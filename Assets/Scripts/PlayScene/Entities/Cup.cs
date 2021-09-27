using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Sprite[] niceText;
    public ParticleSystem particle;

    private void Awake()
    {
        sprite.sprite = GameManager.Instance.storedata.cups[PlayerPrefs.GetInt("CupSkin")-1].icon; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            particle.Play();
        }
    }

}
