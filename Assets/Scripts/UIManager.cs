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
    public Button ExitButton;
    
    void Start()
    {
        Button creditsButton = CreditsButton.GetComponent<Button>();
        creditsButton.onClick.AddListener(TaskOnClick);
        
        Button exitButton = ExitButton.GetComponent<Button>();
        exitButton.onClick.AddListener(ExitOnClick);
        
        CreditsText.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);

    }
    void TaskOnClick()
    {
        LastDance.gameObject.SetActive(false);
        BottomLine.gameObject.SetActive(false);
        CreditsText.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(true);
        
    }

    void ExitOnClick()
    {
        LastDance.gameObject.SetActive(true);
        BottomLine.gameObject.SetActive(true);
        CreditsText.gameObject.SetActive(false);
        PlayButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(false);
    }
}
