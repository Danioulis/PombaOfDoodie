using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{ /// <summary>
/// POMBA
/// </summary>

    public float force;

    void Start()
    {
        force = 2000;
        GetComponent<Rigidbody>().AddForce(transform.up * -force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("referencia"))
        {
            Destroy(gameObject);
        }
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
    }
}
