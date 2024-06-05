using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject BuildObject;
    bool isBuildable = true;
    RaycastHit hit;

    public BuildSO buildSO;
    void Start()
    {
        Material material = GetComponent<Material>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5000f, (1 << 3)))
        {
            transform.position = hit.point;
        }
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5000f, (1 << 3)))
        {
            transform.position = hit.point;
        }
        if (Input.GetMouseButton(0) && isBuildable)
        {
            Instantiate(BuildObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("Terrain"))
        {
            isBuildable = false;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isBuildable = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
