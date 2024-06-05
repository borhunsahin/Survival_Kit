using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour, IDamagable
{
    public float health;
    public GameObject stick;
    private bool isDestroyed = false;
    void Update()
    {
        if (health <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime*0.1f);
        }
        if(health <= 0 && !isDestroyed)
        {
            Instantiate(stick, transform.position + new Vector3(0, .5f, 0), stick.transform.rotation);
            Instantiate(stick, transform.position + new Vector3(0, .5f, .5f), stick.transform.rotation);
            Instantiate(stick, transform.position + new Vector3(.5f, .5f, 0), stick.transform.rotation);
            isDestroyed = true;
        }
    }
    public void Damage(float damage) => health -= damage;
}
