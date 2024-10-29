using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Camera _mainCamera;
    private Vector3 _move; // Вектор направления движения персонажа
    private Vector2 _input;
    private float _speed; // Текущая скорость движения
    private Vector3 _targetDirection; // Ценральная точка относительно поворота камеры
    private bool _isActivateSprint; // Активирован ли спринт?
    private KeyCode _sprintKeyboard; //Кнопка для спринта

    public event UnityAction<float> ChangedSpeed; // Событие, когда мы меняем скорость
    public event UnityAction<string,bool> UsedRunAnimation;
    public event UnityAction<string,bool> UsedSprintAnimation;
    //public event UnityAction UsedAction;



    public void SetValue(CharacterController characterController, float speed, Camera camera, KeyCode sprintKeyboard)
    {
        _mainCamera = camera; 
        _speed = speed;
        _characterController = characterController;
        _sprintKeyboard = sprintKeyboard;
    }

    public void Move(float turnSpeed, float moveSpeed, float sprintSpeed, bool isGround)
    {
        SetDirectionMove();
        ChangeSpeed(moveSpeed, sprintSpeed);
        UpdateTargetDirection();
        TryRotatingByDirection(turnSpeed);
        TryUseSprint(isGround);

        _characterController.Move(_move * _speed * Time.deltaTime);
    }

    private void SetDirectionMove()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _move = _mainCamera.transform.forward * _input.y + _mainCamera.transform.right * _input.x;
        _move.y = 0;

        if (_move.magnitude > 1)
            _move.Normalize();
    }

    private void UpdateTargetDirection()
    {
        Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;

        Vector3 right = _mainCamera.transform.TransformDirection(Vector3.right);

        _targetDirection = _input.x * right + _input.y * forward;
    }

    //Метод вращения камеры
    private void TryRotatingByDirection(float turnSpeed)
    {
        if (_input != Vector2.zero && _targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = _targetDirection.normalized;
            Quaternion freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            float diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            float eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0)
                eulerY = freeRotation.eulerAngles.y;

            Vector3 euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * Time.deltaTime);
        }
    }

    private void ChangeSpeed(float moveSpeed, float sprintSpeed)
    {
        _speed = _isActivateSprint ? sprintSpeed : moveSpeed;

        if (_input.x != 0 || _input.y != 0)
        {
            ChangedSpeed?.Invoke(_speed);
            UsedRunAnimation?.Invoke(PlayerAnimation.NameRun, true);
            UsedSprintAnimation?.Invoke(PlayerAnimation.NameSprint, _isActivateSprint);
        }
        else
        {
            ChangedSpeed?.Invoke(0);
            UsedRunAnimation?.Invoke(PlayerAnimation.NameRun, false);
        }
    }

    private void TryUseSprint(bool isGround)
    {   
        _isActivateSprint = Input.GetKey(_sprintKeyboard) && _input != Vector2.zero;
    }
}
