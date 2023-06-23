using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandom : MonoBehaviour
{
    public GameObject[] itemOut=new GameObject[6];
    public Material[] materialList=new Material[3];
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        set_Material();
    }

   
    void set_Material()
    {
        randomNum = Random.Range(0, materialList.Length);
        Material materialUsing=materialList[randomNum];
        foreach (var i in itemOut)
        {
            i.GetComponent<SkinnedMeshRenderer>().material = materialUsing;
        }    
    }
}
