using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{
    public GameObject referencia;
    public Vector3 angle;
    public float speed;

    void Start()
    {
        // Encontrar referencia e afiliar-se a ela
        referencia = GameObject.FindWithTag("referencia");
        transform.SetParent(referencia.transform);
    }
}
