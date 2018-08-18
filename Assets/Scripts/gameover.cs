using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{

    [SerializeField] GameObject start, quit;
    public int state;
    // Use this for initialization
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        controller();
        updater();
    }

    void updater()
    {
        if (state == 1)
        {
            start.SetActive(true);
            quit.SetActive(false);
        }
        if (state == 2)
        {
            start.SetActive(false);
            quit.SetActive(true);
        }
    }

    void controller()
    {
        if (Input.GetButtonDown("accept"))
        {
            
            if (state == 1)
            {
            Application.LoadLevel("init");
            }
            else
            {
                Application.Quit();
            }
            
        }

        if(Input.GetAxisRaw("Vertical") > 0)
        {
            if(state == 2)
            {
                state = 1;
            }
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (state == 1)
            {
                state = 2;
            }
        }
    }
}
