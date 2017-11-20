using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {
    SaveFiles saveFiles;
	// Use this for initialization
	void Start () {
        saveFiles = GameObject.Find("SaveFiles").GetComponent<SaveFiles>();
        GameObject.Find("Money Count").GetComponent<Text>().text = "У вас "+saveFiles.money+" золотых монет";
        lives();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void LevelChoise()
    {
        SceneManager.LoadScene("LevelChoise");
    }
    void Arsenal()
    {
        SceneManager.LoadScene("Arsenal");
    }
    void Level1()
    {
        SceneManager.LoadScene("lvl1");
    }
    void Level2()
    {
        SceneManager.LoadScene("lvl2");
    }
    void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }
    void Level4()
    {
        SceneManager.LoadScene("lvl4");
    }
    void lives()
    {
        if (saveFiles.lives == 1)
            GameObject.Find("Live Count").GetComponent<Text>().text = "У вас " + saveFiles.lives + " жизнь";
        if (saveFiles.lives == 2 || saveFiles.lives == 3)
            GameObject.Find("Live Count").GetComponent<Text>().text = "У вас " + saveFiles.lives + " жизни";
        if (saveFiles.lives > 3)
            GameObject.Find("Live Count").GetComponent<Text>().text = "У вас " + saveFiles.lives + " жизней";
    }
}
