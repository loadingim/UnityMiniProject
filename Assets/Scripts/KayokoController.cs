using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KayokoController : MonoBehaviour
{
    [SerializeField] Transform Playertrans;
    [SerializeField] float Speed;

    private void FixedUpdate()
    {
        Speed += 0.0125f;

        transform.position = Vector3.MoveTowards(transform.position, Playertrans.position, Speed * Time.deltaTime);
        transform.LookAt(Playertrans.position);
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("충돌유령");
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("HorrorGame");
        }
    }
}