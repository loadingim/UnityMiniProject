using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCheck : MonoBehaviour
{
    [SerializeField] bool itemCheck, watchNote, haveHead;
    [SerializeField] GameObject itemGet;
    [SerializeField] GameObject noteImg;
    [SerializeField] GameObject note;
    [SerializeField] TextMeshProUGUI noteText;
    [SerializeField] GameObject itemSelect;
    [SerializeField] GameObject BoxController;
    [SerializeField] GameObject GhostHead;


    private void Update()
    {
        if (watchNote == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                noteImg.SetActive(false);
                note.SetActive(false);
                watchNote = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && itemSelect!=null)
        {
            switch (itemSelect.tag)
            {
                case "Start":
                    Destroy(itemSelect);
                    itemGet.SetActive(false);
                    break;
                case "Note":
                    noteImg.SetActive(true);
                    noteText.text = "Please find my body...";
                    note.SetActive(true);
                    watchNote = true;
                    break;
                case "Note2":
                    noteImg.SetActive(true);
                    noteText.text = "He collected the heads of six people";
                    note.SetActive(true);
                    watchNote = true;
                    break;
                case "Box":
                    BoxController.GetComponent<BoxController>().Pass();
                    break;
                case "Head":
                    Destroy(itemSelect);
                    haveHead = true;
                    break;
                case "GhostHead":
                    if (haveHead == true)
                    {
                        GhostHead.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer == 6)
        {
            itemGet.SetActive(true);
            itemSelect = collider.gameObject;
            itemCheck = true;

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        itemCheck = false;
        itemSelect = null;
        itemGet.SetActive(false);
    }
}
