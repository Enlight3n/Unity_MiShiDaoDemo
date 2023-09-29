using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : SingletonMonobehaviour<TeleportManager>
{
    public Canvas canvas;

    private CanvasGroup _canvasGroup;
    
    private bool _isFade;

    private bool _canTeleport;

    private void OnEnable()
    {
        EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
    }

    private void OnGameStateChangeEvent(GameStateEnum gameState)
    {
        _canTeleport = gameState == GameStateEnum.GamePlay;
    }

    private void Start()
    {
        _isFade = false;
        _canvasGroup = canvas.GetComponentInChildren<CanvasGroup>();
    }

    public void Transition(ScenesEnum startScene, ScenesEnum destination)
    {
        if (!_isFade && _canTeleport)
        {
            StartCoroutine(SceneChange(startScene, destination));
        }
    }
    private IEnumerator SceneChange(ScenesEnum startScene,ScenesEnum destination)
    {
        yield return Fade(1);
        
        EventHandler.CallBeforeSceneUnLoadEvent();
        
        yield return SceneManager.UnloadSceneAsync((int)startScene);
        yield return SceneManager.LoadSceneAsync((int)destination, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        
        EventHandler.CallAfterSceneLoadedEvent();
        
        yield return Fade(0);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        _isFade = true;
        
        _canvasGroup.interactable = true;

        //这里的0.3f是持续时间
        float speed = Mathf.Abs(_canvasGroup.alpha - targetAlpha) / 0.3f;

        while (!Mathf.Approximately(_canvasGroup.alpha, targetAlpha))
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        
        _canvasGroup.interactable = false;
        
        _isFade = false;
    }
}
