using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AI_First_Try : MonoBehaviour
{


    Quaternion target = Quaternion.Euler(0, 90, 0);
    Quaternion target2 = Quaternion.Euler(0, -90, 0);
    public int hp;
    public int maxhp;
    bool unconsious;
    bool attacking;
    bool rewarded;
    public int armor;
    public int reward;
    public int dmg;
    public bool knowledge_about_me;
    public int speed = 3;
    bool dead = false;
    GameObject Target;
    Stats check;
    Transform position;
    Animator animator;
    int a;//сохранение анимации
    SpriteRenderer flip;
    Vector3 first_position;
    // Use this for initialization
    void Start()
    {
        first_position = transform.position;
        Target = GameObject.Find("Hero");
        check = Target.GetComponent<Stats>();
        check.EnemyList.Add(gameObject);
        position = GetComponent<Transform>();
        flip = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      if(!dead)
        if (unconsious == false)
        {
            if (knowledge_about_me== true)
            {
                if (Target.GetComponent<Transform>().position.x - position.position.x > 4)
                {
                    animator.SetInteger("What_to_do", 1);

                    transform.localScale = (new Vector3(1, 1, 1));
                    position.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else if (Target.GetComponent<Transform>().position.x - position.position.x < -4)
                {
                    animator.SetInteger("What_to_do", 1);

                    transform.localScale = (new Vector3(-1, 1, 1));
                    position.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
                else
                    if (!attacking && (Vector2.Distance(Target.GetComponent<Transform>().position, position.position) < 4))
                {
                    attacking = true;
                    animator.SetInteger("What_to_do", 2);
                        StartCoroutine(WaitForAttack());
                }

            }
            if (knowledge_about_me == false)
                {
                    if (first_position.x - position.position.x > 1)
                    {
                        animator.SetInteger("What_to_do", 1);

                        transform.localScale = (new Vector3(1, 1, 1));
                        position.position += new Vector3(speed * Time.deltaTime, 0, 0);
                    }
                    else if (first_position.x - position.position.x  < -1)
                    {
                        animator.SetInteger("What_to_do", 1);

                        transform.localScale = (new Vector3(-1, 1, 1));
                        position.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        animator.SetInteger("What_to_do", 0);
                    }
                
                }
            if (check.voice >= 20 && (Vector2.Distance(Target.GetComponent<Transform>().position, position.position) < 10))
                knowledge_about_me = true;
            if (((Vector2.Distance(Target.GetComponent<Transform>().position, position.position) > 40)&& (knowledge_about_me==true))|| (check.died==true))
            {
                animator.SetInteger("What_to_do", 1);
                knowledge_about_me = false;
            }
        }
    }
    void RecieveDmG(int dmg)
    {
        unconsious = true;
        if (hp > 0)
            hp = hp - dmg;
        else
        {
            hp = 0;
            dead = true;
        }
        a = animator.GetInteger("What_to_do");
        animator.SetInteger("What_to_do", 4);
        StartCoroutine(Wait());
        foreach (Transform child in transform)
        {
            if(child.name== "HP-level")
            child.transform.localScale = new Vector3(0.11f * (hp / (float)maxhp), 0.009374954f, 1);
        }
        if (hp <= 0 && dead==true)
            Death();
    }
    void Death()
    {
        if (!rewarded)
            GameObject.Find("SaveFiles").GetComponent<SaveFiles>().money += reward;
        rewarded = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        animator.SetInteger("What_to_do", 3);
        StartCoroutine(DeathW());
    }
    public IEnumerator DeathW()
    {
        yield return new WaitForSeconds(5f);
        transform.position = new Vector3(11, -12, 0.1f);
        animator.SetInteger("What_to_do", 0);
        StartCoroutine(Ressurect());
    }
    public IEnumerator Ressurect()
    {
        yield return new WaitForSeconds(10);
        dead = false;
        transform.position = first_position;
        rewarded = false;
        hp = maxhp;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
    public IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.6f);
        unconsious = false;
        animator.SetInteger("What_to_do", a);
    }
    public IEnumerator WaitForAttack()
    {

        yield return new WaitForSeconds(1);
        if (unconsious == false)
        {
            
            check.SendMessage("RecieveDmG", dmg);
        }
        attacking = false;
    }
}
