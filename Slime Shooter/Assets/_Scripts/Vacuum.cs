using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private Effector2D effector;

    private void Update()
    {
        Suction();
    }

    private void Suction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            effector.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            effector.enabled = false;
        }
    }

    private void Reverse()
    {
        //Atira slime
    }
}
