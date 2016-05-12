using UnityEngine;
using System.Collections;

public class DroneAIcontroller : MonoBehaviour
{

    private GameObject reference;

    public float angulo; // Angulo de rotação/velocidade

    void Start()
    {
        reference = GameObject.FindWithTag("referencia");

        angulo = Random.Range(30, 30);
    }

    void Update()
    {
        transform.RotateAround(reference.transform.position, transform.right, angulo * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destruirElementos"))
        {
            Destroy(gameObject);
        }
    }
}
