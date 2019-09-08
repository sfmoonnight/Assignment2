using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = System.Math.Round(Time.time - gameManager.GetStartTime(), 2).ToString();
    }
}
