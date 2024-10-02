using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCheck : MonoBehaviour
{
    [SerializeField] bool itemCheck;
    [SerializeField] bool watchNote;
    [SerializeField] GameObject itemGet;
    [SerializeField] GameObject noteImg;
    [SerializeField] GameObject note;
    [SerializeField] GameObject itemSelect;
    [SerializeField] GameObject BoxController;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (itemSelect.tag)
            {
                case "Start":
                    Destroy(itemSelect);
                    itemGet.SetActive(false);
                    break;
                case "Note":
                    noteImg.SetActive(true);
                    note.SetActive(true);
                    watchNote = true;
                    break;
                case "Box":
                    BoxController.GetComponent<BoxController>().Pass();
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
