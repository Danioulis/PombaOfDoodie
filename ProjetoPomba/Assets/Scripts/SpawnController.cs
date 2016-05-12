using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public int numTag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pontoVerificao1")
        {
            numTag = 1;
        }
        if (other.tag == "pontoVerificao2")
        {
            numTag = 2;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        numTag = 0;
    }
}
