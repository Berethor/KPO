using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
    public int sound=1;
    public int check_point;
    public int progress;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);       
	}
	
	void Sound_change()
    {
        if (sound == 1)
            sound = 0;
        else
            sound = 1;
    }
}
