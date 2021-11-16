using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] private GameObject caixaDialogo;
    [SerializeField] private TMP_Text textLabel;
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
        caixaDialogo.SetActive(true);
        StartCoroutine(PassarDialogo(dialigoObjeto));
    }

    private IEnumerator PassarDialogo(DialogoObejto dialogoObjeto)
    {
        foreach (string dialogo in dialogoObjeto.Dialogo)
        {
            yield return efeitoTypewriter.Run(dialogo, textLabel, espaco);
            espaco.enabled = true;
            yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
            textLabel.text = string.Empty;
            espaco.enabled = false;
            //FindObjectOfType<AudioControl>().Play("ProximaFala");
        }

        FecharDialogo();
    }

    private void FecharDialogo()
    {
        dialogo = false;
        caixaDialogo.SetActive(false);
        textLabel.text = string.Empty;
    }
}
