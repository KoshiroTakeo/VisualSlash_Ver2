using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour
{
    [SerializeField] private EnemyCommon enemy;
    public void Leave()
    {
        enemy.SendMessage("OnLeave");
    }
}
