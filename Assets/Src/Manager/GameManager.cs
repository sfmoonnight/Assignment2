using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
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
    public int death;
    public float score;
    public int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        moves = 0;
        death = 0;
        score = 0;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

    public void ReloadScene()
    {
        if(currentSceneIndex >= 0)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void LoadNextLevel()
    {
        if (currentSceneIndex >= 0)
        {
            currentSceneIndex += 1;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void RespawnPlayer()
    {
        Instantiate(player, new Vector3(0, 2, -8), Quaternion.identity);
    }

    public void CountDeath()
    {
        death += 1;
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

    
}
