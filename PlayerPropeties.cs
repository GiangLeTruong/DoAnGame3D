using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropeties : MonoBehaviour
{
    //Item Mesh Manager:
    public GameObject item_mesh_Helmet;
    public GameObject item_mesh_LeftPauldron;
    public GameObject item_mesh_LeftBrace;
    public GameObject item_mesh_LeftHandWeapon;
    public GameObject item_mesh_RightPauldron;
    public GameObject item_mesh_RightBrace;
    public GameObject item_mesh_RightHandWeapon;

    //Item Level Manager:
    public int item_level_Helmet = 0;
    public int item_level_Pauldron = 0;
    public int item_level_Brace = 0;
    public int item_level_RightHandWeapon = 0;
    public int item_level_LeftHandWeapon = 0;

    // Update is called once per frame
    void Update()
    {
        item_PropertiesSYN();
    }
    private void item_PropertiesSYN()
    {
        item_mesh_Helmet.GetComponent<WeaponLoader>().item_Level = item_level_Helmet;
        item_mesh_LeftPauldron.GetComponent<WeaponLoader>().item_Level = item_level_Pauldron;
        item_mesh_RightPauldron.GetComponent<WeaponLoader>().item_Level = item_level_Pauldron;
        item_mesh_LeftBrace.GetComponent<WeaponLoader>().item_Level = item_level_Brace;
        item_mesh_RightBrace.GetComponent<WeaponLoader>().item_Level = item_level_Brace;
        item_mesh_LeftHandWeapon.GetComponent<WeaponLoader>().item_Level = item_level_LeftHandWeapon;
        item_mesh_RightHandWeapon.GetComponent<WeaponLoader>().item_Level = item_level_RightHandWeapon;
    }
    private void item_LevelManager()
    {






    }

    private void player_PropertyManager()
    {






    }

}
