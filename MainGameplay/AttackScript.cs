using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackScript : MonoBehaviour, IPointerDownHandler
{
    GameObject hero;
	void Start () {
        hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        if(hero.GetComponent<Stats>().died==false)
        hero.SendMessage("Attack");        
    }
}
