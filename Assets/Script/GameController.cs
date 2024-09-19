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
            // Scrollbar'da bir deðiþiklik olduðunda VolumeChange fonksiyonunu çaðýr
            volumeScrollbar.onValueChanged.AddListener(VolumeChange);

            // Scrollbar'ýn baþlangýç deðerini ses seviyesine göre ayarlayalým
            volumeScrollbar.value = audioSource.volume;
        }
    }


    // VolumeChange, scrollbar'da deðiþiklik olunca çaðrýlýr
    public void VolumeChange(float value)
    {
        // AudioSource volume deðerini scrollbar'ýn deðerine eþitle
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
