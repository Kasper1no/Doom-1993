using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    
    private VisualElement _root;
    private Button _lvl1Button;
    private Button _lvl2Button;
    private Button _lvl3Button;
    private Button _quitButton;

    private void Start()
    {
        _root = uiDocument.rootVisualElement;
        _lvl1Button = _root.Q<Button>("Level1Button");
        _lvl2Button = _root.Q<Button>("Level2Button");
        _lvl3Button = _root.Q<Button>("Level3Button");
        _quitButton = _root.Q<Button>("QuitButton");
        
        _lvl1Button.RegisterCallback<ClickEvent>(OnLvl1ButtonClick);
        _lvl2Button.RegisterCallback<ClickEvent>(OnLvl2ButtonClick);
        _lvl3Button.RegisterCallback<ClickEvent>(OnLvl3ButtonClick);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    private void OnLvl3ButtonClick(ClickEvent evt)
    {
        SceneManager.LoadScene(3);
    }

    private void OnLvl2ButtonClick(ClickEvent evt)
    {
        SceneManager.LoadScene(2);
    }

    private void OnQuitButtonClick(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnLvl1ButtonClick(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
    }
}
