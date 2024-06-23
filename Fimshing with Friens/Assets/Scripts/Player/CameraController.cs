using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera;
    private PlayerInput inputs;

    private float xRotation = 0f;
    [SerializeField]
    private float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, inputs.actions.FindAction("MouseX").ReadValue<float>() * sensitivity);
        xRotation -= inputs.actions.FindAction("MouseY").ReadValue<float>() * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
}
