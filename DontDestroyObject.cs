using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DontDestroyObject : MonoBehaviour
{
    GameObject this_GameObject;
    // Start is called before the first frame update
    void Start()
    {
        this_GameObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this_GameObject);
    }
}
