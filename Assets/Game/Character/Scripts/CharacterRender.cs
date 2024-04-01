using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRender : MonoBehaviour
{
    [Header("DATA")]
    [SerializeField] private PlayerScriptable playerScriptable;

    [Header("REFERENCES")]
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private Camera cameraRender;
    [SerializeField] private Transform followTarget;

    private void OnValidate() {
        if(characterAnimation == null) characterAnimation = GetComponent<CharacterAnimation>();
    }

    void Start() {
        ChangeAnimation();
    }

    void ChangeAnimation(){
        characterAnimation.ChangeAnimation(playerScriptable.GetData.animation);
    }

    private void LateUpdate() {
        cameraRender.transform.position = new Vector3(followTarget.position.x, cameraRender.transform.position.y, followTarget.position.z - 2.5f);
    }
}
