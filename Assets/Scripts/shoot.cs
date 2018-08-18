using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float destroy_time;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, destroy_time);
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
	}   

    void move()
    {
        GetComponent<Transform>().Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy>().take_damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ptero")
        {
            collision.gameObject.GetComponent<pteros>().take_damage(damage);
            Destroy(gameObject);
        }
    }
    
}
