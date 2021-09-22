using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Text levelText;
    public Image Lock;
    public Image star1;
    public Image star2;
    public Image star3;
    public int leve;

    public Button button; 
    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnEnable()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (leve > PlayerPrefs.GetInt("MaxLevel"))
        {
            levelText.gameObject.SetActive(false);
            Lock.gameObject.SetActive(true);
            return;
        }

        levelText.text = leve.ToString();
        int sr = PlayerPrefs.GetInt("Level" + leve.ToString());
        if (sr >= 1)
            star1.gameObject.SetActive(true);
        if (sr >= 2)
            star2.gameObject.SetActive(true);
        if (sr >= 3)
            star3.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        if (leve > PlayerPrefs.GetInt("MaxLevel"))
            return;
        GameManager.Instance.level = leve;
        GameManager.Instance.SceneLoading("PlayScene", 0.5f);
    }
}
