using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class macaParametersController : MonoBehaviour
{
    private GameObject referencia;

    void Start()
    {
        // Encontrar referencia e afiliar-se a ela
        referencia = GameObject.FindWithTag("referencia");
        transform.SetParent(referencia.transform);
    }

    void Update()
    {
        Rotacao();
    }

    void Rotacao()
    {
        transform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destruirElementos"))
        {
            Destroy(gameObject);
        }
    }
}
