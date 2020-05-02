using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanves : MonoBehaviour
{
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pauseImg;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;

    private Image pauseBtnImg;
    // Start is called before the first frame update
    void Start()
    {
        pauseBtnImg = pauseBtn.GetComponent<Image>();
    }

    public void ChangePauseState()
    {
        if (Time.timeScale == 1)
        {
            pauseImg.SetActive(true);
            pauseBtnImg.sprite = playSprite;
            Time.timeScale = 0;
        }
        else
        {
            pauseImg.SetActive(false);
            pauseBtnImg.sprite = pauseSprite;
            Time.timeScale = 1;
        }
    }
}
