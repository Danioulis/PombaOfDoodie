using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour {

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
}
