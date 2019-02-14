using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    private List<Fire> fireList = new List<Fire>();

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public Fire GetRandomFire()
    {
        if (fireList.Count == 0) return null;

        int size = fireList.Count;

        size -= 1;

        int index = Random.Range(0, size);

        return fireList[index];
    }

    public void AddFire(Fire fire)
    {
        fireList.Add(fire);
    }

    public void RemoveFire(Fire fire)
    {
        fireList.Remove(fire);

        if (fireList.Count == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameManager.EndGame(MenuManager.MenuType.WIN);
    }
}
