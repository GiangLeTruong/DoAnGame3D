using UnityEngine;

public class PortalBrain : MonoBehaviour
{
    GameObject this_Portal;
    GameObject this_Portal_UI;
    GameObject Player;
    [SerializeField] float senseRange;
    int doingTime = 0;
    bool canOpenShopUI = false;

    bool isPlayed = false;
    //Check point Symbol:
    [SerializeField] GameObject checkpoint_Symbol;

    //Fx:
    [SerializeField] ParticleSystem onClose_FX;

    //Audio:
    [SerializeField] AudioSource onOpen_Audio;
    [SerializeField] AudioSource onClose_Audio;




    private void Start()
    {
        this_Portal = this.gameObject;
        if (GameObject.FindGameObjectWithTag("Warrior") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Warrior");
        }
        this_Portal_UI = GameObject.FindGameObjectWithTag("UI_Player").transform.Find("PlayerPortalStatue_Box").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        set_AckPlayer();
        if (this_Portal_UI)
        {
            if (canOpenShopUI)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    checkpoint_Symbol.SetActive(true);
                    this_Portal_UI.SetActive(true);
                    Cursor.visible = true;
                    clockInGameScene();
                }
            }
            /*
            else
            {
                
            }
            */
        }

    }
    void set_AckPlayer()
    {
        float distance = Vector3.Distance(this_Portal.transform.position, Player.transform.position);
        if (distance < senseRange)
        {
            if (doingTime == 0)
            {
                canOpenShopUI = true;
                doingTime = 1;
            }
            if(isPlayed==false)
            {
                onClose_FX.Play();
                onOpen_Audio.PlayDelayed(0.5f);
                isPlayed = true;
            }
            
        }
        else
        {
            if (doingTime == 1)
            {
                canOpenShopUI = false;
                this_Portal_UI.SetActive(false);
                doingTime = 2;
            }
            if (doingTime == 2)
            {
                doingTime = 0;

            }
            if(isPlayed)
            {
                onClose_FX.Stop();
                onOpen_Audio.Stop();
                onClose_Audio.Play();
                isPlayed = false;
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
