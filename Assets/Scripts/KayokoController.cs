using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KayokoController : MonoBehaviour
{
    [SerializeField] Transform Playertrans;
    [SerializeField] float Speed, distance;
    [SerializeField] Animator animator;
    [SerializeField] bool canMove;
    [SerializeField] GameObject bgm;
    [SerializeField] GameObject key;
    private void OnEnable()
    {
        bgm.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(gameObject.tag == "Kayako")
        {
            Speed += 0.0125f;

            transform.position = Vector3.MoveTowards(transform.position, Playertrans.position, Speed * Time.deltaTime);
            transform.LookAt(Playertrans.position);
        }

        if (gameObject.tag == "HouseKayako" && canMove==true)
        {
            Debug.Log("하우스");
            
            Speed += 2.0f;

            transform.position = Vector3.MoveTowards(transform.position, Playertrans.position, Speed * Time.deltaTime);
            transform.LookAt(Playertrans.position);
        }
        distance = Mathf.Abs(Playertrans.position.x - transform.position.x);
        if (distance < 0.2 && gameObject.tag == "HouseKayako")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "Kayako")
        {
            Debug.Log("충돌유령");
            if (collider.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("HorrorGame");
            }
        }

        if (gameObject.tag == "HouseKayako")
        {
            animator.SetBool("Triger", true);
            canMove = true;
        }
    }

    private void OnDestroy()
    {
        if(gameObject.tag == "HouseKayako")
        {
            key.SetActive(true);
        }
    }
}