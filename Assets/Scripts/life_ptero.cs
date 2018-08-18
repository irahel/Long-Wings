using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_ptero : MonoBehaviour {

    pteros player;
    [SerializeField] GameObject[] lifes;
    [SerializeField] Sprite full, empty;

    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<pteros>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.get_hp() == 3)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = full;
        }
        else if (player.get_hp() == 2)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else if (player.get_hp() == 1)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[1].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
        }

    }
}
