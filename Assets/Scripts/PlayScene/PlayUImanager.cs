using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayUImanager : MonoBehaviour
{

    [Header("Asset")]
    public Sprite star;
    public Sprite targetStar;

    [Header("InGameUI")]  
    public Text LevelText;
    public Text Target;
    public BallCounter counter;
    public Image kindTarget;

    [Header("WinPopUp")]
    public RectTransform WinGamePopUp;
    public Image star1;
    public Image star2;
    public Image star3;
    private int firstNum;
    public Text Textlevel;
    public Text currentCoin;
    public float coin;
    float temp;
    int remain;

    [Header("Lose")]
    public RectTransform LosePopup;
    public RectTransform pauseBT; 
    private bool musicPlay; 

    


    void Awake()
    {
        musicPlay = false;
        LevelText.text = "Level " + GameManager.Instance.level.ToString();
        GameManager.Instance.LoadLevel();
        firstNum = GameManager.Instance.numOfBall;
        coin = PlayerPrefs.GetInt("Coin");
        currentCoin.text = coin.ToString();
        temp =  coin + 20;
        remain  = counter.remain;
    }

    private void OnEnable()
    {
        GameMaster.NewTaskComplete += UIUpdate;
        GameMaster.Win += WinHandle;
        GameMaster.Lose += LoseHandle; 
    }

    private void OnDisable()
    {
        GameMaster.NewTaskComplete -= UIUpdate;
        GameMaster.Win -= WinHandle;
        GameMaster.Lose -= LoseHandle;
    }


    private void UIUpdate()
    {
        if (GameManager.Instance.isStar)
            kindTarget.sprite = targetStar;
        counter.remain = GameManager.Instance.numOfBall;
        remain = counter.remain;
        Target.text = GameManager.Instance.numOfTarget.ToString();
        counter.remain = GameManager.Instance.numOfBall;
    }
    
    

    #region WinPopUp
    private void WinHandle()
    {
        if (Target.text == "0")
        {
            GameManager.Instance.ResetPolling();
            GameMaster.Lose -= LoseHandle;
            if (!musicPlay)
            {
                musicPlay = true;
                AudioManager.Instance.PlayVfx("Win");
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
        AudioManager.Instance.PlayVfx("Click");
      //  AudioManager.Instance.Play("Background");
    }

    public void Home()
    {
        AudioManager.Instance.PlayVfx("Click");
        Destroy(GameManager.Instance.currentLevel);
        GameManager.Instance.ResetPolling(); 
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 20);
       // AudioManager.Instance.Play("Background");
    }

    private IEnumerator ieNum()
    {
        yield return new WaitForSeconds(4);
        
        while (coin < temp)
        {
            AudioManager.Instance.PlayVfx("Coin");
            coin += Time.deltaTime *30 ;
            currentCoin.text = ((int)coin).ToString();
            yield return null;
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
    }

    private IEnumerator countLose()
    {
        yield return new WaitForSeconds(4);
        if (!musicPlay)
        {
            musicPlay = true;
            AudioManager.Instance.PlayVfx("Lose");
            LosePopup.gameObject.SetActive(true);
        }
    }

    #endregion
    private void StarHandle()
    {
        int p = PlayerPrefs.GetInt("SumStar");
        int a = 3;
        if (1f * remain / firstNum <= 0.6)
        {
            star3.sprite = star;
            a--;
        }
        if (1f * remain / firstNum <= 0.3)
        {
            star2.sprite = star;
            a--;
        }
        PlayerPrefs.SetInt("SumStar", p + a);
        string s = "Level" + GameManager.Instance.level.ToString();

        if (PlayerPrefs.GetInt(s) < a)
            PlayerPrefs.SetInt(s, a);
    }

    public void RestartButton()
    {
        Destroy(GameManager.Instance.currentLevel);
        SceneManager.LoadScene("PlayScene");
        AudioManager.Instance.PlayVfx("Click");
    }


    #region Pause 
    public void PauseButton()
    {
        pauseBT.gameObject.SetActive(true);
        GameManager.Instance.stop = true; 
        StartCoroutine(wait());
    }

    public void ContinueBt()
    {
        Time.timeScale = 1;
        GameManager.Instance.stop = false;
        pauseBT.gameObject.SetActive(false);
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    #endregion

 


}
