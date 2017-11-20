using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSceneToMaimMenu : MonoBehaviour {
    SaveFiles saveFiles;
    int money;
	void GoBack()
    {
        saveFiles = GameObject.Find("SaveFiles").GetComponent<SaveFiles>();
        if (saveFiles.money > 30)
            money = saveFiles.money - 30;
        else
            money = 0;
        if( saveFiles.savenum==1)
        {
            saveFiles.Save1(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, money);
        }
        if (saveFiles.savenum == 2)
        {
            saveFiles.Save2(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, money);
        }
        if (saveFiles.savenum == 3)
        {
            saveFiles.Save3(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, money);
        }
        SceneManager.LoadScene("Main Menu");
    }
    void GoBackWin()
    {

        saveFiles = GameObject.Find("SaveFiles").GetComponent<SaveFiles>();
        if (saveFiles.savenum == 1)
        {
            saveFiles.Save1(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, saveFiles.money);
        }
        if (saveFiles.savenum == 2)
        {
            saveFiles.Save2(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, saveFiles.money);
        }
        if (saveFiles.savenum == 3)
        {
            saveFiles.Save3(saveFiles.Levels, 3, saveFiles.head, saveFiles.body, saveFiles.shield, saveFiles.weapon, saveFiles.money);
        }
        SceneManager.LoadScene("Main Menu");
    }

}
