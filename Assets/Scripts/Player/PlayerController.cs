using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerAnimationController playerAnimController;

    [SerializeField] public InventorySO playerInventory;
    [SerializeField] public UIInventoryManager uiInventoryManager;

    public Vector2 input;
    private Vector3 direction;
    private RaycastHit hit;

    [SerializeField] public Player player;
    [SerializeField] public Gravity gravity;

    private Camera playerCam;

    [HideInInspector] public float currentSpeedMultiplier;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimController = GameObject.Find("Player").GetComponentInChildren<PlayerAnimationController>();
        playerCam = Camera.main;

        currentSpeedMultiplier = 1;
    }
    void Update()
    {
        if(player.isActionMode)
            ActionMode();
        else
            FreeMode();
        GravityApply();
        Movement();

        if (!player.isTabMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    //private float Linear(float start,float end,float duration)
    //{
    //    float time = 0;
    //    float result = 0;
    //    time += Time.time;

    //    result = start + (end - start) * time / duration;

    //    if(result > end)
    //        result = end;
    //    if(end < 0.1)
    //        time = 0;

    //    return result;
    //}
    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0, input.y); 
    }
    private void Movement()
    {
        characterController.Move((new Vector3(direction.x * currentSpeedMultiplier, direction.y, direction.z * currentSpeedMultiplier) * player.speed  * Time.deltaTime));
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started && player.isFreeMode && !player.isCrouch)
            currentSpeedMultiplier = player.speedMultiplier;
        //else if(context.started && player.isActionMode && !player.isCrouch)
            //currentSpeedMultiplier = player.speedMultiplier;
        else if (context.canceled)
            currentSpeedMultiplier = 1;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!characterController.isGrounded) return;

        player.isCrouch = false;

        gravity.velocity += player.jumpPower;
        playerAnimController.animator.SetTrigger("isJump");
    }
    public void Crouch(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (player.isCrouch)
            player.isCrouch = false;
        else
            player.isCrouch = true;
    }
    public void Action(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (player.isActionMode)
        {
            player.isActionMode = false;
            player.isFreeMode = true;
        }
        else
        {
            player.isActionMode = true;
            player.isFreeMode = false;
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if(player.isActionMode)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.collider.TryGetComponent(out IHoldable holdableItem) && hit.collider.TryGetComponent(out ICollectable collectableItem))
                {
                    if(hit.collider.TryGetComponent(out Item item))
                    {
                        if ((item.itemSO.itemType == ItemType.Tool || item.itemSO.itemType == ItemType.Weapon))
                        {
                            if(!player.isFullHand)
                            {
                                holdableItem.TakeOnHand(item.itemSO);
                                player.inHandObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            }
                            else
                            {
                                collectableItem.Collect(item.itemSO);
                            }
                        }
                        else if((item.itemSO.itemType == ItemType.Craft))
                        {
                            collectableItem.Collect(item.itemSO);
                        }
                    }
                }
            }
        }
    }
    public void Drop(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (player.inHandObject != null)
        {
            GameObject dropedObject = player.inHandObject;
            dropedObject.GetComponent<Rigidbody>().isKinematic = false;
            Instantiate(dropedObject, player.inHandObject.transform.position, transform.rotation);
            playerInventory.DeleteItem(player.inHandObject.GetComponent<Item>().itemSO, -1);
            uiInventoryManager.UpdateUIForInventory();

            player.inHandObject.SetActive(false);
            player.isFullHand = false;
            player.inHandObject = null;
        }
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if(player.isFullHand)
            playerAnimController.animator.SetTrigger("AxeAttack");
    }
    public void Inventory(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if(player.isTabMenu)
            player.isTabMenu = false;
        else
            player.isTabMenu = true;
    }
    public void Hotbar_1(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        HotbarSelecter(playerInventory.inventorySlots[20]);

    }
    public void Hotbar_2(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        HotbarSelecter(playerInventory.inventorySlots[21]);
    }
    public void Hotbar_3(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        HotbarSelecter(playerInventory.inventorySlots[22]);
    }
    public void Hotbar_4(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        HotbarSelecter(playerInventory.inventorySlots[23]);
    }
    public void Hotbar_5(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        HotbarSelecter(playerInventory.inventorySlots[24]);
    }
    public void HotbarSelecter(Slot hotbarSlot)
    {
        foreach (GameObject holdableObject in player.holdableObjects)
        {
            if (holdableObject.GetComponent<Item>().itemSO == hotbarSlot.item)
            {
                if (!player.isFullHand)
                {
                    if (holdableObject.TryGetComponent(out IHoldable holdable))
                    {
                        player.inHandObject = holdableObject;
                        holdableObject.SetActive(true);
                        player.isFullHand = true;
                        holdableObject.GetComponent<Rigidbody>().isKinematic = true;
                        break;
                    }
                }
                else
                {
                    if (player.inHandObject.GetComponent<Item>().itemSO == hotbarSlot.item)
                    {
                        player.inHandObject = null;
                        holdableObject.SetActive(false);
                        player.isFullHand = false;
                        holdableObject.GetComponent<Rigidbody>().isKinematic = true;
                        break;
                    }
                    else
                    {
                        player.inHandObject.SetActive(false);
                        player.inHandObject = holdableObject;
                        player.inHandObject.SetActive(true);
                        holdableObject.GetComponent<Rigidbody>().isKinematic = true;
                        break;
                    }

                }
            }
            else if(hotbarSlot.item == null && player.isFullHand)
            {
                player.inHandObject.SetActive(false);
                break;
            }
        }
            
    }
    private void FreeMode()
    {
        if (input.sqrMagnitude > 0.05)
        {
            direction = Quaternion.Euler(0.0f, playerCam.transform.eulerAngles.y, 0.0f) * new Vector3(input.x, 0.0f, input.y);
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
    }
    private void ActionMode()
    {
        direction = transform.forward * input.y + transform.right * input.x + transform.up * gravity.velocity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, playerCam.transform.eulerAngles.y, transform.localEulerAngles.z);
    }
    private void GravityApply()
    {
        if (characterController.isGrounded && gravity.velocity < -2)
        {
            gravity.velocity = -1f;
        }
        else
        {
            gravity.velocity += gravity.gravity * gravity.gravityMultipler * Time.deltaTime;
            direction.y = gravity.velocity;
        }
    }
}
[Serializable]
public struct Player
{
    public float speed;
    public float speedMultiplier;
    public float jumpPower;

    public bool isTabMenu;

    public bool isActionMode;
    public bool isFreeMode;
    public bool isCrouch;

    public bool isFullHand;
    public GameObject inHandObject;

    public List<GameObject> holdableObjects;
}
[Serializable]
public struct Gravity
{
    public float gravity;
    public float gravityMultipler;
    [HideInInspector] public float velocity;
}
