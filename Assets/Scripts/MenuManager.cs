using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ManagerMenuUI _managerMenuUI;
    
    [SerializeField] private ExitMenu _exitMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Options _options;
    [SerializeField] private ShopMenu _shopMenu;
    [SerializeField] private SceneChanger _sceneChanger;

    [SerializeField] private Player _player;

    private void OnEnable()
    {   
        _managerMenuUI.ClickedButtonSmile += OnClickedButtonSmile;
        _managerMenuUI.ClickedButtonExit += OnClickedButtonExit;
        _managerMenuUI.ClickedButtonOptions += OnClickedButtonOptions;
        _managerMenuUI.ClickedButtonShop += OnClickedButtonShop;
        _managerMenuUI.ClickedButtonExitExitMenu += OnClickedButtonExitExitMenu;
        _managerMenuUI.ClickedButtonExitOptions += OnClickedButtonExitOptions;
        _managerMenuUI.ClickedButtonExitShop += OnClickedButtonExitShop;


    }

    private void OnDisable()
    {
        _managerMenuUI.ClickedButtonSmile -= OnClickedButtonSmile;
        _managerMenuUI.ClickedButtonExit -= OnClickedButtonExit;
        _managerMenuUI.ClickedButtonOptions -= OnClickedButtonOptions;
        _managerMenuUI.ClickedButtonShop -= OnClickedButtonShop;
        _managerMenuUI.ClickedButtonExitExitMenu -= OnClickedButtonExitExitMenu;
        _managerMenuUI.ClickedButtonExitOptions -= OnClickedButtonExitOptions;
        _managerMenuUI.ClickedButtonExitShop -= OnClickedButtonExitShop;

    }

    private void Start()
    {
        _sceneChanger.ShowPanel(true);
        _player.SetValue();
    }

    private void Update()
    {
        
    }

    private void OnClickedButtonSmile()
    {
        _player.PlayWaveAnimation();
    }

    private void OnClickedButtonExit() => OpenMenu(_exitMenu.gameObject, false);
    private void OnClickedButtonShop() => OpenMenu(_shopMenu.gameObject, false);
    private void OnClickedButtonOptions() => OpenMenu(_options.gameObject, false);
    
    private void OnClickedButtonExitExitMenu() => OpenMenu(_exitMenu.gameObject, true);

    private void OnClickedButtonExitOptions() => OpenMenu(_options.gameObject, true);

    private void OnClickedButtonExitShop() => OpenMenu(_shopMenu.gameObject, true);
//    private void OnClickedButtonReturn() => OpenMenu(_exitMenu.gameObject, true);


    private void OpenMenu(GameObject gameObject, bool isShowMainMenu)
    {
        _mainMenu.gameObject.SetActive(isShowMainMenu);
        gameObject.SetActive(!isShowMainMenu);
    }
}
