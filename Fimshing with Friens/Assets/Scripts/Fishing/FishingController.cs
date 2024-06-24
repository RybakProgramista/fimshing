using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingController : MonoBehaviour
{
    private EquipmentManager equipmentManager;
    private GameObject bobber;
    public GameObject getBobber() { return bobber; }
    public void setBobber(GameObject bobber) { this.bobber = bobber;}
    private void Start()
    {
        equipmentManager = GetComponent<EquipmentManager>();
    }
    public void reeling()
    {
        equipmentManager.changeReelStrenght(-1f * Time.deltaTime);
        bobber.transform.position = Vector3.Lerp(bobber.transform.position, transform.position, 1f * Time.deltaTime);
    }
    public void reelingStoped()
    {
        equipmentManager.changeReelStrenght(1f * Time.deltaTime);
    }
    private void Update()
    {
        if(PlayerManager.currState == PlayerManager.State.CASTED)
        {
            if(Random.Range(1,100) == 69)
            {
                Debug.Log("FISH ON");
                PlayerManager.currState = PlayerManager.State.REELING;
            }
        }
    }
}
