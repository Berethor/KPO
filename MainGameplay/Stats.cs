using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    Slider HP_value;
    public int left_border;
    public int right_border;
    public int lives;
    public int hp;
    public int maxhp;
    public int dmg;
    public int armor;
    public int weight;
    public int voice;
    public bool jumpenable;
    public bool attacking = true;
    public bool died = false;
    public bool block = false;
    SaveFiles saveFiles;
    Animator animation;
    GameObject photo;
    public GameObject RespawnFlag;
    public List<GameObject> EnemyList;
    // Use this for initialization
    void Start()
    {
        saveFiles = GameObject.Find("SaveFiles").GetComponent<SaveFiles>();
        lives = saveFiles.lives;
        animation = gameObject.GetComponent<Animator>();
        weight = armor * 5;
        HP_value = GameObject.Find("HP_value").GetComponent<Slider>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HP_value.value = hp / (maxhp + 0.0f);
        if (hp <= 0 && died == false)
        {
            hp = 1;
            Dead(1);
        }
        if(transform.position.y <= -10 && died == false)
        {
            hp = 1;
            Dead(2);
        }


    }
    public void RecieveDmG(int damage)
    {
        if (!block)
            if (damage > armor)
            {
                hp = hp - damage + armor;
            }
            else{}
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("What_to_do", 7);
            StartCoroutine(BLockAnimation());
            }
    }
    void Dead(int type)
    {
        lives--;
        if (lives == 0)
            SceneManager.LoadScene("Dead Scene");
        if (type == 1)
        {
            animation.SetInteger("What_to_do", 10); 
            died = true;
            StartCoroutine(WaitDeath());
        }
        if (type==2)
        {
            animation.SetInteger("What_to_do", 10); 
            died = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(WaitDeath());
        }
    }
    public void Movement()
    {
        voice = weight + 10;
    }
    public void Stop_move()
    {
        voice = weight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpenable = true;
            if (animation.GetInteger("Phase_Flying")==2)
            {
                died = true;
                animation.SetInteger("What_to_do",11);
                animation.SetInteger("Phase_Flying", 1);
                StartCoroutine(WaitGround());
            }
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (animation.GetInteger("Phase_Flying") == 2)
            {
                died = true;
                animation.SetInteger("What_to_do", 11);
                animation.SetInteger("Phase_Flying", 1);
                StartCoroutine(WaitGround());
            }
        }
            if (collision.gameObject.tag=="RespawnFlag")
        {
            if(RespawnFlag!=null)
            RespawnFlag.GetComponent<Animator>().SetInteger("What to do", 0);
            collision.gameObject.GetComponent<Animator>().SetInteger("What to do", 1);
            RespawnFlag = collision.gameObject;
        }
    }
    void Attack()
    {
        int b = Random.Range(10, 20);
        if(!block)
        if (!attacking)
        {
            attacking = true;
            if(b<15)
            animation.SetInteger("What_to_do", 4);
            else
                animation.SetInteger("What_to_do", 5);
            StartCoroutine(WaitAttack());
        }
    }
    public IEnumerator WaitAttack()
    {

        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (Vector2.Distance(transform.position, EnemyList[i].GetComponent<Transform>().position) < 3)
                EnemyList[i].SendMessage("RecieveDmG", dmg);

        }
        animation.SetInteger("What_to_do", 0);
        attacking = false;
    }
    public IEnumerator WaitGround()
    {
        yield return new WaitForSeconds(0.3f);
        died = false;
    }
    public IEnumerator WaitDeath()
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(RespawnFlag.transform.position.x, RespawnFlag.transform.position.y + 2f, RespawnFlag.transform.position.z);
        hp = maxhp;
        animation.SetInteger("What_to_do", 0);
        died = false;

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public IEnumerator BLockAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Animator>().SetInteger("What_to_do", 3);
    }

   
}