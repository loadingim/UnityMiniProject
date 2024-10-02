using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] GameObject openBox;
    [SerializeField] InputField Pass;
    [SerializeField] TMP_InputField passtmp;
    [SerializeField] GameObject InputPass;
    [SerializeField] string pw = "6666";

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        InputPass.SetActive(true);
        Pass.text = "";
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputPass.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (Pass.text == pw)
            {
                openBox.SetActive(true);

                Destroy(gameObject);
            }
            else
            {
                Pass.text = "";
            }
        }
    }
}
