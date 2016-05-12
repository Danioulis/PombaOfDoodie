using UnityEngine;
using System.Collections;

public class EnemyTiroController : MonoBehaviour
{
    public float force;

    private float time;

    void Start()
    {
        force = 2000;
        GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }

    void Update()
    {
        time += 0.01f;
        if (time >= 3)
        {
            Destroy(gameObject);
        }
    }
}
