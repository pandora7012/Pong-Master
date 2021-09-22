using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSystem : MonoBehaviour
{

    public List<RectTransform> ChapContent;
    public List<RectTransform> Chapter;
    public LevelButton levelBt;
    public Image lockimg;
    public RectTransform nextBt;
    public RectTransform previousBut;
    public RectTransform backBT;
    public RectTransform main; 


    private void Start()
    {
        Init();
    }

    public void Init()
    { 
        for (int i = 1; i <= 12; i++)
        {
            LevelButton bt = Instantiate(levelBt, ChapContent[0]);
            bt.leve = i;
        }

        for (int i = 13; i<= 24; i++)
        {
            LevelButton bt = Instantiate(levelBt, ChapContent[1]);
            bt.leve = i;
        }
    }

    public void OnEnable()
    {
        if (PlayerPrefs.GetInt("MaxLevel") > 12)
            lockimg.gameObject.SetActive(false);
        
    }

    public void setAT1()
    {
        Chapter[0].gameObject.SetActive(false);
        Chapter[1].gameObject.SetActive(false);
        ChapContent[0].gameObject.SetActive(true);
        foreach( var i in Chapter)
        {
            i.gameObject.SetActive(false);
        }
        nextBt.gameObject.SetActive(true);
        backBT.gameObject.SetActive(true);
    }

    public void setAT2()
    {
        if (PlayerPrefs.GetInt("MaxLevel") < 12)
            return; 
        Chapter[0].gameObject.SetActive(false);
        Chapter[1].gameObject.SetActive(false);
        ChapContent[1].gameObject.SetActive(true);
        foreach (var i in Chapter)
            i.gameObject.SetActive(false);
        previousBut.gameObject.SetActive(true);
        backBT.gameObject.SetActive(true);
    }

    public void nextButton()
    {
        ChapContent[0].gameObject.SetActive(false);
        ChapContent[1].gameObject.SetActive(true);
        previousBut.gameObject.SetActive(true);
        nextBt.gameObject.SetActive(false);
    }

    public void previousButton()
    {
        ChapContent[0].gameObject.SetActive(true);
        ChapContent[1].gameObject.SetActive(false);
        previousBut.gameObject.SetActive(false);
        nextBt.gameObject.SetActive(true);
    }


    public void home()
    {
        this.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
    }

    public void back()
    {
        Chapter[0].gameObject.SetActive(true);
        Chapter[1].gameObject.SetActive(true);
        ChapContent[0].gameObject.SetActive(false);
        ChapContent[1].gameObject.SetActive(false);
        nextBt.gameObject.SetActive(false);
        previousBut.gameObject.SetActive(false);
        backBT.gameObject.SetActive(false);
    }

}
