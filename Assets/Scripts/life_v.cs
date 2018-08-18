using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_v : MonoBehaviour {
    GameObject player;
    [SerializeField] GameObject lifes;
    [SerializeField] Sprite full, empty;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<naveA>().get_hp() == 1)
        {
            lifes.GetComponent<SpriteRenderer>().sprite = full;

        }
        else
        {
            lifes.GetComponent<SpriteRenderer>().sprite = empty;

        }

    }
}
