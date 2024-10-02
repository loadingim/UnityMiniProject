using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] GameObject openBox;
    [SerializeField] GameObject box;
    [SerializeField] TMP_InputField Passtmp;
    [SerializeField] GameObject InputPass;
    [SerializeField] string pw = "6666";
    

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        InputPass.SetActive(true);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputPass.SetActive(false);
    }

    void Update()
    {
        Debug.Log("실행");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (Passtmp.text == pw)
            {
                Debug.Log("정답");
                openBox.SetActive(true);
                Destroy(box);
            }
            else
            {
                Debug.Log("틀림");
            }
        }
    }
}
