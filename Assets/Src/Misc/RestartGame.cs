using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        gameManager.Restart();
    }
}
