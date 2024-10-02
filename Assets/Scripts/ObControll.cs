using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObControll : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    [SerializeField] GameObject kayoko;

    private void OnDestroy()
    {
        foreach (GameObject light in lights)
        {
            Destroy(light);
            kayoko.SetActive(true);
        }
    }
}
