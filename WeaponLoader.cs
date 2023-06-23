using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponLoader : MonoBehaviour
{
    // Variable:
    public int item_Level = 0;
    private Transform item_Position;
    public GameObject[] item_Types;

    private void Start()
    {
        item_Position = this.GetComponent<Transform>();
    }
    private void Update()
    {
        if (item_Types != null)
        {
            fitWeapon();

        }
    }

    private void fitWeapon()
    {
        if (item_Level == 0)
        {
            sortWeapon();
        }
        else if (item_Level == 1)
        {
            sortWeapon();
        }
        else if (item_Level == 2)
        {
            sortWeapon();
        }
        else if (item_Level == 3)
        {
            sortWeapon();
        }
        else if (item_Level == 4)
        {
            sortWeapon();
        }
    }
    private void sortWeapon()
    {
        
        for (int i = 0; i < item_Types.Length; i++)
        {

            if (i == item_Level)
            {
                clearOldWeapon(item_Types[i]);
                if (item_Position.childCount < 1)
                {
                    Instantiate(item_Types[i], item_Position.transform.position, item_Position.transform.rotation, item_Position);
                }
            }
        }
    }
    private void clearOldWeapon(GameObject netx)
    {
        
        if(item_Position.childCount == 1)
        {
            for (int k=0;k< item_Position.childCount;k++)
            {
                if(item_Position.GetChild(k).tag!= netx.tag)
                {
                    Destroy(item_Position.GetChild(k).gameObject);
                }
                
            }
           
        }
    }

    }
    

