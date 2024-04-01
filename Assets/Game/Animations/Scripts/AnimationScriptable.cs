using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "LTG/Animation", order = 0)]
public class AnimationScriptable : ScriptableObject {
    
    [Header("ANIMATIONS")]
    [SerializeField] private AnimationData[] data;

    public AnimationData[] GetData => data;

    public int GetClip(string _animation){
        for (int i = 0; i < data.Length; i++)
        {
            if(_animation.Equals(data[i].name)){
                return data[i].clipIndex; 
            }
        }

        Debug.LogError("No animation found.");
        return -1;
    }
}
