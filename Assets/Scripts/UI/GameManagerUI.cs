using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    [Header("Тексты на экране")]
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _coinsWinText;
    [SerializeField] private TMP_Text _healthWinText;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonLeave;
    [SerializeField] private GameObject _panelDeath;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private Button _buttonWinLeave;
    [SerializeField] private Button _buttonWinNext;
    [SerializeField] private Button _buttonWinRestart;

    public event UnityAction PressedLeaveButton;
    public event UnityAction PressedRestartButton;
    public event UnityAction PressedNextButton;

    private void OnEnable()
    {
        _buttonLeave.onClick.AddListener(() => PressedLeaveButton?.Invoke());
        _buttonWinLeave.onClick.AddListener(() => PressedLeaveButton?.Invoke());
        _buttonRestart.onClick.AddListener(() =>PressedRestartButton?.Invoke());
        _buttonWinRestart.onClick.AddListener(()=>PressedRestartButton?.Invoke());
        _buttonWinNext.onClick.AddListener(() =>PressedNextButton?.Invoke());
    }

    private void OnDisable()
    {
        _buttonLeave.onClick.RemoveListener(() => PressedLeaveButton?.Invoke());
        _buttonWinLeave.onClick.RemoveListener(() => PressedLeaveButton?.Invoke());
        _buttonRestart.onClick.RemoveListener(() => PressedRestartButton?.Invoke());
        _buttonWinRestart.onClick.RemoveListener(() => PressedRestartButton?.Invoke());
        _buttonWinNext.onClick.RemoveListener(()=>PressedNextButton?.Invoke());
    } 

    public void ChangeCoin(int coin)
    {
        _coinsText.text = coin.ToString();
    }

    public void ChangeHealth(int health)
    {
        _healthText.text = health.ToString();
    }

    public void ShowDeathPanel()
    {
        _panelDeath.SetActive(true);
    }

    public void ShowWinPanel()
    {
        _panelWin.SetActive(true);
    }

    public void ChangeWinValue(int health, int currentCoins, int maxCoins)
    {
        _coinsWinText.text = currentCoins.ToString() + "/" + maxCoins.ToString();
        _healthWinText.text = health.ToString();
    }
}
