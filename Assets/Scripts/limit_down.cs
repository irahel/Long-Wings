using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limit_down : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject, 0.5f);
        }
        if (collision.gameObject.tag == "ptero")
        {
            Destroy(collision.gameObject, 1.5f);
        }
    }
}
