using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int coin;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        coin = PlayerPrefs.GetInt("coin");
    }

    public static void SaveAll()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.Save();
    }

    public static void GameOver()
    {
        SaveAll();
        MenuManager.instance.OpenMenu(MenuType.main);
    }

    public static void Restart()
    {
        SaveAll();
        MenuManager.instance.OpenMenu(MenuType.close);
        SceneManager.LoadScene(0);
    }
}
