using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader intance;

    [SerializeField] private TMP_Text _text;
    
    public Animator transition;
    [SerializeField] private int transitionTime;

    private void Awake()
    {
        if (intance==null)
        {
            intance = this;
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        _text.text = "";
        transition.enabled = true;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}