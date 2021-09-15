using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogText;

    Queue<string> sentences;

    private void Awake()
    {
        sentences = new Queue<string>();
    }

    public void DialogStart(Dialog d)
    {
        nameText.text = d.name;

        Debug.Log(sentences.Count);

        sentences.Clear();

        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DialogNext();
    }

    public void DialogNext()
    {
        if(sentences.Count == 0)
        {
            DialogEnd();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    public void DialogEnd()
    {
        SceneManager.LoadScene("MovementPrototype");
    }
}
