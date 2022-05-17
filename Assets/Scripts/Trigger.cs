using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static bool boxtrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (boxtrigger)
        {
            boxtrigger = false;
        } else
        {
            boxtrigger = true;
        }
    }
}
