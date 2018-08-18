using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    [SerializeField] float time;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
