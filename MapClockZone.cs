using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClockZone : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(Player)
        {
            if (Player.GetComponent<CharacterProLoader>().char_Current_Level>=6)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
