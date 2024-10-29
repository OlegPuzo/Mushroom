using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _rect;

    private void Start()
    {
        _rect = GetComponent<RawImage>();
        StartCoroutine(MoveBackground());
    }
    //void Update()
    //{
    //    _positionX += _speed*Time.deltaTime;
    //    gameObject.GetComponent<RawImage>().uvRect = new Rect(_positionX, _rect.uvRect.y, _rect.uvRect.width, _rect.uvRect.height);
    //}

    private IEnumerator MoveBackground()
    {
        float positionX = 0;

        while (true)
        {
            positionX += _speed * Time.deltaTime;
            gameObject.GetComponent<RawImage>().uvRect = new Rect(positionX, _rect.uvRect.y, _rect.uvRect.width, _rect.uvRect.height);
            yield return null;
        }
    }
}
