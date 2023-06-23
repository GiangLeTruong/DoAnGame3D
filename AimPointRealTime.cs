using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPointRealTime : MonoBehaviour
{
    public Transform ref_AimingPoint;
    public Transform this_AimingPoint;

    // Update is called once per frame
    void Update()
    {
        this_AimingPoint.position = ref_AimingPoint.position;
    }
}
