using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// OBS: WaiForSeconds...* Estruturar melhor a classe InstantiateController();... Arrumar 'podeInstanciar'

public class GameController : MonoBehaviour
{
    // Cars
    public GameObject[] cars;
    private int indiceCars;
    //public GameObject spawnCars;
    public static int carrosPista1, carrosPista2;
    //

    // Drone
    public Transform[] spawnDrone;

    public int indiceSpawnDrone1;
    public int indiceSpawnDrone2;

    public bool sortear = false;
    public bool sorteou = false;

    public GameObject drone;
    //

    // Map
    public GameObject[] mapas;
    public GameObject spawn;
    public GameObject pomba;

    public int pontosVerificacao;
    public int indice;
    public float speed;

    public bool podeInstanciar;

    private Vector3 scale;
    //

    public bool _morreu;

    void Start()
    {
        _morreu = false;
        ControleSpawnCar();
        ControleSpawnDrone();

        podeInstanciar = true;
        indice = 0;

    }

    void Update()
    {
        transform.Rotate(transform.right, speed * Time.deltaTime);

        pontosVerificacao = spawn.GetComponent<SpawnController>().numTag;

        LevelConstruct();

        if (sortear)
        {
            SortearPosicoes();
        }

        _morreu = pomba.GetComponent<PombaController>().morreu;

        if (_morreu)
        {
            GetComponent<AudioSource>().Stop();
        }

        ZUEIRA();
    }

    void LateUpdate()
    {
        if (indice == mapas.Length)
        {
            indice = 0;
        }
    }

    // MAP //

    // Building procedural map
    public void LevelConstruct()
    {
        // Diferenciar posicao dos mapas 1 e 2
        if (podeInstanciar)
        {
            if (pontosVerificacao == 1)
            {
                podeInstanciar = false;
                GameObject.Destroy(GameObject.FindWithTag("map1"));
                InstantiateMapController();
            }
            if (pontosVerificacao == 2)
            {
                podeInstanciar = false;
                GameObject.Destroy(GameObject.FindWithTag("map2"));
                InstantiateMapController();
            }
        }

        if (pontosVerificacao == 0)
        {
            podeInstanciar = true;
        }
    }

    // Set Scale and Instantiate
    public void InstantiateMapController()
    {

        if (pontosVerificacao == 1)
        {
            scale = GameObject.FindWithTag("map2").transform.localScale;
            scale.y *= -1; // Direcao contraria do mapa em cena

            // Instanciar
            mapas[indice].transform.localScale = scale;
            mapas[indice].tag = "map1";
            Instantiate(mapas[indice], transform.position, transform.rotation);

            GameObject pontoVerificacao = GameObject.FindWithTag("pontoVerificacao");
            pontoVerificacao.tag = "pontoVerificao1";

            indice++;
        }
        if (pontosVerificacao == 2)
        {
            scale = GameObject.FindWithTag("map1").transform.localScale;
            scale.y *= -1; // Direcao contraria do mapa em cena

            // Instanciar
            mapas[indice].transform.localScale = scale;
            mapas[indice].tag = "map2";
            Instantiate(mapas[indice], transform.position, transform.rotation);

            GameObject pontoVerificacao = GameObject.FindWithTag("pontoVerificacao");
            pontoVerificacao.tag = "pontoVerificao2";

            indice++;
        }
    }

    void IndiceController()
    {
        if (indice > mapas.Length)
        {
            indice = 0;
        }
    }

    // CARS //
    void InstantiateCarsPista1()
    {
        indiceCars = Random.Range(0, 5);
        Vector3 positionSpawn1 = new Vector3(-3, -60, 0);
        cars[indiceCars].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cars[indiceCars].tag = "pista1"; // Controlar direcao de movimento ao instaciar CARRO --- Controle feito no script do carro
        Instantiate(cars[indiceCars], positionSpawn1, cars[0].transform.rotation);
        carrosPista1++;
    }
    void InstantiateCarsPista2()
    {
        indiceCars = Random.Range(0, 5);
        Vector3 positionSpawn2 = new Vector3(3, -60, 0);
        cars[indiceCars].transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        cars[indiceCars].tag = "pista2";
        Instantiate(cars[indiceCars], positionSpawn2, cars[0].transform.rotation);
        carrosPista2++;
    }
    private void ControleSpawnCar()
    {
        InvokeRepeating("InstantiateCarsPista1", 4, 4);
        InvokeRepeating("InstantiateCarsPista2", 3, 4);
    }

    // Drone //
    void ControleSpawnDrone()
    {
        InvokeRepeating("InstantiateDrone", 5, 3);
    }
    void InstantiateDrone()
    {
        sortear = true;

        if (sorteou)
        {
            Instantiate(drone, spawnDrone[indiceSpawnDrone1].position, drone.transform.rotation);
            Instantiate(drone, spawnDrone[indiceSpawnDrone2].position, drone.transform.rotation);
            sorteou = false;
        }
    }

    void SortearPosicoes()
    {
        indiceSpawnDrone1 = Random.Range(0, spawnDrone.Length);
        indiceSpawnDrone2 = Random.Range(0, spawnDrone.Length);
        if (indiceSpawnDrone2 != indiceSpawnDrone1)
        {
            sorteou = true;
            sortear = false;
        }
    }

    void ZUEIRA()
    {
        if (Input.GetKey(KeyCode.O))
        {
            Time.timeScale += 0.1f;
        }
        else if (Input.GetKey(KeyCode.L) && Time.timeScale >= 0.1)
        {
            Time.timeScale -= 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}











