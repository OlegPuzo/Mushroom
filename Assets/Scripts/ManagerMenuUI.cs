using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManagerMenuUI : MonoBehaviour
{
    [SerializeField] private Button _buttonUseSmile;
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonShop;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonExitExitMenu;
    [SerializeField] private Button _buttonExitOptions;
    [SerializeField] private Button _buttonExitShop;
    
    public event UnityAction ClickedButtonSmile;
    public event UnityAction ClickedButtonStart;
    public event UnityAction ClickedButtonShop;
    public event UnityAction ClickedButtonOptions;
    public event UnityAction ClickedButtonExit;
    public event UnityAction ClickedButtonExitExitMenu;
    public event UnityAction ClickedButtonExitOptions;
    public event UnityAction ClickedButtonExitShop;

    private void OnEnable()
    {
        _buttonUseSmile.onClick.AddListener(() => ClickedButtonSmile?.Invoke());

        _buttonExit.onClick.AddListener(() => ClickedButtonExit?.Invoke());
        _buttonStart.onClick.AddListener(() => ClickedButtonStart?.Invoke());
        _buttonShop.onClick.AddListener(() => ClickedButtonShop?.Invoke());
        _buttonOptions.onClick.AddListener(() => ClickedButtonOptions?.Invoke()); 
        _buttonExitExitMenu.onClick.AddListener(() => ClickedButtonExitExitMenu?.Invoke());
        _buttonExitOptions.onClick.AddListener(() => ClickedButtonExitOptions?.Invoke());
        _buttonExitShop.onClick.AddListener(() => ClickedButtonExitShop?.Invoke());

    }

    private void OnDisable()
    {
        _buttonUseSmile.onClick.RemoveListener(() => ClickedButtonSmile?.Invoke());

        _buttonExit.onClick.RemoveListener(() => ClickedButtonExit?.Invoke());
        _buttonStart.onClick.RemoveListener(() => ClickedButtonStart?.Invoke());
        _buttonShop.onClick.RemoveListener(() => ClickedButtonShop?.Invoke());
        _buttonOptions.onClick.RemoveListener(() => ClickedButtonOptions?.Invoke());
        _buttonExitOptions.onClick.RemoveListener(() => ClickedButtonExitOptions?.Invoke());
        _buttonExitShop.onClick.RemoveListener(() => ClickedButtonExitShop?.Invoke());

    }
}
