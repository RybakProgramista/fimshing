using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    private Reel currReel;
    private void Start()
    {
        currReel = new Reel("Rzy³ka", 20f);
    }
    private void Update()
    {
        if(PlayerManager.currState == PlayerManager.State.REELING)
        {

        }
    }
}
