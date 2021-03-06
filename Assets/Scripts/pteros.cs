﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pteros : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] float destroy_time;
    [SerializeField] int hit_damage;

    enum behaviour { ONLY_DOWN, DIAG, ZIG }
    enum diag { LEFT, RIGHT }
    [SerializeField] diag atual_diag;
    [SerializeField] behaviour atual;
    public bool changed;
    [SerializeField] float init_zig, end_zig;
    float zig_time, zig_time_elapsed;

    bool damaged;
    [SerializeField] float total_time_damaged;
    private float time_elapsed;

    bool colided;
    float time_col, time_col_elapsed;

    // Use this for initialization
    void Start()
    {
        time_col = 1f;
        colided = false;
        changed = false;
        float rand_behaviour = Random.Range(0, 9);
        if (rand_behaviour <= 3) atual = behaviour.ONLY_DOWN;
        else if (rand_behaviour <= 6) atual = behaviour.DIAG;
        else atual = behaviour.ZIG;
        float rand_dir = Random.Range(0, 10);
        if (rand_dir < 5) atual_diag = diag.LEFT;
        else atual_diag = diag.RIGHT;
        Destroy(gameObject, destroy_time);
        zig_time_elapsed = 0;
        float rand_zig = Random.Range(init_zig, end_zig);
        zig_time = rand_zig;
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        death();
        change_color();
        atualize_time();
    }

    void move()
    {
        if (atual == behaviour.ONLY_DOWN)
        {
            GetComponent<Transform>().Translate(Vector2.down * Time.deltaTime * speed);
        }
        else if (atual == behaviour.DIAG)
        {
            if (atual_diag == diag.LEFT)
            {
                GetComponent<Transform>().Translate((Vector2.down + Vector2.left) * Time.deltaTime * speed);
            }
            else
            {
                GetComponent<Transform>().Translate((Vector2.down + Vector2.right) * Time.deltaTime * speed);
            }
        }
        else
        {
            actualize_zig();
            if (atual_diag == diag.LEFT)
            {
                GetComponent<Transform>().Translate((Vector2.down + Vector2.left) * Time.deltaTime * speed);
            }
            else
            {
                GetComponent<Transform>().Translate((Vector2.down + Vector2.right) * Time.deltaTime * speed);
            }
        }


    }

    public void change_dir()
    {
        if (atual_diag == diag.LEFT) atual_diag = diag.RIGHT;
        else atual_diag = diag.LEFT;

    }

    void actualize_zig()
    {
        zig_time_elapsed += Time.deltaTime;
        if (zig_time_elapsed >= zig_time)
        {
            change_dir();
            zig_time_elapsed = 0;
        }
    }

    void death()
    {
        if (hp <= 0) Destroy(gameObject);
    }

    public void take_damage(int damage)
    {
        hp -= damage;
        death();
        damaged = true;
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

    void atualize_time()
    {
        if (colided)
        {
            time_col_elapsed += Time.deltaTime;
            if(time_col_elapsed >= time_col)
            {
                colided = false;
                time_col_elapsed = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!colided)
            {
                collision.gameObject.GetComponent<naveA>().take_damage(hit_damage);
                colided = true;
            }
            
        }
    }

    public int get_hp()
    {
        return hp;
    }
}
