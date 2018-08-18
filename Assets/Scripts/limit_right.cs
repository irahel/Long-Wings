using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limit_right : MonoBehaviour
{
    [SerializeField] float force;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!collision.gameObject.GetComponent<enemy>().changed) collision.gameObject.GetComponent<enemy>().change_dir();
        }
        if (collision.gameObject.tag == "ptero")
        {
            if (!collision.gameObject.GetComponent<pteros>().changed) collision.gameObject.GetComponent<pteros>().change_dir();
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<naveA>().last_move_g() == "R")
            {
                collision.gameObject.GetComponent<naveA>().stop_force();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }
            if (collision.gameObject.GetComponent<naveA>().last_move_g() == "L")
            {
                collision.gameObject.GetComponent<naveA>().stop_force();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (collision.gameObject.GetComponent<enemy>().changed) collision.gameObject.GetComponent<enemy>().changed = false;
        }
        if (collision.gameObject.tag == "ptero")
        {
            if (collision.gameObject.GetComponent<pteros>().changed) collision.gameObject.GetComponent<pteros>().changed = false;
        }
      
    }
}

