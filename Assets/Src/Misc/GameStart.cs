using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.GetGameManager();
    }

    public void StartGame()
    {
        gameManager.LoadNextLevel();
        gameManager.SetStartTime();
    }
}
