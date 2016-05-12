using UnityEngine;
using System.Collections;

public class MenuPrincipalController : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(1);
        }
    }
}
