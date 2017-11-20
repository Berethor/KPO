using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Стрелы : MonoBehaviour {
    public int dmg;
    public int Way;
    public bool active=true;
    public int speed;// направление движения
    Vector3 first_position;
    // Use this for initialization
    void Start () {
        first_position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(active)
        transform.position +=new Vector3(Way*speed* Time.deltaTime, 0, 0);
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Hero")
        {
            active = false;
            GameObject.Find("Hero").GetComponent<Stats>().SendMessage("RecieveDmG", dmg);
            transform.position = first_position;
            StartCoroutine(RespawnTrap());
        }
        if (collision.gameObject.tag=="Floor")
        {
            active = false;
            transform.position = first_position;
            StartCoroutine(RespawnTrap());
        }
    }
    public IEnumerator RespawnTrap()
    {
        yield return new WaitForSeconds(3);
        active = true;

    }
}
