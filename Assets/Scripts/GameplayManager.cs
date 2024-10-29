using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private Player _player;
    [SerializeField] private GameManagerUI _gameManagerUI;
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private List<Coin> _coins;



    private bool _canPlay = false;

    private void OnEnable()
    {
        _player.ChangedCoin += _gameManagerUI.ChangeCoin;
        _player.ChangedHealth += _gameManagerUI.ChangeHealth;
        _gameManagerUI.PressedRestartButton += _sceneChanger.LoadGameScene;
        _gameManagerUI.PressedLeaveButton += _sceneChanger.LoadMainScene;
        _player.Deathed += _gameManagerUI.ShowDeathPanel;
        _player.Winned += _sceneChanger.LoadMainScene;
        _finishLine.TouchedPlayer += OnTouchedPlayer;
    }

    private void OnDisable()
    {
        _player.ChangedCoin -= _gameManagerUI.ChangeCoin;
        _player.ChangedHealth -= _gameManagerUI.ChangeHealth;
        _gameManagerUI.PressedRestartButton -= _sceneChanger.LoadGameScene;
        _gameManagerUI.PressedLeaveButton -= _sceneChanger.LoadMainScene;
        _player.Deathed -= _gameManagerUI.ShowDeathPanel;
        _player.Winned -= _sceneChanger.LoadMainScene;
        _finishLine.TouchedPlayer -= OnTouchedPlayer;
    }

    void Start()
    {
        _sceneChanger.ShowPanel(true);
        _player.SetValue();

        _canPlay = true;
    }

    void FixedUpdate()
    {
        if (_canPlay == true)
        {
            _player.UseAction();
        }
    }

    private void OnTouchedPlayer()
    {
        _gameManagerUI.ShowWinPanel();
        _gameManagerUI.ChangeWinValue(_player.Health, _player.Coins, _coins.Count);
        _canPlay = false;
    }
}