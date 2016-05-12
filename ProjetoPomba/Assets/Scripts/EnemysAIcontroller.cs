using UnityEngine;
using System.Collections;

public class EnemysAIcontroller : MonoBehaviour
{
    public GameObject spawnPosition;
    public GameObject tiro;

    private GameObject pomba;

    private bool atirar;
    private float fireRate;
    private float nextFire;

    void Start()
    {
        fireRate = 2f;
        nextFire = 0;
        pomba = GameObject.FindWithTag("Player");
        atirar = false;
    }

    void Update()
    {
        TiroController();
    }

    void LateUpdate()
    {
        spawnPosition.transform.LookAt(pomba.transform.position);
    }

    void TiroController()
    {
        // Se puder atirar
        if (atirar && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(tiro, spawnPosition.transform.position, spawnPosition.transform.rotation);
        }
    }

    // Verificar quando pode atirar
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("podeAtirar"))
        {
            atirar = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("podeAtirar"))
        {
            atirar = false;
        }
    }
}
