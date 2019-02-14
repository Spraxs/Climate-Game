using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fakeGame;

    [SerializeField]
    private GameObject game;

    private GameObject circleSpawner;

    private MenuManager menuManager;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();

        fakeGame.SetActive(true);
    }

    public void StartGame()
    {
        circleSpawner = FindObjectOfType<CircleSpawner>().gameObject;

        fakeGame.SetActive(false);
        circleSpawner.SetActive(true);
        game.SetActive(true);
    }

    public void EndGame(MenuManager.MenuType menuType)
    {
        fakeGame.SetActive(true);

        Destroy(game);

        menuManager.ShowMenu(menuType);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
