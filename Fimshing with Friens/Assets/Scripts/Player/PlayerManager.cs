using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum State
    {
        IDLE,
        CASTING,
        REELING
    }
    public static State currState;

}
