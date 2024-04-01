using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController
{
    private VisualTreeAsset menuTemplate;

    private MenuManager menuManager;

    public void InitMenu(VisualElement _root, AnimationData[] _data){

        menuManager = MenuManager.Instance;

        for (int i = 1; i <= _data.Length; i++)
        {
            Button buttonAnim = _root.Q<Button>("button-anim"+i.ToString());
            AnimationData data = _data[i-1];
            buttonAnim.text = data.name;
            buttonAnim.clicked += () => ButtonChangeAnimation(data);
        }

        Button buttonSelect = _root.Q<Button>("button-select");
        buttonSelect.text = "SELECT";
        buttonSelect.clicked += () => ButtonSelect();
    }

    void ButtonChangeAnimation(AnimationData _animationData){
        menuManager.SetAnimation(_animationData);
    }

    void ButtonSelect(){
        menuManager.OnSelect();
    }
}
