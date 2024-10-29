using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private float _durationMove;

    private void Start()
    {
        StartCoroutine(Mover());      
    }


    //private IEnumerator Mover()
    //{
    //    Vector3 currentPos = _startPos;
    //    transform.DOLocalMove(currentPos, _durationMove, false);
    //    while (true)
    //    {
    //        if (transform.localPosition == _startPos)
    //        {
    //            transform.DOLocalMove(currentPos, _durationMove, false);
    //            currentPos = _endPos;

    //        }
    //        else if (transform.localPosition == _endPos)
    //        {
    //            transform.DOLocalMove(currentPos, _durationMove, false);
    //            currentPos = _startPos;
    //        }

    //        Debug.Log(" start " + transform.localPosition + " end " + _endPos);
    //        yield return null;
    //    }
    //}

    private IEnumerator Mover()
    {
        Vector3 currentPos = _startPos;
        while (true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentPos, _durationMove*Time.deltaTime);
            if (transform.localPosition == _startPos)
            {
                currentPos = _endPos;

            }
            else if (transform.localPosition == _endPos)
            {
                currentPos = _startPos;
            }

            yield return null;
        }
    }
}
