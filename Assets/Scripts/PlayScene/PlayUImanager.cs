using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayUImanager : MonoBehaviour
{

    [Header("Asset")]
    public Sprite star; 

    [Header("InGameUI")]  
    public Text LevelText;
    public Text Target;
    public BallCounter counter;

    [Header("WinPopUp")]
    public RectTransform WinGamePopUp;
    public Image star1;
    public Image star2;
    public Image star3;
    private int firstNum;
    private int targetNum;
    public Text Textlevel;
   

    void Start()
    {
        counter.remain = GameManager.Instance.numOfBall;
        LevelText.text = "Level " + GameManager.Instance.level.ToString();
        firstNum = GameManager.Instance.numOfBall;
        targetNum = GameManager.Instance.numOfTarget;
        GameManager.Instance.LoadLevel();
    }

    private void Update()
    {
        InGameUI();
        WinHandle();
    }

    private void InGameUI()
    {
        Target.text = GameManager.Instance.numOfTarget.ToString();
        counter.remain = GameManager.Instance.numOfBall;
    }


    #region WinPopUp
    private void WinHandle()
    {
        if (Target.text == "0")
        {
            Textlevel.text = "Level " + GameManager.Instance.level.ToString();
            StarHandle();
            WinGamePopUp.gameObject.SetActive(true);
            Target.gameObject.SetActive(false);
            LevelText.gameObject.SetActive(false);
            counter.gameObject.SetActive(false);
        }
    }

    public void NextLevel()
    {
        GameManager.Instance.level++; 
        Destroy(GameManager.Instance.currentLevel);
        SceneManager.LoadScene("PlayScene");
      
    }

    public void Home()
    {
        Destroy(GameManager.Instance.currentLevel);
        SceneManager.LoadScene("MainMenu");
    }

    #endregion 
    private void StarHandle()
    {
        int remain = counter.remain;
        if (firstNum - remain - targetNum >= 2)
            star2.sprite = star;
        if (firstNum - remain - targetNum >= 1)
            star3.sprite = star; 
    }

    public void PauseButton()
    {

    }

    public void RestartButton()
    {

    }

    

    
}
