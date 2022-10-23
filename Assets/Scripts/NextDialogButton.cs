using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myDialog;
    private int lineIndex = 0;
    public void nextLine(dialog dialog)
    {
        
        myDialog.text = dialog.lines[lineIndex++];
    }
}
