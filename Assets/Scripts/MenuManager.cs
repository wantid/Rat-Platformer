using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject SkinMenu;
    public GameObject MainMenu;
    public GameObject AboutMenu;

    public static MenuManager instance;

    public void Start()
    {
        instance = this;
    }

    public void Restart()
    {
        GameManager.Restart();
    }

    public void GoToMenu()
    {
        OpenMenu(MenuType.main);
    }

    public void ChangeSkin()
    {
        OpenMenu(MenuType.skin);
    }

    public void About()
    {
        OpenMenu(MenuType.about);
    }

    public void OpenMenu(MenuType menu)
    {
        switch (menu)
        {
            case MenuType.about:
                SkinMenu.SetActive(false);
                MainMenu.SetActive(false);
                AboutMenu.SetActive(true);
                break;
            case MenuType.skin:
                MainMenu.SetActive(false);
                AboutMenu.SetActive(false);
                SkinMenu.SetActive(true);
                break;
            case MenuType.main:
                SkinMenu.SetActive(false);
                AboutMenu.SetActive(false);
                MainMenu.SetActive(true);
                break;
            case MenuType.close:
                SkinMenu.SetActive(false);
                MainMenu.SetActive(false);
                AboutMenu.SetActive(false);
                break;
        }
    }
}

public enum MenuType
{
    skin,
    main,
    about,
    close
}


