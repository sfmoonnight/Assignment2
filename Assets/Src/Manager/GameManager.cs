using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager GetGameManager()
    {
        if (GameManager._instance == null)
        {
            var go = new GameObject("GameManager");
            DontDestroyOnLoad(go);
            GameManager._instance = go.AddComponent<GameManager>();
        }
        return GameManager._instance;
    }

    public GameObject player;

    public float startTime = 0;
    public float endTime = Mathf.Infinity;
    public int moves;
    public int deaths;
    public float score;
    public int currentSceneIndex;

    private string path;

    // Start is called before the first frame update
    void Start()
    {
        moves = 0;
        deaths = 0;
        score = 0;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        path = Application.dataPath + "/TopRecord.txt";
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPlayer();
    }

    /*public void CheckPlayer()
    {
        if (Player.GetPlayer())
        {
            return;
        }
        else
        {
            ReloadScene();
        }
    }*/

    /*public void ReloadScene()
    {
        if(currentSceneIndex >= 0)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }*/

    public void LoadNextLevel()
    {
        if (currentSceneIndex >= 0)
        {
            if(currentSceneIndex == 4)
            {
                SetEndTime();
            }
            currentSceneIndex += 1;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void RespawnPlayer()
    {
        Instantiate(player, new Vector3(0, 2, -8), Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        moves = 0;
        deaths = 0;
        score = 0;
        currentSceneIndex = 0;
    }

    public void CountDeath()
    {
        deaths += 1;
    }

    public void CountMove()
    {
        moves += 1;
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    public void SetStartTime()
    {
        startTime = Time.time;
    }

    public void SetEndTime()
    {
        endTime = Time.time;
    }

    public float GetStartTime()
    {
        return startTime;
    }

    public float GetEndTime()
    {
        return endTime;
    }

    public float GetScore()
    {
        return score;
    }

    public float GetMoves()
    {
        return moves;
    }

    public float GetDeaths()
    {
        return deaths;
    }

    public float ReadRecord()
    {
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            //Debug.Log(reader.ReadLine());
            float num = float.Parse(reader.ReadLine());
            reader.Close();

            //Debug.Log(num);
            return num;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();
            WriteRecord(99999999);
            return 99999999;
        }     
    }

    public void WriteRecord(double newRecord)
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(newRecord);
        writer.Close();
    }
}
