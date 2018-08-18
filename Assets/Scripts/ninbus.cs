using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninbus : MonoBehaviour {

    float step;

	// Use this for initialization
	void Start () {
        step = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().Translate(Vector2.down * Time.deltaTime * step);
	}
}
