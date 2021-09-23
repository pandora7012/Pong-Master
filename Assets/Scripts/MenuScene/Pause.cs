using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public Sprite musicOn;
    public Sprite musicOff;
    public Sprite VFSOn;
    public Sprite VFSOff;

    public Image music;
    public Image vfx; 
    private void OnEnable()
    {
        UIUpdate();
    }

    public void VFXOnClick()
    {
        PlayerPrefs.SetInt("Vfx", PlayerPrefs.GetInt("Vfx") == 1 ? 0 : 1);
        UIUpdate();
    }

    public void MusicOnClick()
    {
        PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music") == 1 ? 0 : 1);
        UIUpdate();
        MusicUpdate();
    }

    private void UIUpdate()
    {
        music.sprite = PlayerPrefs.GetInt("Music") == 1 ? musicOn : musicOff;
        vfx.sprite = PlayerPrefs.GetInt("Vfx") == 1 ? VFSOn : VFSOff;
    }

    private void MusicUpdate()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
            AudioManager.Instance.Stop("Background");
        else
            AudioManager.Instance.Play("Background");
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
}
