using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum TypeAnimation { isJump, Wave, Sprint }

    public static string NameJump = "isJump";
    public static string NameWave = "isWave";
    public static string NameSprint = "isSprint";
    public static string NameRun = "isRun";
    public static string NameDying = "isDying";

    [SerializeField]private Animator _animator;
    [SerializeField] private TypeAnimation _typeAnimation;

    public void OnUsedAnimation(string nameAnimation)
    {
        _animator.SetTrigger(nameAnimation);
    }

    public void OnUsedAnimation(string nameAnimation, bool isPlay)
    {
        _animator.SetBool(nameAnimation, isPlay);
    }
}