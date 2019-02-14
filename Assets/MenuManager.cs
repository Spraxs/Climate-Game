using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject deathMenu;

    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private GameObject introMenu;

    [SerializeField]
    private GameObject baseMenu;

    [SerializeField]
    private GameObject uIElements;

    private MenuType openMenu;

    private InputController inputController;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        inputController = FindObjectOfType<InputController>();

        inputController.buttonInputAction += ButtonInput;
    }

    void Start()
    {

        openMenu = MenuType.INTRO;
        baseMenu.SetActive(true);
        introMenu.SetActive(true);

    }

    public void ShowMenu(MenuType menuType)
    {
        openMenu = menuType;

        if (baseMenu.activeSelf) baseMenu.SetActive(false);
        if (deathMenu.activeSelf) deathMenu.SetActive(false);
        if (winMenu.activeSelf) winMenu.SetActive(false);
        if (introMenu.activeSelf) introMenu.SetActive(false);

        if (openMenu != MenuType.NONE) {
            baseMenu.SetActive(true);
            uIElements.SetActive(false);
        }

        switch (menuType)
        {
            case MenuType.INTRO:
                introMenu.SetActive(true);
                break;

            case MenuType.WIN:
                winMenu.SetActive(true);
                break;

            case MenuType.LOSE:
                deathMenu.SetActive(true);
                break;
        }
    }

    private void ButtonInput(InputController.ButtonInput buttonInput)
    {
        if (openMenu == MenuType.NONE) return;

        if (openMenu == MenuType.INTRO)
        {
            ShowMenu(MenuType.NONE);
            uIElements.SetActive(true);
            gameManager.StartGame();
            return;
        }

        gameManager.RestartGame();
    }

    public enum MenuType
    {
        WIN, LOSE, INTRO, NONE
    }
}
