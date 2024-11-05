using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GoToMenuButton : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private int sceneIndex;
    
    private VisualElement _root;
    private Button _menuButton;

    private void Start()
    {
        _root = uiDocument.rootVisualElement;
        _menuButton = _root.Q<Button>("MenuButton");
        
        _menuButton.RegisterCallback<ClickEvent>(OnMenuButtonClick);
    }

    private void OnMenuButtonClick(ClickEvent evt)
    {
        throw new NotImplementedException();
    }
}
