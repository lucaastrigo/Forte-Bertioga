using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo/DialogoCutscene")]
public class DialogoCutscene : ScriptableObject
{
    public List<TextCutscene> Strings = new List<TextCutscene>();

    [System.Serializable]
    public class TextCutscene
    {
        public bool passaDialogo;
        [TextArea] public string falas;
        public AudioClip audioString;
    }
}
