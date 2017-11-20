using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandlerScript : MonoBehaviour,IPointerDownHandler {

	public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }
}
