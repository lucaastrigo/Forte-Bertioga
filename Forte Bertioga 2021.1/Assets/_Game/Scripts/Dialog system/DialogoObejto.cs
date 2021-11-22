using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo/DialogoObjeto")]
public class DialogoObejto : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogo;

    public string[] Dialogo => dialogo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
