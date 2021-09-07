using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Trajectory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points = new GameObject[15];
    [SerializeField]
    private GameObject pointPrefab;

    [SerializeField]
    private Ball ball;

    private void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
            points[i].transform.parent = this.transform; 
        }
    }

    private void Update()
    {
        OnHolding();
    }

    private void OnHolding()
    {
        if (!ball.holding)
            return;
        for (int i = 0; i < 15; i++)
        {
            Vector2 position = ball.transform.position;
            position.x += ball.direction.x * i*0.08f * 7;
            position.y += ball.direction.y * i*0.08f * 7 + 0.5f * Physics2D.gravity.y * i * i * 0.0064f ;
            points[i].transform.position = position;
            
        }
    }
}
