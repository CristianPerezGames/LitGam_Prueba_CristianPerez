using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuView : MonoBehaviour
{

    [SerializeField] private AnimationScriptable animationScriptable;

    private void Start() {
        UIDocument uiDoc = GetComponent<UIDocument>();

        var menuController = new MenuController();
        menuController.InitMenu(uiDoc.rootVisualElement, animationScriptable.GetData);
    }
}
