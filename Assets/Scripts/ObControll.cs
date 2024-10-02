using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObControll : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    [SerializeField] GameObject kayoko;
    [SerializeField] GameObject note;
    [SerializeField] GameObject stairs;
    [SerializeField] GameObject windows;

    private void OnDestroy()
    {
        if (gameObject.tag == "Start")
        {
            foreach (GameObject light in lights)
            {
                Destroy(light);
                kayoko.SetActive(true);
            }
        }

        if (gameObject.tag == "Head")
        {
            kayoko.SetActive(true);
            note.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (gameObject.tag == "GhostHead")
        {
            Destroy(windows);
            stairs.SetActive(true);
        }
    }
}
