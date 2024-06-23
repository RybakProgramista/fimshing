using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private CharacterController characterController;

    PlayerInput inputs;
    InputAction moveAction;
    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<PlayerInput>();
        moveAction = inputs.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        characterController.Move(transform.TransformDirection(new Vector3(direction.x, 0f, direction.y)) * movementSpeed * Time.deltaTime);
    }
}
