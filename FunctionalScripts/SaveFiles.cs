using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveFiles : MonoBehaviour {
    public string NameofSlot;//название сейва
    public int Levels;//кол-во открытых уровней
    public int head;//открытые шлема
    public int body;//открытые нагрудники
    public int shield;//открытые щиты
    public int weapon;//открытые оружия
    public int money;//деньги 
    public int lives;//жизни
    public int savenum;
    GameObject field1;
    GameObject field2;
    GameObject field3;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        field1 = GameObject.Find("InputField1");
        field2 = GameObject.Find("InputField2");
        field3 = GameObject.Find("InputField3");
        if (PlayerPrefs.HasKey("Nameof1Slot"))
        {
            GameObject.Find("Save1Text").GetComponent<Text>().text = PlayerPrefs.GetString("Nameof1Slot");
            field1.SetActive(false);
        }        
        if (PlayerPrefs.HasKey("Nameof2Slot"))
        {
            GameObject.Find("Save2Text").GetComponent<Text>().text = PlayerPrefs.GetString("Nameof2Slot");
            field2.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Nameof3Slot"))
        {
            GameObject.Find("Save3Text").GetComponent<Text>().text = PlayerPrefs.GetString("Nameof3Slot");
            field3.SetActive(false);
        }
    }
    public void Save1(int levelfinished,int lives,int head,int body,int shield,int weapon,int money)
    {
        PlayerPrefs.SetInt("Levels1", levelfinished);
        PlayerPrefs.SetInt("lives1", lives);
        PlayerPrefs.SetInt("head1", head);
        PlayerPrefs.SetInt("body1", body);
        PlayerPrefs.SetInt("shield1", shield);
        PlayerPrefs.SetInt("weapon1", weapon);
        PlayerPrefs.SetInt("money1", money);
        Set1();
        PlayerPrefs.Save();
    }
    public void Save2(int levelfinished, int lives, int head, int body, int shield, int weapon, int money)
    {
        PlayerPrefs.SetInt("Levels2", levelfinished);
        PlayerPrefs.SetInt("lives2", lives);
        PlayerPrefs.SetInt("head2", head);
        PlayerPrefs.SetInt("body2", body);
        PlayerPrefs.SetInt("shield2", shield);
        PlayerPrefs.SetInt("weapon2", weapon);
        PlayerPrefs.SetInt("money2", money);
        Set2();
        PlayerPrefs.Save();
    }
    public void Save3(int levelfinished, int lives, int head, int body, int shield, int weapon, int money)
    {
        PlayerPrefs.SetInt("Levels3", levelfinished);
        PlayerPrefs.SetInt("lives3", lives);
        PlayerPrefs.SetInt("head3", head);
        PlayerPrefs.SetInt("body3", body);
        PlayerPrefs.SetInt("shield3", shield);
        PlayerPrefs.SetInt("weapon3", weapon);
        PlayerPrefs.SetInt("money3", money);
        Set3();
        PlayerPrefs.Save();
    }
    void Load1()
    {
        if (!PlayerPrefs.HasKey("Nameof1Slot"))
            if (GameObject.Find("InputField1").GetComponent<InputField>().text != "Имя сейва")
            {
                NameofSlot = GameObject.Find("InputField1").GetComponent<InputField>().text;
                PlayerPrefs.SetString("Nameof1Slot", NameofSlot);
                PlayerPrefs.Save();
                Save1(1, 3, 1, 1, 1, 1, 0);
            }

        if(PlayerPrefs.HasKey("Nameof1Slot"))
        {
            Set1();
            SceneManager.LoadScene("Main Menu");
        }

    }
    void Load2()
    {

        if (!PlayerPrefs.HasKey("Nameof2Slot"))
            if (GameObject.Find("InputField2").GetComponent<InputField>().text != "Имя сейва")
            {
                NameofSlot = GameObject.Find("InputField2").GetComponent<InputField>().text;
                PlayerPrefs.SetString("Nameof2Slot", NameofSlot);
                PlayerPrefs.Save();
                Save2(1, 5, 1, 1, 1, 1, 10);
            }
        if (PlayerPrefs.HasKey("Nameof2Slot"))
        {
            Set2();
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Load3()
    {

        if (!PlayerPrefs.HasKey("Nameof3Slot"))
            if (GameObject.Find("InputField3").GetComponent<InputField>().text != "Имя сейва")
            {
                NameofSlot = GameObject.Find("InputField3").GetComponent<InputField>().text;
                PlayerPrefs.SetString("Nameof3Slot", NameofSlot);
                PlayerPrefs.Save();
                Save3(1, 1, 1, 1, 1, 1, 20);
            }
        if (PlayerPrefs.HasKey("Nameof3Slot"))
        {
            Set3();
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Delete1()
    {
        PlayerPrefs.DeleteKey("Nameof1Slot");
        PlayerPrefs.DeleteKey("Levels1");
        PlayerPrefs.DeleteKey("lives1");
        PlayerPrefs.DeleteKey("head1");
        PlayerPrefs.DeleteKey("body1");
        PlayerPrefs.DeleteKey("shield1");
        PlayerPrefs.DeleteKey("weapon1");
        PlayerPrefs.DeleteKey("money1");
        PlayerPrefs.Save();
        GameObject.Find("Save1Text").GetComponent<Text>().text = "Пустое сохранение";
        field1.SetActive(true);
        Debug.Log("Deleted");
    }
    void Delete2()
    {
        PlayerPrefs.DeleteKey("Nameof2Slot");
        PlayerPrefs.DeleteKey("Levels2");
        PlayerPrefs.DeleteKey("lives2");
        PlayerPrefs.DeleteKey("head2");
        PlayerPrefs.DeleteKey("body2");
        PlayerPrefs.DeleteKey("shield2");
        PlayerPrefs.DeleteKey("weapon2");
        PlayerPrefs.DeleteKey("money2");
        PlayerPrefs.Save();
        GameObject.Find("Save2Text").GetComponent<Text>().text = "Пустое сохранение";
        field2.SetActive(true);
        Debug.Log("Deleted");
    }
    void Delete3()
    {

        PlayerPrefs.DeleteKey("Nameof3Slot");
        PlayerPrefs.DeleteKey("Levels3");
        PlayerPrefs.DeleteKey("lives3");
        PlayerPrefs.DeleteKey("head3");
        PlayerPrefs.DeleteKey("body3");
        PlayerPrefs.DeleteKey("shield3");
        PlayerPrefs.DeleteKey("weapon3");
        PlayerPrefs.DeleteKey("money3");
        PlayerPrefs.Save();
        GameObject.Find("Save3Text").GetComponent<Text>().text = "Пустое сохранение";
        field3.SetActive(true);
        Debug.Log("Deleted");
    }
    void Set1()
    {
        NameofSlot = PlayerPrefs.GetString("Nameof1Slot");
        Levels = PlayerPrefs.GetInt("Levels1");
        lives = PlayerPrefs.GetInt("lives1");
        head = PlayerPrefs.GetInt("head1");
        body = PlayerPrefs.GetInt("body1");
        shield = PlayerPrefs.GetInt("shield1");
        weapon = PlayerPrefs.GetInt("weapon1");
        money = PlayerPrefs.GetInt("money1");
        savenum = 1;
    }
    void Set2()
    {
        NameofSlot = PlayerPrefs.GetString("Nameof2Slot");
        Levels = PlayerPrefs.GetInt("Levels2");
        lives = PlayerPrefs.GetInt("lives2");
        head = PlayerPrefs.GetInt("head2");
        body = PlayerPrefs.GetInt("body2");
        shield = PlayerPrefs.GetInt("shield2");
        weapon = PlayerPrefs.GetInt("weapon2");
        money = PlayerPrefs.GetInt("money2");
        savenum = 2;
    }
    void Set3()
    {
        NameofSlot = PlayerPrefs.GetString("Nameof3Slot");
        Levels = PlayerPrefs.GetInt("Levels3");
        lives = PlayerPrefs.GetInt("lives3");
        head = PlayerPrefs.GetInt("head3");
        body = PlayerPrefs.GetInt("body3");
        shield = PlayerPrefs.GetInt("shield3");
        weapon = PlayerPrefs.GetInt("weapon3");
        money = PlayerPrefs.GetInt("money3");
        savenum = 3;
    }
}
