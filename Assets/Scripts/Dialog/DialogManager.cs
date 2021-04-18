using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {
        public static DialogManager instance;

        [SerializeField] private GameObject dialogBox;
        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private int lettersPerSecond;

        [SerializeField] private Dialog _dialog;
        private int counter=0;

        private void Awake()
        {
            if (instance==null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            if (_dialog.Lines.Count <= 0)
            {
                dialogBox.SetActive(false);
                return;
            }

            ShowDialog(_dialog);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (SceneManager.GetActiveScene().buildIndex==4) return;
            
            if (counter>=_dialog.Lines.Count-1)
            {
                dialogBox.SetActive(false);
                LevelLoader.intance.LoadNextLevel();
                return;
            }
            counter++;
            ShowDialog(_dialog);
        }

        public void ShowDialog(Dialog dialog)
        {
            
            StopAllCoroutines();
            dialogBox.SetActive(true);
            StartCoroutine(TypeDialog(dialog.Lines[counter]));
            
        }

        public IEnumerator TypeDialog(string dialog)
        {
            dialogText.text = "";
            foreach (var letter in dialog.ToCharArray())
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(1f / lettersPerSecond);
            }

            yield return new WaitForSeconds(1);
            
        }
    }
}