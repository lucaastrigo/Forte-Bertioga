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

    public bool dialogo;
    public Image espaco;
    void Start()
    {
        efeitoTypewriter = GetComponent<EfeitoTypewriter>();
        FecharDialogo();
    }

    public void MostrarDialogo(DialogoObejto dialigoObjeto)
    {
        dialogo = true;

        if (caixaDialogo.activeSelf == false)
        {
            caixaDialogo.SetActive(true);
        }

        StartCoroutine(PassarDialogo(dialigoObjeto));
    }

    private IEnumerator PassarDialogo(DialogoObejto dialogoObjeto)
    {
        foreach (string dialogo in dialogoObjeto.Dialogo)
        {
            yield return efeitoTypewriter.Run(dialogo, textLabel, espaco);
            espaco.enabled = true;
            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space) || caixaDialogo.GetComponent<DialogBox>().clicked);
            yield return new WaitForSeconds(0.1f);
            caixaDialogo.GetComponent<DialogBox>().clicked = false;
            //textLabel.text = string.Empty;
            //FindObjectOfType<AudioControl>().Play("ProximaFala");
        }

        FecharDialogo();
    }  



    public void MostrarDialogoCutscene(DialogoCutscene dialigoObjeto)
    {
        dialogo = true;
        caixaDialogo.SetActive(true);
        StartCoroutine(PassarDialogoCutscene(dialigoObjeto));
    }

    private IEnumerator PassarDialogoCutscene(DialogoCutscene dialogoObjeto)
    {
        for (int i = 0; i < dialogoObjeto.Strings.Count; i++)
        {
            if (dialogoObjeto.Strings[i].audioString != null)
            {
                audioSource.PlayOneShot(dialogoObjeto.Strings[i].audioString);
            }

            yield return efeitoTypewriter.Run(dialogoObjeto.Strings[i].falas, textLabel, espaco);

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

    IEnumerator Finito()
    {
        yield return new WaitForSeconds(0.5f);

        dialogo = false;
    }
}
