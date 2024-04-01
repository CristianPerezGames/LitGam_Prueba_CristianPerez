using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    [Header("DATA")]
    [SerializeField] private PlayerScriptable playerScriptable;

    [Header("REFERENCES")]
    [SerializeField] private CharacterAnimation characterAnimation;

    private MenuManager menuManager;

    private void OnValidate() {
        if(characterAnimation == null) characterAnimation = GetComponent<CharacterAnimation>();
    }

    void Start() {
        menuManager = MenuManager.Instance;

        menuManager.OnChangeAnimation += ChangeAnimation;

        ChangeAnimation();
    }

    void ChangeAnimation(){
        characterAnimation.ChangeAnimation(playerScriptable.GetData.animation);
    }
}
