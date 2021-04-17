using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PlayButton;
    public Button CreditsButton;
    public TMP_Text CreditsText;
    public TMP_Text LastDance;
    public Image BottomLine;
    
    void Start()
    {
        Button creditsButton = CreditsButton.GetComponent<Button>();
        creditsButton.onClick.AddListener(TaskOnClick);
        
        Button playButton = PlayButton.GetComponent<Button>();
        playButton.onClick.AddListener(PlayGameSceneManager);
        
        CreditsText.gameObject.SetActive(false);

    }
    void PlayGameSceneManager()
    {
        Debug.Log("Burdan başlıcak. Tek sahnede nasıl yapıcaz? :D");
    }
    void TaskOnClick()
    {
        LastDance.gameObject.SetActive(false);
        BottomLine.gameObject.SetActive(false);
        CreditsText.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(false);
    }
}
