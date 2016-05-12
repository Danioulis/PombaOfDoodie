using UnityEngine;
using System.Collections;

public class MapRotate : MonoBehaviour {

    private float speed;

	void Start () {
        speed = 10;
    }
	void Update () {
        transform.Rotate(transform.right, speed * Time.deltaTime);
    }
}
