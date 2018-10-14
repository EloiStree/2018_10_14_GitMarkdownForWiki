using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ClipboardToInputField : MonoBehaviour {
    
    public string m_currentClipboard;
    public InputField m_inputField;
    
	
	void Update () {


        m_currentClipboard = Clipboard;
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V)) {
            if( EventSystem.current.currentSelectedGameObject==null)
                Push();
        }

    }
    public void Push() {

        m_currentClipboard = Clipboard;
        m_inputField.text = m_currentClipboard;
         
    }
    public static string Clipboard
    {
        get { return GUIUtility.systemCopyBuffer; }
        set { GUIUtility.systemCopyBuffer = value; }
    }

}
