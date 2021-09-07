using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayUImanager : MonoBehaviour
{

    public Text LevelText;
    public Text Target;
    public BallCounter counter;

    void Start()
    {
        GameManager.Instance.LoadLevel();
        counter.remain = GameManager.Instance.numOfBall;
        LevelText.text = "Level " + GameManager.Instance.level.ToString();
    }

    private void Update()
    {
        Target.text = GameManager.Instance.numOfTarget.ToString();
        counter.remain = GameManager.Instance.numOfBall;
    }

    public void PauseButton()
    {

    }
}
