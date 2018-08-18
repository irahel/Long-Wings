using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_h : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject[] lifes;
    [SerializeField] Sprite full, empty;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<naveA>().get_hp() == 5)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = full;
            lifes[3].GetComponent<SpriteRenderer>().sprite = full;
            lifes[4].GetComponent<SpriteRenderer>().sprite = full;
        }
        else if (player.GetComponent<naveA>().get_hp() == 4)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = full;
            lifes[3].GetComponent<SpriteRenderer>().sprite = full;
            lifes[4].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else if (player.GetComponent<naveA>().get_hp() == 3)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = full;
            lifes[3].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[4].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else if (player.GetComponent<naveA>().get_hp() == 2)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = full;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[3].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[4].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else if (player.GetComponent<naveA>().get_hp() == 1)
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = full;
            lifes[1].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[3].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[4].GetComponent<SpriteRenderer>().sprite = empty;
        }
        else
        {
            lifes[0].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[1].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[2].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[3].GetComponent<SpriteRenderer>().sprite = empty;
            lifes[4].GetComponent<SpriteRenderer>().sprite = empty;
        }

    }
}
