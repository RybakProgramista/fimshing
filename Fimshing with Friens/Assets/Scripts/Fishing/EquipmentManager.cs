using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipmentManager : MonoBehaviour
{
    private Reel currReel;

    [SerializeField]
    private GameObject currBobber;
    private void Start()
    {
        currReel = new Reel("Rzy³ka", 20f);
    }
    public void changeReelStrenght(float val)
    {
        currReel.changeCurrStrenght(currReel.CurrStrenght + val);
    }
    public GameObject getBobber() { return currBobber; }
    private void Update()
    {
        Debug.Log("Reel strenght " + currReel.CurrStrenght);
        if(currReel.CurrStrenght <= 0f)
        {
            Debug.Log("Reel snaped");
            PlayerManager.currState = PlayerManager.State.IDLE;
        }
    }
}
