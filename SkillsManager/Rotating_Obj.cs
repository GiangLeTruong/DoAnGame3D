using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Obj : MonoBehaviour
{
    Transform this_Object;
    [SerializeField] private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        this_Object=this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        set_Rotating();
    }
    private void set_Rotating()
    {
        this_Object.Rotate(new Vector3(0, 0, this_Object.rotation.y + speed * Time.deltaTime*100),Space.Self);
    }
        
    

}
