using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleUI : MonoBehaviour{

	// Use this for initialization
	int pontos;
	public Text pontosText;

	void Start () {

		pontos = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		pontosText.text = "Pontos: " + pontos;

	}

}
