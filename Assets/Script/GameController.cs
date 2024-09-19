using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public MonoBehaviour GameManager;
    public MonoBehaviour CameraMove;

    public AudioSource audioSource;
    public Scrollbar volumeScrollbar;

    private void Start()
    {
        volumeScrollbar.gameObject.SetActive(false);
        {
            // Scrollbar'da bir de�i�iklik oldu�unda VolumeChange fonksiyonunu �a��r
            volumeScrollbar.onValueChanged.AddListener(VolumeChange);

            // Scrollbar'�n ba�lang�� de�erini ses seviyesine g�re ayarlayal�m
            volumeScrollbar.value = audioSource.volume;
        }
    }


    // VolumeChange, scrollbar'da de�i�iklik olunca �a�r�l�r
    public void VolumeChange(float value)
    {
        // AudioSource volume de�erini scrollbar'�n de�erine e�itle
        audioSource.volume = value;

    }
    public void Controller()
    {
        if (GameManager.enabled)
        {
            GameManager.enabled = false;
            CameraMove.enabled = false;
            volumeScrollbar.gameObject.SetActive(true);
            Time.timeScale = 0f;  // Oyunu durdur
        }
        else
        {
            GameManager.enabled = true;
            CameraMove.enabled = true;
            volumeScrollbar.gameObject.SetActive(false);
            Time.timeScale = 1f;  // Oyunu durdur
        }
        
    }
}
