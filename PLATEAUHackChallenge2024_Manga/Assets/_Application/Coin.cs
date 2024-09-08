using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Coin : MonoBehaviour
{
    const int MaxGetCount = 4;

    static int GetCointCount = 0;

    private void Awake()
    {
        GetCointCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
            PlaySEManager.Current.PlayGetCoin();
            GetCointCount++;
            if(GetCointCount >= MaxGetCount)
            {
                Invoke("CallEnding", 1.0f);
            }
        }
    }

    private void CallEnding()
    {
        Ending.Current.PlayEnding();
    }
}
