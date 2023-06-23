using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMap : MonoBehaviour
{
    public GameObject targetPlayer;
    private GameObject this_Camera;
    private void Start()
    {
        this_Camera = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        camera_MiniMap_Follow();
    }

    void camera_MiniMap_Follow()
    {
        this_Camera.transform.position= new Vector3(targetPlayer.transform.position.x, 30, targetPlayer.transform.position.z);
    }

}
