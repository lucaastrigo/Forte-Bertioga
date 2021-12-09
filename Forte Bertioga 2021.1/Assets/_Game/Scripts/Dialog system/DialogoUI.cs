using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoUI : MonoBehaviour
{
    StoryBoard storyBoard => FindObjectOfType<StoryBoard>();
    public GameObject caixaDialogo;
    [SerializeField] private TMP_Text textLabel;
    public AudioSource audioSource;
    //[SerializeField] private DialogoObejto testeDialogo;

    private EfeitoTypewriter efeitoTypewriter;
    public DialogoObejto m_dialogoObjeto;

    public bool dialogo;
    public Image espaco;
    void Start()
    {
        efeitoTypewriter = GetComponent<EfeitoTypewriter>();
        FecharDialogo();
    }

    public void MostrarDialogo(DialogoObejto dialigoObjeto, string nomiJogador)
    {
        dialogo = true;

        if (caixaDialogo.activeSelf == false)
        {
            caixaDialogo.SetActive(true);
        }

        StartCoroutine(PassarDialogo(dialigoObjeto, nomiJogador));
    }
    private IEnumerator PassarDialogo(DialogoObejto dialogoObjeto, string nomeJogador)
    {
        m_dialogoObjeto = dialogoObjeto;
        foreach (string dialogo in dialogoObjeto.Dialogo)
        {

            string output = dialogo.Replace("nickname", nomeJogador);

            yield return efeitoTypewriter.Run(output, textLabel, espaco);

            espaco.enabled = true;
            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
            yield return new WaitForSeconds(0.1f);
            caixaDialogo.GetComponent<DialogBox>().clicked = false;
            //textLabel.text = string.Empty;
            //FindObjectOfType<AudioControl>().Play("ProximaFala");
        }

        FecharDialogo();
    }  



    public void MostrarDialogoCutscene(DialogoCutscene dialigoObjeto, string nomiJogador)
    {
        dialogo = true;
        caixaDialogo.SetActive(true);
        StartCoroutine(PassarDialogoCutscene(dialigoObjeto, nomiJogador));
    }

    private IEnumerator PassarDialogoCutscene(DialogoCutscene dialogoObjeto, string nomeJogador)
    {
        for (int i = 0; i < dialogoObjeto.Strings.Count; i++)
        {
            if (dialogoObjeto.Strings[i].audioString != null)
            {
                audioSource.PlayOneShot(dialogoObjeto.Strings[i].audioString);
            }

            string output = dialogoObjeto.Strings[i].falas.Replace("nickname", nomeJogador);

            yield return efeitoTypewriter.Run(output, textLabel, espaco);

            espaco.enabled = true;

            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space));

            if(dialogoObjeto.Strings[i].passaDialogo)
            {
                storyBoard.NextItem();
            }
        }

        FecharDialogo();
    }

    public void FecharDialogo()
    {

        if (caixaDialogo.activeSelf == true)
        {
            caixaDialogo.SetActive(false);
        }

        textLabel.text = string.Empty;

        StartCoroutine(Finito());
    } 
    public void FecharDialogo2()
    {
        //StartCoroutine(PassarDialogo(m_dialogoObjeto, null));

        //foreach (string dialogo in m_dialogoObjeto.Dialogo)
        //{
        //    print("oioio");
        //}

        //FecharDialogo();


        ////if (caixaDialogo.activeSelf == true)
        ////{
        ////    caixaDialogo.SetActive(false);
        ////}

        ////textLabel.text = string.Empty;

        ////StartCoroutine(Finito());

    }

    IEnumerator Finito()
    {
        yield return new WaitForSeconds(0.5f);

        dialogo = false;
    }
}
