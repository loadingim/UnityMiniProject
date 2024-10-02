using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed, rotateSpeed;
    [SerializeField] GameObject flashLight;
    private float xRotate, yRotate, x, z, y;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(flashLight.activeSelf ? false : true);
        }
    }

    private void Move()
    {
         x = Input.GetAxis("Horizontal");
         z = Input.GetAxis("Vertical");
        yRotate -= Input.GetAxis("Mouse Y") * Time.deltaTime * moveSpeed;
        xRotate += Input.GetAxis("Mouse X") * Time.deltaTime * moveSpeed;

        animator.SetFloat("MoveSpeed", moveSpeed * z);
        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        x = Input.GetAxis("Mouse X"); // 마우스 좌우 움직임량
        y = Input.GetAxis("Mouse Y"); // 마우스 위아래 움직임량

        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }
}