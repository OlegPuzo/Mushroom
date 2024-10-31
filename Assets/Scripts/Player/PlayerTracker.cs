using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTracker : MonoBehaviour
{
    public event UnityAction<bool> TouchedGround; //Событие, когда мы касаемся земли
    public event UnityAction TouchedCoin;
    public event UnityAction TouchedHurt;
    public event UnityAction TouchedWin;



    //transform.SetParent(null); избавиться от родителя
    //Метод устанавливаюищй рейкаст вниз для обнаружения "земли" под персонажем
    public void UseRayDown(float offsetRayDown, float rayDownLenght)
    {
        Vector3 origin = transform.position + new Vector3(0, offsetRayDown, 0);
        RaycastHit hit;

        if (Physics.Raycast(origin, Vector3.down, out hit, rayDownLenght))
        {
            if (hit.collider.gameObject.GetComponent<Platform>())
            {
                // transform.SetParent(hit.collider.gameObject.transform);
                Debug.Log("Касание платформы");
            }

            TouchedGround?.Invoke(true);
        }
        else
        {
            TouchedGround?.Invoke(false);
        }

        Debug.DrawRay(origin, Vector3.down * rayDownLenght, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>())
        {
            TouchedCoin?.Invoke();
            other.gameObject.SetActive(false);
        }

        else if (other.gameObject.tag == "HitObject")
        {
            TouchedHurt?.Invoke();
            Debug.Log("Касание смерти");

        }

        else if (other.gameObject.GetComponent<FinishLine>())
        {
            TouchedWin?.Invoke();
            Debug.Log("Касание финиша");
        }
    }
}
