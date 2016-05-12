using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarAIcontroller : MonoBehaviour
{

    public GameObject referencia;

    public float angulo; // Angulo de rotação/velocidade
    
    public float score;

    void Start()
    {
        referencia = GameObject.FindWithTag("referencia");
        angulo = 20;
    }

    void Update()
    {
        if (gameObject.tag == "pista1")
        {
            transform.RotateAround(referencia.transform.position, -transform.forward, angulo * Time.deltaTime);
        }
        else if (gameObject.tag == "pista2")
        {
            transform.RotateAround(referencia.transform.position, transform.forward, angulo * Time.deltaTime);
        }
    }

    // Bosta acertando carro
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiroPomba"))
        {
            score++;
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("destruirElementos") && gameObject.tag == "pista1")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("destruirElementos2") && gameObject.tag == "pista2")
        {
            Destroy(gameObject);
        }
    }
}
