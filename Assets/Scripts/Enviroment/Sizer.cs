using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sizer : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _durationMove;

    private void Start()
    {
        StartCoroutine(Mover());
    }


    private IEnumerator Mover()
    {
        Vector3 currentPos = _startPos;
        transform.DOScale(currentPos, _durationMove).SetLoops(-1, LoopType.Yoyo);
        //while (true)
        //{
        //    if (transform.localPosition == _startPos)
        //    {
        //        transform.DORotate(currentPos, _durationMove);
        //        currentPos = _endPos;

        //    }
        //    else if (transform.localPosition == _endPos)
        //    {
        //        transform.DORotate(currentPos, _durationMove);
        //        currentPos = _startPos;
        //    }

        //    Debug.Log(" start " + transform.localPosition + " end " + _endPos);
        //    yield return null;
        //}
        yield return null;
    }

}
