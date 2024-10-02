using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] GameObject openPw;


    public void Pass()
    {
        openPw.SetActive(true);
    }
}