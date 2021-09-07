using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    public GameObject[] balls;

    public int BallRemain;

    public int remain
    {
        get
        {
            return BallRemain;
        }
        set
        {
            BallRemain = value;
            for (int i = 0; i < 8; i++)
            {
                if (i < BallRemain)
                    balls[i].SetActive(true);
                else
                    balls[i].SetActive(false);
            }
        }
    }

 


    
}
