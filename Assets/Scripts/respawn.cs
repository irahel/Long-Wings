//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class respawn : MonoBehaviour {

    [SerializeField] float respawn_time;
    [SerializeField] bool can_spawn;
    [SerializeField] GameObject nave_enemy, ptero;
    [SerializeField] Transform Initial, Final;
    enum type { enemy, ptero}
    type atual_type;

    float respawn_time_elapsed;
   
    // Use this for initialization
    void Start ()
    {
        float rand_type = Random.Range(0, 10);
        if (rand_type <= 5) atual_type = type.enemy;
        else atual_type = type.ptero;
        can_spawn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float rand_type = Random.Range(0, 10);
        if (rand_type <= 5) atual_type = type.enemy;
        else atual_type = type.ptero;
        if (can_spawn)
        {
            float rand_x = Random.Range(Initial.position.x, Final.position.x);
            if(atual_type == type.enemy) Instantiate(nave_enemy, new Vector2(rand_x, Initial.position.y), Initial.rotation);
            else Instantiate(ptero, new Vector2(rand_x, Initial.position.y), Initial.rotation);
            can_spawn = false;
            respawn_time_elapsed = 0;
        }
        else
        {
            respawn_time_elapsed += Time.deltaTime;
            if(respawn_time_elapsed >= respawn_time)
            {
                can_spawn = true;
                respawn_time_elapsed = 0;
            }
        }
	}

}
