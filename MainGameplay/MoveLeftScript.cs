using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveLeftScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    GameObject hero;
    Transform move;
    public float speed;
    Animator animator;
    Stats voice;//позиция джойстика
    bool flag=false;//флаг на проверку отпустил ли джойстик или нет
	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero");
        move = hero.transform;
        animator = hero.GetComponent<Animator>();
        voice = hero.GetComponent<Stats>();
	}
    private void Update()
    {
        if( hero.GetComponent<Stats>().block==false)
            if (hero.GetComponent<Stats>().died == false)
                if (flag)
                {
                    animator.SetInteger("What_to_do", 1);
                    hero.transform.localScale = (new Vector3(-1, 1, 1));
                    if (move.position.x>=voice.left_border)
                    move.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                    voice.SendMessage("Movement");
                }
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (hero.GetComponent<Stats>().died == false)
            flag = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
            flag = false;
            voice.SendMessage("Stop_move");
            animator.SetInteger("What_to_do", 0);
        
    }
}
