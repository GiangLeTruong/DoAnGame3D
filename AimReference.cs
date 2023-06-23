using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReference : MonoBehaviour
{
    private GameObject aim_Point;

    // Start is called before the first frame update
    void Start()
    {
        aim_Point=this.gameObject;
        setDefault();
    }
    private void setDefault()
    {
        aim_Point.transform.Translate(new Vector3(0f,0f,11f), Space.Self);
    }
    
}
