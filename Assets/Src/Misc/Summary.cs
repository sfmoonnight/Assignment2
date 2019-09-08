using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public Text time;
    public Text score;
    public Text moves;
    public Text deaths;
    public Text topRecord;
    public Text record;
    public Image ginSan;
    public Sprite sarcasm;
    public Sprite shock;

    private double totalTime;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        SetRecord();
        ShowResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowResult()
    {
        time.text = totalTime.ToString();
        score.text = gameManager.GetScore().ToString();
        moves.text = gameManager.GetMoves().ToString();
        deaths.text = gameManager.GetDeaths().ToString();
        topRecord.text = gameManager.ReadRecord().ToString();
    }

    void SetRecord()
    {
        totalTime = System.Math.Round(gameManager.GetEndTime() - gameManager.GetStartTime(), 2);
        ginSan.GetComponent<Image>().sprite = sarcasm;
        if (System.Math.Round(gameManager.ReadRecord()) > totalTime)
        {
            //print(totalTime);
            gameManager.WriteRecord(totalTime);
            record.text = "New Record!";
            ginSan.GetComponent<Image>().sprite = shock;
        }
    }
}
