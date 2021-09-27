using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class Star : MonoBehaviour
{
    public ParticleSystem par; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
            this.transform.parent.DOScale(Vector2.zero, 0.1f);
        par.Play();
    }
}
