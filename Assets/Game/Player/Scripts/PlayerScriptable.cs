using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "LTG/PlayerData", order = 0)]
public class PlayerScriptable : ScriptableObject {
    
    [Header("PLAYER")]
    [SerializeField] private PlayerData data;

    public PlayerData GetData => data;

    public void SetAnimation(string _animation){
        data.animation = _animation;
    }
}
