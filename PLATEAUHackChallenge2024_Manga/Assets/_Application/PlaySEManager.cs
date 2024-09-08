using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySEManager : MonoBehaviour
{
    public static PlaySEManager Current;

    [SerializeField]
    private AudioSource getCoin;

    private void Awake()
    {
        Current = this;
    }

    public void PlayGetCoin()
    {
        getCoin.Play();
    }
}
