using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed, rotateSpeed, x, z;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
         x = Input.GetAxis("Horizontal");
         z = Input.GetAxis("Vertical");

        animator.SetFloat("MoveSpeed", moveSpeed * z);
        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse X"); // ���콺 �¿� �����ӷ�
        float y = Input.GetAxis("Mouse Y"); // ���콺 ���Ʒ� �����ӷ�

        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }
}
