using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanves : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
//    [SerializeField] private GameObject pauseBtn;
    //[SerializeField] private GameObject pauseImg;
//    [SerializeField] private Sprite pauseSprite;
//    [SerializeField] private Sprite playSprite;
//    [SerializeField] private AudioManager audioManager;


//    private Image pauseBtnImg;
    
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    
    [SerializeField] private GameObject muteMusicButton;
    [SerializeField] private GameObject playMusicButton;
    
    private void Awake()
    {
        OnClickedPause();
    }

    // Start is called before the first frame update
//    void Start()
//    {
//        pauseBtnImg = pauseBtn.GetComponent<Image>();
//    }
    
    
    //Edit: Seperated pausing and resuming into two different functions.
//    public void ChangePauseState()
//    {
//        if (Time.timeScale == 1)
//        {
//            //pauseImg.SetActive(true);
//            pauseBtnImg.sprite = playSprite;
//            startMenu.SetActive(true);
//            Time.timeScale = 0;
//        }
//        else
//        {
//            //pauseImg.SetActive(false);
//            pauseBtnImg.sprite = pauseSprite;
//            startMenu.SetActive(false);
//            Time.timeScale = 1;
//        }
//    }

    public void OnClickedPause(){
        if (Time.timeScale != 1) return;
        
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        
        startMenu.SetActive(true);
        
        Time.timeScale = 0;
    }
    
    public void OnClickedResume(){
        if (Time.timeScale == 1) return;
        
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        
        startMenu.SetActive(false);
        
        Time.timeScale = 1;
    }
    
    public void OnClickedPlayMusicState()
    {
        muteMusicButton.SetActive(true);
        playMusicButton.SetActive(false);
        
        AudioManager.Instance.PlayMainMusic();
    }
    
    public void OnClickedMuteMusicState()
    {
        muteMusicButton.SetActive(false);
        playMusicButton.SetActive(true);
        
        AudioManager.Instance.MuteMainMusic();
    }

    public void Exit()
    {
        Application.Quit();
        print("Quit");
    }
}
