using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerInput inputs;
    InputAction useAction;

    private bool isMouseHolded;

    private CameraController cameraController;
    private FishingController fishingController;
    private EquipmentManager equipmentManager;

    public enum State
    {
        IDLE,
        CASTING,
        CASTED,
        REELING
    }
    public static State currState;

    private void Start()
    {
        inputs = GetComponent<PlayerInput>();
        equipmentManager = GetComponent<EquipmentManager>();
        fishingController = GetComponent<FishingController>();
        cameraController = GetComponent<CameraController>();

        useAction = inputs.actions.FindAction("Use");
        useAction.performed += OnMouseHoldPerformed;
        useAction.canceled += OnMouseHoldCanceled;
        useAction.performed += OnMouseClick;
    }

    private void Update()
    {
        if(currState == State.REELING)
        {
            if(isMouseHolded)
            {
                fishingController.reeling();
            }
            else
            {
                fishingController.reelingStoped();
            }
        }
        else if(currState == State.IDLE)
        {
            Destroy(fishingController.getBobber());
            fishingController.setBobber(null);
        }
    }
    private void OnMouseClick(InputAction.CallbackContext context)
    {
        if(currState == State.IDLE)
        {
            currState = State.CASTING;
        }
        else if(currState == State.CASTING)
        {
            Ray ray = new Ray(cameraController.getPlayerCamera().position, cameraController.getPlayerCamera().transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                fishingController.setBobber(Instantiate(equipmentManager.getBobber(), hit.point, Quaternion.identity));
            }
            currState = State.CASTED;
        }
        else if(currState == State.CASTED)
        {
            currState = State.IDLE;
        }
    }
    private void OnMouseHoldPerformed(InputAction.CallbackContext context)
    {
        isMouseHolded = true;
    }
    private void OnMouseHoldCanceled(InputAction.CallbackContext context)
    {
        isMouseHolded = false;
    }
}
