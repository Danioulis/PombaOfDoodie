using UnityEngine;
using System.Collections;

public class PowerUpsController : MonoBehaviour
{
    public GameObject maca;
    public GameObject positionSpawn;

    private float posteRandom;

    void Start()
    {

        float numRandom = Random.Range(1, 5);

        if (numRandom == 3)
        {
            // Spawnar apenas no mapa que está sendo criado
            posteRandom = Random.Range(1, 4);

            positionSpawn = GameObject.FindWithTag("poste" + posteRandom);
            Instantiate(maca, positionSpawn.transform.position, maca.transform.rotation);

        }
    }
}
