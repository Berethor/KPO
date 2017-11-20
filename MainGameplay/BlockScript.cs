using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockScript : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{

    GameObject hero;
    Stats stats;
    Animator animator;
    // Use this for initialization
    void Start () {
        hero = GameObject.Find("Hero");
        stats = hero.GetComponent<Stats>();
        animator = hero.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        stats.block = true;
        animator.SetInteger("What_to_do", 3);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        stats.block = false;
        animator.SetInteger("What_to_do", 0);
    }
}
