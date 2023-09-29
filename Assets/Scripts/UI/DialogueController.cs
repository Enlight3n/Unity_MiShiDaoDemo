using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue_SO dialogueSoEmpty;
    public Dialogue_SO dialogueSoFull;

    private Stack<string> _dialogueEmptyStack;
    
    private Stack<string> _dialogueFullStack;

    private bool _isTaking;


    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()
    {
        _dialogueEmptyStack = new Stack<string>();

        _dialogueFullStack = new Stack<string>();

        for (int i = dialogueSoEmpty.dialogueList.Count - 1; i > -1; i--)
        {
            _dialogueEmptyStack.Push(dialogueSoEmpty.dialogueList[i]);
        }
        for (int i = dialogueSoFull.dialogueList.Count - 1; i > -1; i--)
        {
            _dialogueFullStack.Push(dialogueSoFull.dialogueList[i]);
        }
    }

    public void ShowDialogueEmpty()
    {
        if (!_isTaking)
        {
            StartCoroutine(DialogueRoutine(_dialogueEmptyStack));
        }
    }

    public void ShowDialogueFull()
    {
        if (!_isTaking)
        {
            StartCoroutine(DialogueRoutine(_dialogueFullStack));
        }
    }

    private IEnumerator DialogueRoutine(Stack<string> data)
    {
        _isTaking = true;
        
        if (data.TryPop(out string result))
        {
            EventHandler.CallShowDialogueEvent(result);
            yield return null;
            EventHandler.CallGameStaeChangeEvent(GameStateEnum.Pause);
        }

        else
        {
            EventHandler.CallShowDialogueEvent(string.Empty);
            FillDialogueStack();
            EventHandler.CallGameStaeChangeEvent(GameStateEnum.GamePlay);
        }
        
        _isTaking = false;
    }
    
}
