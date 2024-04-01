using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [Header("DATA")]
    [SerializeField] private AnimationScriptable animationScriptable;

    [Header("REFERENCES")]
    [SerializeField] private Animator animator;

    public void ChangeAnimation(string _animation){
        var clipIndex = animationScriptable.GetClip(_animation);
        animator.SetFloat("Blend", clipIndex);
    }
}
