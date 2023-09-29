using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DialogueController))]
public class NPC_H2 : Interactive
{
    private DialogueController _dialogueController;

    private void Awake()
    {
        _dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if(isDone)
            _dialogueController.ShowDialogueFull();
        else
            _dialogueController.ShowDialogueEmpty();
    }
    
    protected override void OnClickedAction()
    {
        _dialogueController.ShowDialogueFull();
    }
}
