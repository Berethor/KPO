using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class СмертьЮнита : MonoBehaviour {
    AI_First_Try AI;
	// Use this for initialization
	void Start () {
        AI = gameObject.GetComponent<AI_First_Try>();
	}
	
	// Update is called once per frame
	void Update () {
		 if (AI.hp==0)
        {
            StartCoroutine(Win());
        }
	}
    public IEnumerator Win()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Win Scene");
    }
}
