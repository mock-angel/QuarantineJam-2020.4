using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanves : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseBtn;
    //[SerializeField] private GameObject pauseImg;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private AudioManager audioManager;


    private Image pauseBtnImg;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseBtnImg = pauseBtn.GetComponent<Image>();
    }

    public void ChangePauseState()
    {
        if (Time.timeScale == 1)
        {
            //pauseImg.SetActive(true);
            pauseBtnImg.sprite = playSprite;
            startMenu.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            //pauseImg.SetActive(false);
            pauseBtnImg.sprite = pauseSprite;
            startMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ChangeMusicState()
    {
        audioManager.UpdateMusicState();
    }

    public void Exit()
    {
        Application.Quit();
        print("Quit");
    }
}
