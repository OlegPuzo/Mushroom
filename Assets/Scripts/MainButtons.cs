using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button _button;



    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        _button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.3f, 1);
        _button.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1.0f, 1);
        _button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }
}