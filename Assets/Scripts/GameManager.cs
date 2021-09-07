using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public  List<GameObject> BallPolling;

    [Header("Level Infomacion")]
    public int numOfBall;
    public int numOfTarget;
    public Vector2 startPos;
    public int level;
    public GameObject currentLevel;

    [Header("PoolingSystem")]
    public GameObject ballPrefabs;


    public int ballnum
    {
        get
        {
            return numOfBall;
        }
        set
        {
            numOfBall = value;
            if (numOfBall < 0)
                return;
            transform.DOScale(Vector3.one, 1).OnComplete(() =>
            {
                BallPolling[numOfBall].SetActive(true);
            }
            ); 
            
        }
    }


    protected override void Awake()
    {
        base.Awake();
        BallPolling = new List<GameObject>(); 
        PollingSystem();
        SceneLoading("MainMenu", 6);
        if (PlayerPrefs.GetInt("MaxLevel") == 0)
            PlayerPrefs.SetInt("MaxLevel", 1);
        
    }

    public void LoadLevel()
    {
        GameObject levelPrefab = Resources.Load("Level" + level.ToString()) as GameObject;
        if (levelPrefab == null)
            return;
        GetLevelInfo(levelPrefab);
        currentLevel = Instantiate(levelPrefab);
        
    }

    private void GetLevelInfo(GameObject level_)
    {
        LevelInfomacion levelInfomacion = level_.GetComponent<LevelInfomacion>();
        this.numOfBall = levelInfomacion.numOfball;
        this.numOfTarget = levelInfomacion.numOfTarget;
        this.startPos = levelInfomacion.ballStartPos;
    }

    private void PollingSystem()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject ball = Instantiate(ballPrefabs, transform);
           
            ball.SetActive(false);
            BallPolling.Add(ball);
        }
    }

    public void SceneLoading(string scene, float timeWait)
    {
        StartCoroutine(SceneWait(scene,timeWait));
    }

    private IEnumerator SceneWait(string scene, float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        SceneManager.LoadScene(scene);
    }



}
