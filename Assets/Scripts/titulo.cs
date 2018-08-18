using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titulo : MonoBehaviour
{
    [SerializeField] GameObject[] naves;
    [SerializeField] GameObject start, quit, h, v, screen;
    int state;
    enum types { AFONSO, HUGO, VINICIUS}
    types type;
    bool inited, ok;


	// Use this for initialization
	void Start ()
    {
        type = types.AFONSO;
        state = 1;
        ok = false;
        inited = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        update_indicator();
       
        
        if (!inited && !ok)
        {
            Controller();
        }
        if (ok)
        {
            update_indicator2();
            Controller2();
        }
        
   
	}

    void update_indicator()
    {
        if(state == 1)
        {
            start.SetActive(true);
            quit.SetActive(false);
        }
        else
        {
            start.SetActive(false);
            quit.SetActive(true);
        }
    }

    void update_indicator2()
    {
        if (type == types.AFONSO)
        {
            start.SetActive(true);
            h.SetActive(false);
            v.SetActive(false);
        }
        else if(type == types.HUGO)
        {
            start.SetActive(false);
            h.SetActive(true);
            v.SetActive(false);
        }
        else
        {
            start.SetActive(false);
            h.SetActive(false);
            v.SetActive(true);
        }
    }

    void Controller()
    {
        if (Input.GetButtonDown("accept"))
        {
            if (state == 1)
            {
                inited = true;
                naves[0].GetComponent<Animator>().SetTrigger("init");
                naves[1].GetComponent<Animator>().SetTrigger("init");
                naves[2].GetComponent<Animator>().SetTrigger("init");
                screen.GetComponent<Animator>().SetTrigger("init");
                start.GetComponent<Animator>().SetTrigger("init");
                Invoke("get_ok", 1);
            }
            else
            {
                Application.Quit();
            }
        }
        if (Input.GetAxisRaw("Vertical") >0 )
        {
            if (state == 2)
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

    void get_ok()
    {        
        ok = true;
    }

    void Controller2()
    {
        if (Input.GetButtonDown("accept"))
        {
            if (type == types.AFONSO)
            {
                naves[0].GetComponent<Animator>().SetTrigger("go");
                naves[1].GetComponent<Animator>().SetTrigger("back");
                naves[2].GetComponent<Animator>().SetTrigger("back");
                Invoke("load_a", 0.8f);
            }
            else if (type == types.HUGO)
            {
                naves[0].GetComponent<Animator>().SetTrigger("back");
                naves[1].GetComponent<Animator>().SetTrigger("go");
                naves[2].GetComponent<Animator>().SetTrigger("back");
                Invoke("load_h", 0.8f);
            }
            else
            {
                naves[0].GetComponent<Animator>().SetTrigger("back");
                naves[1].GetComponent<Animator>().SetTrigger("back");
                naves[2].GetComponent<Animator>().SetTrigger("go");
                Invoke("load_v", 0.8f);
            }
        
        }

        if (Input.GetButtonDown("Right"))
        {
            if (type == types.AFONSO)
            {
                type = types.VINICIUS;
            }
            else if (type == types.HUGO)
            {
                type = types.AFONSO;
            }
        }
        if (Input.GetButtonDown("Left"))
        {
            if (type == types.AFONSO)
            {
                type = types.HUGO;
            }
            else if (type == types.VINICIUS)
            {
                type = types.AFONSO;
            }
        }
    }

    void load_a()
    {
        Application.LoadLevel("fase1_a");
    }
    void load_h()
    {
        Application.LoadLevel("fase1_h");
    }
    void load_v()
    {
        Application.LoadLevel("fase1_v");
    }
}

