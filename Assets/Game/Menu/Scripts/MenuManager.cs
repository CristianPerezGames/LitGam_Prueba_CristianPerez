using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance = null;

    public Action OnChangeAnimation; 

    [SerializeField] private PlayerScriptable playerScriptable; 

    [SerializeField] private FadeManager fadeManager;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SetAnimation(AnimationData _animationData){
        playerScriptable.SetAnimation(_animationData.name);

        NotifyChangeAnimation();
    }

    void NotifyChangeAnimation(){
        OnChangeAnimation?.Invoke();
    }

    public void OnSelect(){
        fadeManager.Fade(1,1,ChangeScene);
    }

    void ChangeScene(){
        SceneManager.LoadScene("Gameplay");
    }
}
