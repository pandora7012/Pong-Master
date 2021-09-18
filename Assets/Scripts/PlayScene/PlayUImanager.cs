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
    public Text currentCoin;
    public float coin;
    float temp;
    int remain;

    [Header("Lose")]
    public RectTransform LosePopup;
    public bool LoseTrigger;

    private bool musicPlay; 

    void Start()
    {
        musicPlay = false;
        counter.remain = GameManager.Instance.numOfBall;
        LevelText.text = "Level " + GameManager.Instance.level.ToString();
        firstNum = GameManager.Instance.numOfBall;
        targetNum = GameManager.Instance.numOfTarget;
        GameManager.Instance.LoadLevel();
        LoseTrigger = false;
        coin = PlayerPrefs.GetInt("Coin");
        currentCoin.text = coin.ToString();
        temp =  coin + 20;
        remain  = counter.remain;
    }

    private void Update()
    {
        InGameUI();
        WinHandle();
        LoseHandle();
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
            if (!musicPlay)
            {
                musicPlay = true;
                AudioManager.Instance.Play("Win");
                
            }
            Textlevel.text = "Level " + GameManager.Instance.level.ToString();
            StarHandle();
            WinGamePopUp.gameObject.SetActive(true);
            Target.gameObject.SetActive(false);
            LevelText.gameObject.SetActive(false);
            counter.gameObject.SetActive(false);
            StartCoroutine("ieNum");
        }
    }

    public void NextLevel()
    {
        GameManager.Instance.level++; 
        Destroy(GameManager.Instance.currentLevel);
        SceneManager.LoadScene("PlayScene");
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 20);
        AudioManager.Instance.Play("Click");
      //  AudioManager.Instance.Play("Background");
    }

    public void Home()
    {
        AudioManager.Instance.Play("Click");
        Destroy(GameManager.Instance.currentLevel);
        GameManager.Instance.ResetPolling(); 
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 20);
       // AudioManager.Instance.Play("Background");
    }

    private IEnumerator ieNum()
    {
        yield return new WaitForSeconds(4);
        
        if (coin < temp)
        {
            AudioManager.Instance.Play("Coin");
            coin += Time.deltaTime*30;
            currentCoin.text = ((int)coin).ToString(); 
        }
        
    }

    #endregion


    #region Lose

    private void LoseHandle()
    {
        if (Target.text != "0" && counter.remain == 0)
        {
            StartCoroutine("countLose");
        }
        if (LoseTrigger)
            LosePopup.gameObject.SetActive(true);
        
    }

    private IEnumerator countLose()
    {
        yield return new WaitForSeconds(10);
        LoseTrigger = true;
        if (!musicPlay)
        {
            musicPlay = true;
            AudioManager.Instance.Play("Lose");
         //   AudioManager.Instance.Stop("Background");
        }
    }

    #endregion
    private void StarHandle()
    {
        
        if (firstNum - remain - targetNum >= 2)
            star2.sprite = star;
        if (firstNum - remain - targetNum >= 1)
            star3.sprite = star; 
    }

    public void RestartButton()
    {
        Destroy(GameManager.Instance.currentLevel);
        SceneManager.LoadScene("PlayScene");
        AudioManager.Instance.Play("Click");
        
    }

    

    
}
