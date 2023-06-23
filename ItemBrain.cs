using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrain : MonoBehaviour
{
    string this_Item_Tag;
    [SerializeField] int CoinValue;


    // Start is called before the first frame update
    void Start()
    {
        this_Item_Tag=this.gameObject.tag;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision Player)
    {
        if(Player.gameObject.layer == 3)
        {
            if (this_Item_Tag == "Item_Coin")
            {
                int addGold = (int)Random.Range(CoinValue - 50f, CoinValue + 50f);
                Player.gameObject.GetComponent<PlayerMovementAndAttack>().AudioConsumed_Gold.Play();
                Player.gameObject.GetComponent<CharacterProLoader>().char_Current_Gold += addGold;

            }
            else if (this_Item_Tag == "Item_Blood")
            {
                Player.gameObject.GetComponent<PlayerMovementAndAttack>().AudioConsumed_Blood.Play();
                Player.gameObject.GetComponent<CharacterProLoader>().char_Current_Blood_Poition += 1;
            }
            else if (this_Item_Tag == "Item_Mana")
            {
                Player.gameObject.GetComponent<PlayerMovementAndAttack>().AudioConsumed_Mana.Play();
                Player.gameObject.GetComponent<CharacterProLoader>().char_Current_Mana_Poition += 1;
            }
            Destroy(this.gameObject);

        }
    }

}
