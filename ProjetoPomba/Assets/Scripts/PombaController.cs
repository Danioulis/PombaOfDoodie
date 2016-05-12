using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class InvisibleWalls
{
    public float xMin, xMax;
}

public class PombaController : MonoBehaviour
{
    public GameObject _cam;
    public GameObject maca;
    public InvisibleWalls invWalls;

	public Material pombaMaterial;

    public Transform reference;
    public Transform spawnTiro;

    public GameObject tiro;
    public GameObject pomba;

    public float speed;
    public float angle;

    private float vida;
    private float fireRate;
    private float nextFire;

    // Animations
    public Animator anim;
    public bool voando = false;

    // Audios
    public AudioClip[] sound;
    private int indiceSound;
    public bool morreu;

    // UI
    public Text text;
    private bool powerUp;
    private float time = 0;
    public Image[] imageUI;
    private int indiceVidas;

    void Start()
    {
		
        morreu = false;
        powerUp = false;
        indiceVidas = 2;
        vida = 3;
        fireRate = 0.5f;
        nextFire = 0;
        // Margem
        invWalls.xMin = -14;
        invWalls.xMax = 17;
        angle = 2;
		pombaMaterial.SetColor ("_Color", Color.white);
    }

    void Update()
    {
        TiroController();

        PowerUpsController();
    }

    void FixedUpdate()
    {
        // Movimentos nao touch
        Movimento();
    }

    void TiroController()
    {
        // Bosta spawn
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            anim.SetTrigger("Atirar");

            nextFire = Time.time + fireRate;

            indiceSound = Random.Range(1, 3);
            GetComponent<AudioSource>().PlayOneShot(sound[2]);

            Instantiate(tiro, spawnTiro.position, tiro.transform.rotation);
        }
    }

	void TiroTouch()
	{

		if (Time.time > nextFire)
		{
			anim.SetTrigger ("Atirar");

			nextFire = Time.time + fireRate;

			indiceSound = Random.Range (1, 3);
			GetComponent<AudioSource> ().PlayOneShot (sound [2]);

			Instantiate (tiro, spawnTiro.position, tiro.transform.rotation);
		}
	}

    void PowerUpsController()
    {
        // ------------------------------------------------------- MUDAR PARA WaitForSeconds -------------------------------------------------------------------
        if (powerUp)
        {
            imageUI[3].gameObject.SetActive(true); // Mostrar imagem do Powerup
            fireRate = 0.1f;  // Cagar mais rapido

            time += 0.1f; // Desativar PowerUp depois de um tempo

            if (time >= 20)
            {
                powerUp = false;

            }
        }
        else
        {
            imageUI[3].gameObject.SetActive(false);
            fireRate = 0.5f;
            time = 0;
        }
    }

    void Movimento()
    {
        // Mover pomba pra esqueda/direita
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * -speed;

        //Invisible walls
        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, invWalls.xMin, invWalls.xMax),
                transform.position.y,
                transform.position.z
            );

        // Rotacionar pro lado ao mover a pomba
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, GetComponent<Rigidbody>().velocity.x * angle, 0);

        // Animations
        if (moveHorizontal != 0)
        {
            anim.SetTrigger("Voar");
            voando = true;
        }
        if (voando && GetComponent<Rigidbody>().velocity.x == 0)
        {
            voando = false;
            anim.SetTrigger("PararDeVoar");
        }
    }

    void VidaController()
    {
        vida--;
		pombaMaterial.SetColor ("_Color", Color.red);
		GetComponent<BoxCollider> ().enabled = false;
		Invoke ("FimDano", 1.0f);
        if (vida <= 0)
        {
            morreu = true;
            text.text = "Você Perdeu! 'R' pra recomeçar";
            Time.timeScale = 0;
        }
        if (indiceVidas >= 0)
        {
            imageUI[indiceVidas].gameObject.SetActive(false);
            indiceVidas--;
        }
    }

	void FimDano()
	{

		pombaMaterial.SetColor ("_Color", Color.white);
		GetComponent<BoxCollider> ().enabled = true;

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiroEnemy") || other.gameObject.CompareTag("drone"))
        {
            anim.SetTrigger("Dano");

            _cam.GetComponent<Animator>().SetTrigger("Vibrate");

            Destroy(other.gameObject);

            VidaController();
        }
        else if (other.gameObject.CompareTag("maca"))
        {
            GetComponent<AudioSource>().PlayOneShot(sound[3]);

            Destroy(other.gameObject);

            powerUp = true;
        }
    }
}
