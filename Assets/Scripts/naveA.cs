using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveA : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] bool can_fire;
    [SerializeField] float step, fire_time;
    [SerializeField] GameObject explo;
    [SerializeField] GameObject bullet, bullet_h, bullet_v;
    [SerializeField] Transform fire_point_1, fire_point_2, fire_point_3, fire_point_4, fire_point_5, max_y, min_y;
    float fire_time_elapsed;
    enum moves { RIGHT, LEFT, UP, DOWN}
    moves last_move;
    bool dead;
    bool coliding;

    bool damaged;
    [SerializeField] float total_time_damaged;
    private float time_elapsed;

    [SerializeField] Animator sprite , lab;
    [SerializeField] bool init;

    [SerializeField] AudioSource shoot_sound;
    

    enum types { AFONSO, HUGO, VINICIUS}
    [SerializeField] types my_type;


    // Use this for initialization
    void Start ()
    {
        dead = false;
        coliding = false;
        can_fire = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!init)
        {
            move();
            fire();
            death();
            change_color();
        }
    
    }

    public void take_damage(int damage)
    {
        hp -= damage;
        death();
        damaged = true;
    }

    void move()
    {
  
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (!coliding)
                {
                    GetComponent<Transform>().Translate(Vector2.right * Time.deltaTime * step);
                    last_move = moves.RIGHT;
                }
                
            }
            else
            {
                if (!coliding)
                {
                    GetComponent<Transform>().Translate(Vector2.left * Time.deltaTime * step);
                    last_move = moves.LEFT;
                }
            }

        }
        if(Input.GetAxisRaw("Vertical") != 0)
        {
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                if(GetComponent<Transform>().position.y < max_y.position.y)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * step);
                }
            }
            else
            {
                if (GetComponent<Transform>().position.y > min_y.position.y)
                {
                    transform.Translate(Vector2.down * Time.deltaTime * step);
                }
            }
        }
    }

    void fire()
    {
       
        if (my_type == types.AFONSO)
        {
            if (Input.GetButtonDown("Fire1") && can_fire)
            {
                Instantiate(bullet, fire_point_1.position, fire_point_1.rotation);
                Instantiate(bullet, fire_point_2.position, fire_point_2.rotation);
                shoot_sound.Play();
                can_fire = false;
                fire_time_elapsed = 0;
            }
        }else if(my_type == types.HUGO)
        {
            if (Input.GetButtonDown("Fire1") && can_fire)
            {
                Instantiate(bullet_h, fire_point_1.position, fire_point_1.rotation);
                Instantiate(bullet_h, fire_point_2.position, fire_point_2.rotation);
                Instantiate(bullet_h, fire_point_3.position, fire_point_3.rotation);
                Instantiate(bullet_h, fire_point_4.position, fire_point_4.rotation);
                Instantiate(bullet_h, fire_point_5.position, fire_point_5.rotation);
                shoot_sound.Play();
                can_fire = false;
                fire_time_elapsed = 0;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && can_fire)
            {
                Instantiate(bullet_v, fire_point_1.position, fire_point_1.rotation);
                shoot_sound.Play();
                can_fire = false;
                fire_time_elapsed = 0;
            }
        }


        if (!can_fire)
        {
            fire_time_elapsed += Time.deltaTime;
            if(fire_time_elapsed >= fire_time)
            {
                can_fire = true;
                fire_time_elapsed = 0;
            }
        }
    }

    void death()
    {
        if (hp <= 0 && !dead)
        {
            dead = true;
            sprite.SetTrigger("death");
            lab.SetTrigger("death");
            
            //Destroy(gameObject, 1f);
            Instantiate(explo, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            Invoke("gameover", 1);
        }
    }

    void gameover()
    {
        Application.LoadLevel("gameover");
    }

    void change_color()
    {
        if (this.damaged)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        this.time_elapsed += Time.deltaTime;
        if ((this.time_elapsed >= this.total_time_damaged) && this.damaged)
        {
            damaged = false;
            this.time_elapsed = 0;
        }
    }

    public string last_move_g()
    {
        if (last_move == moves.LEFT)        return "L";
        else if (last_move == moves.RIGHT)  return "R";
        else if (last_move == moves.DOWN)   return "D";
        else                                return "U";
    }

    public void stop_force()
    {
        Invoke("stops", 1);
        coliding = true;
    }

    void stops()
    {        
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Rigidbody2D>().WakeUp();
        coliding = false;
    }
    
    public int get_hp()
    {
        return hp;  
    }
}
