using UnityEngine;
using System.Collections;

public class RotacaoTeste : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 3000 * Time.deltaTime, 0));
    }
}
