using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resp_ninbus : MonoBehaviour
{
    public Transform []points;
    [SerializeField] GameObject ninbus;
    [SerializeField] float respawn_time;
    float respawn_time_elapsed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        respawn_time_elapsed += Time.deltaTime;
        if(respawn_time_elapsed >= respawn_time)
        {
            int index = Random.Range(0,8);
            Instantiate(ninbus, points[index].position, points[index].rotation);
            respawn_time_elapsed = 0;
           
        }
	}
}
