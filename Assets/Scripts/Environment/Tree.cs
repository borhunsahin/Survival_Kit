using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamagable
{
    public float health;
    public GameObject wood;
    private bool isDestroyed = false;
    void Update()
    {
        if(health <=0 && !isDestroyed)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(wood, transform.position + new Vector3(0,.5f,0), wood.transform.rotation);
            Instantiate(wood, transform.position + new Vector3(0, .5f, .5f), wood.transform.rotation);
            Instantiate(wood, transform.position + new Vector3(.5f, .5f, 0), wood.transform.rotation);
            isDestroyed = true;
        }
    }
    public void Damage(float damage) => health -= damage;
}
