using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpScript : MonoBehaviour, IPointerDownHandler
{
    GameObject hero;
    Rigidbody2D force;
    Transform pos;
    Animator animator;
    bool flag = true;
    public int power;//сила прыжка
    void Start () {        
        hero = GameObject.Find("Hero");
        animator = hero.GetComponent<Animator>();
        force = hero.GetComponent<Rigidbody2D>();
        pos = hero.GetComponent<Transform>();

    }
    private void Update()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (hero.GetComponent<Stats>().died == false)
            if (hero.GetComponent<Stats>().jumpenable)
        {
                hero.GetComponent<Stats>().jumpenable = false;
                animator.SetInteger("What_to_do", 2);
                StartCoroutine(Wait());
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        force.AddForce(new Vector2(0f, 30 * power));
        animator.SetInteger("Phase_Flying", 2);
    }
}
