using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ilha1 : MonoBehaviour {

    float step;
    [SerializeField] Sprite[] ilhas;
    // Use this for initialization
    void Start()
    {
        float x = Random.Range(0, 10);
        if(x < 2.5)
        {
            GetComponent<SpriteRenderer>().sprite = ilhas[0];
        }
        else if(x < 5)
        {
            GetComponent<SpriteRenderer>().sprite = ilhas[1];
        }
        else if (x < 7.5)
        {
            GetComponent<SpriteRenderer>().sprite = ilhas[2];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ilhas[3];
        }
        step = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Translate(Vector2.down * Time.deltaTime * step);
    }
}