using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]



public class Player : MonoBehaviour
{
    [HideInInspector] public int a = 1;
    [Header("Объекты")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private PlayerTracker _playerTracker;
    [SerializeField] private Camera _camera;
    [Header("Клавиши для бега и прыжка")]
    [SerializeField] private KeyCode _keySprint;
    [SerializeField] private KeyCode _keyJump;
    [Header("Характеристики движения")]
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    [Range(0, 7)][SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;
    [Tooltip("Скорость разворота")][SerializeField] private float _turnSpeed;

    [Header("Смещение луча и его длина направленная вниз, для определения земли")]
    [SerializeField] private float _offsetRay;
    [SerializeField] private float _lenghtRay;
    [Space][SerializeField] private float _deathHeight;
    [SerializeField] private int _health;
    [SerializeField] private Slider _healthSlider;

    private Vector3 _startPos;
    private int _coins = 0;
    private bool _isDead = false;

    public event UnityAction<int> ChangedCoin;
    public event UnityAction<int> ChangedHealth;
    public event UnityAction Deathed;
    public event UnityAction Winned;

    public int Health => _health;
    public int Coins => _coins;

    private void OnEnable()
    {
        _playerJump.UsedJumpAnimation += _playerAnimation.OnUsedAnimation;
        _playerMovement.UsedRunAnimation += _playerAnimation.OnUsedAnimation;
        _playerMovement.UsedSprintAnimation += _playerAnimation.OnUsedAnimation;
        _playerTracker.TouchedGround += _playerJump.OnTouchedGround;
        _playerTracker.TouchedCoin += OnTouchedCoin;
        _playerTracker.TouchedHurt += OnTouchedHurt;
        _playerTracker.TouchedWin += OnTouchedWin;
    }

    private void OnDisable()
    {

        _playerJump.UsedJumpAnimation -= _playerAnimation.OnUsedAnimation;
        _playerMovement.UsedRunAnimation -= _playerAnimation.OnUsedAnimation;
        _playerMovement.UsedSprintAnimation -= _playerAnimation.OnUsedAnimation;
        _playerTracker.TouchedGround -= _playerJump.OnTouchedGround;
        _playerTracker.TouchedCoin -= OnTouchedCoin;
        _playerTracker.TouchedHurt -= OnTouchedHurt;
        _playerTracker.TouchedWin -= OnTouchedWin;


    }

    public void SetValue()
    {
        _startPos = transform.position;
        _playerMovement.SetValue(_characterController, _speed, _camera, _keySprint);
        ChangedCoin(_coins);
        ChangedHealth(_health);
    }

    public void PlayWaveAnimation()
    {
        _playerAnimation.OnUsedAnimation(PlayerAnimation.NameWave);
    }

    public void UseAction()
    {
        if (_isDead == false)
        {
           _playerMovement.Move(_turnSpeed, _speed, _sprintSpeed, _playerJump.isGround);
           _playerJump.TryUseJump(_keyJump, _characterController, _gravity, _jumpForce);
           _playerTracker.UseRayDown(_offsetRay, _lenghtRay);
        }

    }

    public void OnTouchedCoin()
    {
        _coins++;
        ChangedCoin?.Invoke(_coins);
    }

    public void OnTouchedHurt()
    {
        _health--;

        if (_health > 0)
        {
            ChangedHealth?.Invoke(_health);
            _healthSlider.value = _health;
            _characterController.enabled = false;
            transform.position = _startPos;
            _characterController.enabled = true;
        }
        else
        {
            _healthSlider.value = _health;
            _playerAnimation.OnUsedAnimation(PlayerAnimation.NameDying);
            _isDead = true;
        }
    }

    public void OnTouchedWin()
    {
        Winned?.Invoke();
    }
    private void CreateActionDeath() => Deathed?.Invoke();

    private void oooo()
    {
        transform.position = _startPos;
    }
}
