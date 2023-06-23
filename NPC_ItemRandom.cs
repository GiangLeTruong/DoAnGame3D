using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ItemRandom : MonoBehaviour
{
    public GameObject[] itemOut=new GameObject[4];
    private Transform item_Position;
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        item_Position= this.GetComponent<Transform>();
        set_Item();
    }


    void set_Item()
    {
        randomNum = Random.Range(0, itemOut.Length);
        Instantiate(itemOut[randomNum], item_Position.transform.position, item_Position.transform.rotation, item_Position);
    }
}
