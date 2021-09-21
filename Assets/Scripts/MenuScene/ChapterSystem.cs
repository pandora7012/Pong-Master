using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSystem : MonoBehaviour
{

    public List<RectTransform> ChapContent;
    public LevelButton levelBt;

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
}
