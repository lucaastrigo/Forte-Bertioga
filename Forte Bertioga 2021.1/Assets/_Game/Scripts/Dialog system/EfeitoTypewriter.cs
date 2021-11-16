using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EfeitoTypewriter : MonoBehaviour
{
    [SerializeField] private float velocidade = 50f;
    private bool toca = true;
    public AudioSource teclas;
    public bool toca1 = true;
    public AudioClip[] audiosTeclas;
    public Coroutine Run(string textToType, TMP_Text textLabel, Image bg)
    {
       return StartCoroutine(TypeText(textToType, textLabel, bg));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel, Image espaco)
    {
        yield return new WaitForSeconds(1);

        textLabel.text = string.Empty;
        espaco.enabled = true;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * velocidade;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);

            toca = true;
            if(toca1)
            {
                if (toca)
                {
                    toca1 = false;
                    //Invoke("EscrevendoSom", 0.17f);
                }
            }

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        toca = false;
        textLabel.text = textToType;
    }

    public void EscrevendoSom()
    {
        teclas.clip = audiosTeclas[Random.Range(0, audiosTeclas.Length)];
        teclas.volume = Random.Range(0.3f, 0.4f);
        teclas.pitch = Random.Range(0.9f, 1.0f);
        teclas.Play();
        toca1 = true;
    }
}
