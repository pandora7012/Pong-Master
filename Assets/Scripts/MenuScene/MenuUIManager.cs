using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuUIManager : MonoBehaviour
{
    public Text LevelText;


    private void Start()
    {
        LevelText.text  = "Level " + PlayerPrefs.GetInt("MaxLevel").ToString();
    }

    public void PlayButton()
    {
        GameManager.Instance.level = 1;
        GameManager.Instance.SceneLoading("PlayScene", 1f);
    }
}
