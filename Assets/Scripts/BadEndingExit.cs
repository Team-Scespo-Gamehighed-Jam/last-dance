using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BadEndingExit : MonoBehaviour
{
    public Button ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        Button exitButton = ExitButton.GetComponent<Button>();
        exitButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
