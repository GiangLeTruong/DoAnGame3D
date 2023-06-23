using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopKeeperNPCBrain : MonoBehaviour
{
    string this_ShopKeeper_Tag;
    private GameObject Player;
    private GameObject this_ShopKeeper;
    private float senseRange = 3;
    Animator this_Animator;
    string anim_Welcome = "Welcome", anim_Bye = "Bye";
    int doingTime = 0;
    float defaultRotation;

    //Check UI:
    bool canOpenShopUI = false;

    //Check UI:
    GameObject this_ShopKeeper_UI;


    //Audio:
    public AudioSource this_Shopkeeper_AudioHello;
    public AudioSource this_Shopkeeper_AudioBye;



    // Start is called before the first frame update
    void Start()
    {
        this_ShopKeeper = this.GameObject();
        this_Animator = GetComponent<Animator>();
        defaultRotation = this_ShopKeeper.transform.rotation.eulerAngles.y;
        this_ShopKeeper_Tag=this.gameObject.tag;

    }

    // Update is called once per frame
    void Update()
    {
        Find_Player_Class();
        
        if (Player!=null)
        {
            Find_Player_UIBox();
            set_Animation();
            set_ShopKeeperUI();
        }
        
    }
    private void Find_Player_Class()
    {

        if (GameObject.FindGameObjectWithTag("Warrior") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Warrior");
        }
        else if (GameObject.FindGameObjectWithTag("Berserker") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Berserker");
        }
        else if (GameObject.FindGameObjectWithTag("Marksman") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Marksman");
        }
        else Player = null;
    }

    private void Find_Player_UIBox()
    {
        if(this_ShopKeeper_Tag=="ShopKeeper_Helmet")
        {
            this_ShopKeeper_UI = GameObject.FindGameObjectWithTag("UI_Player").transform.Find("ShopKeeper_Helmet_Box").gameObject;
        }
        else if  (this_ShopKeeper_Tag == "ShopKeeper_Braces")
        {
            this_ShopKeeper_UI = GameObject.FindGameObjectWithTag("UI_Player").transform.Find("ShopKeeper_Braces_Box").gameObject;
        }
        else if (this_ShopKeeper_Tag == "ShopKeeper_Pauldrons")
        {
            this_ShopKeeper_UI = GameObject.FindGameObjectWithTag("UI_Player").transform.Find("ShopKeeper_Pauldrons_Box").gameObject;
        }
        else if (this_ShopKeeper_Tag == "ShopKeeper_Weapon")
        {
            this_ShopKeeper_UI = GameObject.FindGameObjectWithTag("UI_Player").transform.Find("ShopKeeper_Weapon_Box").gameObject;
        }

    }

        void set_Animation()
    {
        float distance = Vector3.Distance(this_ShopKeeper.transform.position, Player.transform.position);
        if (distance < senseRange)
        {
            this_ShopKeeper.transform.LookAt(Player.transform);
            if (doingTime==0)
            {
                this_Animator.Play(anim_Welcome);
                this_Shopkeeper_AudioHello.Play();
                canOpenShopUI = true;
                doingTime = 1;
            }
        }
        else
        {
            if (doingTime == 1)
            {
                this_Animator.Play(anim_Bye);
                this_Shopkeeper_AudioBye.Play();
                canOpenShopUI = false;
                doingTime = 2;
            }
            if(doingTime == 2)
            {
                doingTime = 0;

            }
            if(distance> senseRange*2)
            {
                this_ShopKeeper.transform.Rotate(0, -this_ShopKeeper.transform.rotation.eulerAngles.y + defaultRotation, 0);
            }
            
        }

    }
    void set_ShopKeeperUI()
    {
        if (this_ShopKeeper_UI)
        {
            if (canOpenShopUI)
            {
                if(Input.GetKey(KeyCode.E))
                {
                    this_ShopKeeper_UI.SetActive(true);
                    Cursor.visible = true;
                    clockInGameScene();
                }
                
            }
            else
            {
                this_ShopKeeper_UI.SetActive(false);
            }
        }
       

    }

    void clockInGameScene()
    {
        Player.GetComponent<PlayerMovementAndAttack>().enabled = false;
        Player.transform.GetChild(7).GetComponent<CameraFollow>().enabled = false;
        Player.GetComponent<UISystem>().isOnTab = true;
    }


}
