using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    //Revival Point:
    [SerializeField] Transform revival_Point;
    //Char Name:
    [SerializeField] TMP_Text ui_text_CharName;
    //Char Gold:
    [SerializeField] TMP_Text ui_text_CharGold;

    //Char Item Slots:
    [SerializeField] TMP_Text ui_text_CharBloodPoition;
    [SerializeField] TMP_Text ui_text_CharManaPoition;

    // Control Item:
    [SerializeField] GameObject iconBlood;
    [SerializeField] GameObject iconMana;

    public bool isOnBood=true;
    public bool isOnMana = false;

    //Is on UI Tab:
    public bool isOnTab=false;

    //Load and Save Game:
    string filePath = Path.Combine(Application.streamingAssetsPath, "Player_Property.csv");
    private char fieldSeperator = ','; // Dau phay
    //Player UIs:
    public GameObject ui_GameOver;
    public GameObject ui_EndGame;
    [SerializeField] GameObject ui_CheatBox;
    [SerializeField] GameObject ui_Guild;
    [SerializeField] GameObject ui_PlayerPropertyBox;
    [SerializeField] GameObject ui_PlayerSkills;
    [SerializeField] GameObject ui_PlayerMainMenu;
    [SerializeField] GameObject ui_PlayerPotalTab;


    [SerializeField] TMP_Text ui_text_Current_Level;
    [SerializeField] TMP_Text ui_text_Current_Strength;
    [SerializeField] TMP_Text ui_text_Current_Dexterity;
    [SerializeField] TMP_Text ui_text_Current_Intelligence;
    [SerializeField] TMP_Text ui_text_Current_Vitality;
    [SerializeField] TMP_Text ui_text_Current_AttackDamage;
    [SerializeField] TMP_Text ui_text_Current_MaxHealth;
    [SerializeField] TMP_Text ui_text_Current_HealthRegen;
    [SerializeField] TMP_Text ui_text_Current_MaxMana;
    [SerializeField] TMP_Text ui_text_Current_ManaRegen;
    [SerializeField] TMP_Text ui_text_Current_Gold;
    [SerializeField] TMP_Text ui_text_Current_UpgradePoint;


    //UI ShopKeeper:
    [SerializeField] Slider ui_HelmetLevel_Slider;
    [SerializeField] Slider ui_BracesLevel_Slider;
    [SerializeField] Slider ui_PauldronsLevel_Slider;
    [SerializeField] Slider ui_WeaponsLevel_Slider;

    //UI GuildBox:
    int readChapter=1;
    [SerializeField] TMP_Text text_Guild;

    //Teleport Check Point:
    //Check Point Symbol:
    [SerializeField] GameObject checkpoint_GremlingCity;
    [SerializeField] GameObject checkpoint_MysJungle;
    [SerializeField] GameObject checkpoint_DarkWoods;
    [SerializeField] GameObject checkpoint_ScorchedLand;

    //Check Point UI(Text+Button):
    [SerializeField] GameObject ui_Teleport_GremlingCity;
    [SerializeField] GameObject ui_Teleport_MysJungle;
    [SerializeField] GameObject ui_Teleport_DarkWoods;
    [SerializeField] GameObject ui_Teleport_ScorchedLand;


    //Set Gold Price For Upgrede Items:
    [SerializeField] TMP_Text ui_text_Helmet_Price;
    [SerializeField] TMP_Text ui_text_Braces_Price;
    [SerializeField] TMP_Text ui_text_Pauldrons_Price;
    [SerializeField] TMP_Text ui_text_Weapons_Price;
    //Audio Upgrade:
    public AudioSource this_Character_AudioOK;
    public AudioSource this_Character_AudioNoNo;
    // Start is called before the first frame update
    void Start()
    {
        isOnBood = true;
        isOnMana = false;

        ui_HelmetLevel_Slider.maxValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ui_text_CharName.text = this.GetComponent<CharacterProLoader>().Name;
        ui_text_CharGold.text = this.GetComponent<CharacterProLoader>().char_Current_Gold.ToString();
        ui_text_CharBloodPoition.text= this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition.ToString();
        ui_text_CharManaPoition.text= this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition.ToString();



        set_ui_PlayerPropertyBox();
        set_ui_PlayerSkillsBox();
        //UI Opener:
        open_PlayerUIs();
        text_GuildBox_Editor();
        //Set Item Switcher:
        item_Switcher();
        //Set Item UI:
        set_ui_Helmet();
        set_ui_Braces();
        set_ui_Pauldrons();
        set_ui_Weapons();
        //Teleport:
        check_Teleport();
        //Set Item Prices:
        set_Item_Prices();
    }
    //---------------------------------------------------------------------------------------------------------------------
    // SET UI PLAYER PROPERTY BOX:
    void set_ui_PlayerPropertyBox()
    {
        if (ui_PlayerPropertyBox)
        {
            ui_text_Current_Level.text= this.GetComponent<CharacterProLoader>().char_Current_Level.ToString();
            ui_text_Current_Strength.text = this.GetComponent<CharacterProLoader>().char_Current_Strength.ToString();
            ui_text_Current_Dexterity.text = this.GetComponent<CharacterProLoader>().char_Current_Dexterity.ToString();
            ui_text_Current_Intelligence.text = this.GetComponent<CharacterProLoader>().char_Current_Intelligence.ToString();
            ui_text_Current_Vitality.text = this.GetComponent<CharacterProLoader>().char_Current_Vitality.ToString();
            ui_text_Current_AttackDamage.text = this.GetComponent<CharacterProLoader>().char_Current_Damage.ToString();
            ui_text_Current_MaxHealth.text = this.GetComponent<CharacterProLoader>().char_Current_maxHealth.ToString();
            ui_text_Current_HealthRegen.text = this.GetComponent<CharacterProLoader>().char_Current_regHealth.ToString();
            ui_text_Current_MaxMana.text = this.GetComponent<CharacterProLoader>().char_Current_maxMana.ToString();
            ui_text_Current_ManaRegen.text = this.GetComponent<CharacterProLoader>().char_Current_regMana.ToString();
            ui_text_Current_Gold.text= this.GetComponent<CharacterProLoader>().char_Current_Gold.ToString();
            ui_text_Current_UpgradePoint.text= this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint.ToString();
        }
    }
    // Item stwicher:
    private void item_Switcher()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isOnBood)
            {
                isOnBood = false;
                isOnMana = true;

            }
            else
            {
                isOnBood = true;
                isOnMana = false;
            }
        }
        iconBlood.SetActive(isOnBood);
        iconMana.SetActive(isOnMana);
    }
    public void button_AddStrength()
    {
        if(this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint>0)
        {
            this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint -= 1;
            this.GetComponent<CharacterProLoader>().char_Add_Strength += 1;
        }
    }
    public void button_AddDexterity()
    {
        if (this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint > 0)
        {
            this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint -= 1;
            this.GetComponent<CharacterProLoader>().char_Add_Dexterity += 1;
        }
    }
    public void button_AddIntelligence()
    {
        if (this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint > 0)
        {
            this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint -= 1;
            this.GetComponent<CharacterProLoader>().char_Add_Intelligence += 1;
        }
    }
    public void button_AddVitality()
    {
        if (this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint > 0)
        {
            this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint -= 1;
            this.GetComponent<CharacterProLoader>().char_Add_Vitality += 1;
        }
    }
    //---------------------------------------------------------------------------------------------------------------------
    // SET UI PLAYER ITEMS BOX:
    //Shop Keeper Upgrade:
    //Helmet:
    void set_ui_Helmet()
    {
        ui_HelmetLevel_Slider.value = this.GetComponent<CharacterProLoader>().helmet_Current_Point;
        if(this.GetComponent<CharacterProLoader>().helmet_Current_Level==4)
        {
            ui_HelmetLevel_Slider.value = 5;
        }
        else
        {
            ui_HelmetLevel_Slider.value = this.GetComponent<CharacterProLoader>().helmet_Current_Point;
        }
    }

    public void button_HelmetUpgrade()
    {
        if (this.GetComponent<CharacterProLoader>().helmet_Current_Level < 4)
        {
            if (int.Parse(ui_text_Helmet_Price.text) < this.GetComponent<CharacterProLoader>().char_Current_Gold)
            {
                this.GetComponent<CharacterProLoader>().helmet_Current_Point += 1;
                this_Character_AudioOK.Play();
                this.GetComponent<CharacterProLoader>().char_Current_Gold -= int.Parse(ui_text_Helmet_Price.text);
            }
            else
            {
                this_Character_AudioNoNo.Play();
            }

        }
        else
        {
            this_Character_AudioNoNo.Play();
        }
    }
    //Braces:
    void set_ui_Braces()
    {
        ui_BracesLevel_Slider.value = this.GetComponent<CharacterProLoader>().braces_Current_Point;
        if (this.GetComponent<CharacterProLoader>().braces_Current_Level == 4)
        {
            ui_BracesLevel_Slider.value = 5;
        }
        else
        {
            ui_BracesLevel_Slider.value = this.GetComponent<CharacterProLoader>().braces_Current_Point;
        }
    }
    public void button_BracesUpgrade()
    {
        if (this.GetComponent<CharacterProLoader>().braces_Current_Level < 4)
        {
            if (int.Parse(ui_text_Braces_Price.text) < this.GetComponent<CharacterProLoader>().char_Current_Gold)
            {
                this.GetComponent<CharacterProLoader>().braces_Current_Point += 1;
                this_Character_AudioOK.Play();
                this.GetComponent<CharacterProLoader>().char_Current_Gold -= int.Parse(ui_text_Braces_Price.text);
            }
            else
            {
                this_Character_AudioNoNo.Play();
            }

        }
        else
        {
            this_Character_AudioNoNo.Play();
        }
    }
    //Pauldrons:
    void set_ui_Pauldrons()
    {
        ui_PauldronsLevel_Slider.value = this.GetComponent<CharacterProLoader>().pauldrons_Current_Point;
        if (this.GetComponent<CharacterProLoader>().pauldrons_Current_Level == 4)
        {
            ui_PauldronsLevel_Slider.value = 5;
        }
        else
        {
            ui_PauldronsLevel_Slider.value = this.GetComponent<CharacterProLoader>().pauldrons_Current_Point;
        }
    }
    public void button_PauldronsUpgrade()
    {
        if (this.GetComponent<CharacterProLoader>().pauldrons_Current_Level < 4)
        {
            if (int.Parse(ui_text_Pauldrons_Price.text) < this.GetComponent<CharacterProLoader>().char_Current_Gold)
            {
                this.GetComponent<CharacterProLoader>().pauldrons_Current_Point += 1;
                this_Character_AudioOK.Play();
                this.GetComponent<CharacterProLoader>().char_Current_Gold -= int.Parse(ui_text_Pauldrons_Price.text);
            }
            else
            {
                this_Character_AudioNoNo.Play();
            }

        }
        else
        {
            this_Character_AudioNoNo.Play();
        }
    }
    //Weapons:
    void set_ui_Weapons()
    {
        ui_WeaponsLevel_Slider.value = this.GetComponent<CharacterProLoader>().weapons_Current_Point;
        if (this.GetComponent<CharacterProLoader>().weapons_Current_Level == 4)
        {
            ui_WeaponsLevel_Slider.value = 5;
        }
        else
        {
            ui_WeaponsLevel_Slider.value = this.GetComponent<CharacterProLoader>().weapons_Current_Point;
        }
    }

    public void button_WeaponsUpgrade()
    {
        if (this.GetComponent<CharacterProLoader>().weapons_Current_Level < 4)
        {
            if(int.Parse(ui_text_Weapons_Price.text)< this.GetComponent<CharacterProLoader>().char_Current_Gold)
            {
                this.GetComponent<CharacterProLoader>().weapons_Current_Point += 1;
                this_Character_AudioOK.Play();
                this.GetComponent<CharacterProLoader>().char_Current_Gold -= int.Parse(ui_text_Weapons_Price.text);
            }
            else
            {
                this_Character_AudioNoNo.Play();
            }
           
        }
        else
        {
            this_Character_AudioNoNo.Play();
        }
    }
    //Set Item Prices:
    void set_Item_Prices()
    {
        ui_text_Helmet_Price.text= (this.GetComponent<CharacterProLoader>().helmet_Current_Level * 200 + this.GetComponent<CharacterProLoader>().helmet_Current_Point * 10).ToString();
        ui_text_Braces_Price.text= (this.GetComponent<CharacterProLoader>().braces_Current_Level * 200 + this.GetComponent<CharacterProLoader>().braces_Current_Point * 10).ToString();
        ui_text_Pauldrons_Price.text = (this.GetComponent<CharacterProLoader>().pauldrons_Current_Level *200+ this.GetComponent<CharacterProLoader>().pauldrons_Current_Point *10).ToString();
        ui_text_Weapons_Price.text= (this.GetComponent<CharacterProLoader>().weapons_Current_Level *200+ this.GetComponent<CharacterProLoader>().weapons_Current_Point *10).ToString();


    }
        private void open_PlayerUIs()
        {
        if (Input.GetKey(KeyCode.P) && isOnTab == false)
        {
            Cursor.visible = true;
            clockInGameScene();
            ui_CheatBox.SetActive(true);

        }
        if (Input.GetKey(KeyCode.B)&& isOnTab==false)
        {
            Cursor.visible = true;
            clockInGameScene();
            ui_PlayerPropertyBox.SetActive(true);

        }
        if (Input.GetKey(KeyCode.N) && isOnTab == false)
        {
            Cursor.visible = true;
            clockInGameScene();
            ui_PlayerSkills.SetActive(true);

        }
        if (Input.GetKey(KeyCode.H) && isOnTab == false)
        {
            Cursor.visible = true;
            clockInGameScene();
            ui_Guild.SetActive(true);

        }
        if (Input.GetKey(KeyCode.Escape) && isOnTab == false)
        {
            Cursor.visible = true;
            clockInGameScene();
            ui_PlayerMainMenu.SetActive(true);

        }


    }
    //---------------------------------------------------------------------------------------------------------------------
    // SET UI SKILL BOX:
    void set_ui_PlayerSkillsBox()
    {
        if (ui_PlayerSkills)
        {
            ui_PlayerSkills.GetComponent<UI_Skills_Box_Loader>().available_SkillPoint.text = this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint.ToString();
            ui_PlayerSkills.GetComponent<UI_Skills_Box_Loader>().level_Of_Skill_1=this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level;
            ui_PlayerSkills.GetComponent<UI_Skills_Box_Loader>().level_Of_Skill_2 = this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level;
            ui_PlayerSkills.GetComponent<UI_Skills_Box_Loader>().level_Of_Skill_3 = this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level;
            ui_PlayerSkills.GetComponent<UI_Skills_Box_Loader>().level_Of_Skill_4 = this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level;
        }
    }

    public void button_Upgrade_Skill(int Skill_i)
    {
        Cursor.visible = true;
        switch(Skill_i)
        {
            case 1:
                if (this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint > 0)
                {
                    if(this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level<3)
                    {
                        this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level += 1;
                        this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint -= 1;
                    }
                    
                }
                break;
            case 2:
                if (this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint > 0)
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level < 3)
                    {
                        this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level += 1;
                        this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint -= 1;
                        
                    }
                }
                break;
            case 3:
                if (this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint > 0)
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level < 3)
                    {
                        this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level += 1;
                        this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint -= 1;
                    }
                }
                break;
            case 4:
                if (this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint > 0 && this.GetComponent<CharacterProLoader>().char_Current_Level >= 6)
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level < 3)
                    {
                        this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level += 1;
                        this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint -= 1;
                    }
                }
                break;
        }
    }


    //---------------------------------------------------------------------------------------------------------------------
    //Check Point Teleport:
    void check_Teleport()
    {
        //GremlingCity:
        if (checkpoint_GremlingCity.activeSelf)
        {
            ui_Teleport_GremlingCity.SetActive(true);
        }
        else
        {
            ui_Teleport_GremlingCity.SetActive(false);
        }
        //MysJungle:
        if (checkpoint_MysJungle.activeSelf)
        {
            ui_Teleport_MysJungle.SetActive(true);
        }
        else
        {
            ui_Teleport_MysJungle.SetActive(false);
        }
        //DarkWoods:
        if (checkpoint_DarkWoods.activeSelf)
        {
            ui_Teleport_DarkWoods.SetActive(true);
        }
        else
        {
            ui_Teleport_DarkWoods.SetActive(false);
        }
        //ScorchedLand:
        if (checkpoint_ScorchedLand.activeSelf)
        {
            ui_Teleport_ScorchedLand.SetActive(true);
        }
        else
        {
            ui_Teleport_ScorchedLand.SetActive(false);
        }
    }



    //Button Teleport:
    public void button_Teleport(GameObject teleport_Portal)
    {
        ui_PlayerPotalTab.SetActive(false);
        GameObject teleportPoint;
        teleportPoint = teleport_Portal.transform.Find("TeleportPoint").gameObject;
        this.transform.position = teleportPoint.transform.position;

        //On close Tab:
        this.GetComponent<PlayerMovementAndAttack>().enabled = true;
        this.transform.GetChild(7).GetComponent<CameraFollow>().enabled = true;
        isOnTab = false;
    }

    //---------------------------------------------------------------------------------------------------------------------
    // SET UI CheaterBox:
    public void button_CheatStrength(int numStrength)
    {
        this.GetComponent<CharacterProLoader>().char_Add_Strength += numStrength;
    }
    public void button_CheatIntel(int numIntel)
    {
        this.GetComponent<CharacterProLoader>().char_Add_Intelligence += numIntel;
    }
    public void button_CheatGold(int numGold)
    {
        this.GetComponent<CharacterProLoader>().char_Current_Gold += numGold;
    }
    public void button_CheatEXP(int numEXP)
    {
        this.GetComponent<CharacterProLoader>().char_Current_Exp += numEXP;
    }

    //---------------------------------------------------------------------------------------------------------------------
    // SET UI GuildBox:
    public void button_NextChap()
    {
        if(readChapter==1|| readChapter == 2)
        {
            readChapter += 1;
        }
    }
    public void button_BackChap()
    {
        if(readChapter==2|| readChapter == 3)
        {
            readChapter -= 1;
        }
    }

    void text_GuildBox_Editor()
    {
        if (readChapter == 1)
        {
            text_Guild.text = "Chapter 1:\r\nIn the first levels (<6), fight monsters in the MysJungle area.\r\nWhen the level is reached, the portal will open for the player to pass through the DarkWood area.\r\nThe teleport ports help players move quickly to the check points.\r\nWhen strong enough, kill the last Boss to end the Game.";
        }
        else if (readChapter == 2)
        {
            text_Guild.text = "Chapter 2:\r\nPress the B key to open the player's stats tab.\r\nPress the N key to open the character skills tab.\r\nPress the ESC key to open the Menu tab.\r\nWeapons and equipment can be upgraded at NPCs.";
        }
        else
        {
            text_Guild.text = "Chapter 3:\r\nBeware of Jungle Monsters, they can kill you.\r\nThere are 2 main types of monsters: close-range and long-range. In each area the monster has different power.\r\nBoss in addition to the ability to attack normally with high damage can also use skills. Very dangerous!\r\nP/s: Monsters in the MysJungle area are very weak, suitable for early game farming.";
        }

    }

    //---------------------------------------------------------------------------------------------------------------------
    // SET LOAD/SAVE:
    public void button_LoadGame()
    {

        TextReader read;
        read = new StreamReader(filePath);
        string[] dataUsers = read.ReadToEnd().Split(fieldSeperator);

        int nums = dataUsers.Length - 1;
        if (nums > 0)
        {
            this.GetComponent<CharacterProLoader>().char_Add_Strength = int.Parse(dataUsers[0]);
            this.GetComponent<CharacterProLoader>().char_Add_Dexterity = int.Parse(dataUsers[1]);
            this.GetComponent<CharacterProLoader>().char_Add_Intelligence = int.Parse(dataUsers[2]);
            this.GetComponent<CharacterProLoader>().char_Add_Vitality = int.Parse(dataUsers[3]);
            this.GetComponent<CharacterProLoader>().char_Current_Gold = int.Parse(dataUsers[4]);
            this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition = int.Parse(dataUsers[5]);
            this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition = int.Parse(dataUsers[6]);
            this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level = int.Parse(dataUsers[7]);
            this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level = int.Parse(dataUsers[8]);
            this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level = int.Parse(dataUsers[9]);
            this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level = int.Parse(dataUsers[10]);
            this.GetComponent<CharacterProLoader>().char_Current_Exp = int.Parse(dataUsers[11]);
            this.GetComponent<CharacterProLoader>().char_Current_maxExp = int.Parse(dataUsers[12]);
            this.GetComponent<CharacterProLoader>().char_Current_Level = int.Parse(dataUsers[13]);
            this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint = int.Parse(dataUsers[14]);
            this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint = int.Parse(dataUsers[15]);
            this.GetComponent<CharacterProLoader>().helmet_Current_Point = int.Parse(dataUsers[16]);
            this.GetComponent<CharacterProLoader>().helmet_Current_Level = int.Parse(dataUsers[17]);
            this.GetComponent<CharacterProLoader>().braces_Current_Point = int.Parse(dataUsers[18]);
            this.GetComponent<CharacterProLoader>().braces_Current_Level = int.Parse(dataUsers[19]);
            this.GetComponent<CharacterProLoader>().pauldrons_Current_Point = int.Parse(dataUsers[20]);
            this.GetComponent<CharacterProLoader>().pauldrons_Current_Level = int.Parse(dataUsers[21]);
            this.GetComponent<CharacterProLoader>().weapons_Current_Point = int.Parse(dataUsers[22]);
            this.GetComponent<CharacterProLoader>().weapons_Current_Level = int.Parse(dataUsers[23]);
        }
        read.Close();
    }
    public void button_SaveGame()
    {
        TextWriter Write;
        Write = new StreamWriter(filePath, false);
        Write.Write(this.GetComponent<CharacterProLoader>().char_Add_Strength + "," + this.GetComponent<CharacterProLoader>().char_Add_Dexterity + "," + this.GetComponent<CharacterProLoader>().char_Add_Intelligence + "," + this.GetComponent<CharacterProLoader>().char_Add_Vitality + "," + this.GetComponent<CharacterProLoader>().char_Current_Gold + "," + this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition + "," + this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition + "," + this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level + "," + this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level + "," + this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level + "," + this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level + "," + this.GetComponent<CharacterProLoader>().char_Current_Exp + "," + this.GetComponent<CharacterProLoader>().char_Current_maxExp + "," + this.GetComponent<CharacterProLoader>().char_Current_Level + "," + this.GetComponent<CharacterProLoader>().char_Current_UpgradePoint + "," + this.GetComponent<CharacterProLoader>().char_Current_SkillsPoint + "," + this.GetComponent<CharacterProLoader>().helmet_Current_Point + "," + this.GetComponent<CharacterProLoader>().helmet_Current_Level + "," + this.GetComponent<CharacterProLoader>().braces_Current_Point + "," + this.GetComponent<CharacterProLoader>().braces_Current_Level + "," + this.GetComponent<CharacterProLoader>().pauldrons_Current_Point + "," + this.GetComponent<CharacterProLoader>().pauldrons_Current_Level + "," + this.GetComponent<CharacterProLoader>().weapons_Current_Point + "," + this.GetComponent<CharacterProLoader>().weapons_Current_Level);
        Write.Close();
        button_LoadGame();
    }


    //---------------------------------------------------------------------------------------------------------------------
    // SET UI GENERAL:
    public void button_Close(GameObject thisUI)
    {
        thisUI.SetActive(false);
        Cursor.visible = false;
        this.GetComponent<PlayerMovementAndAttack>().enabled = true;
        this.transform.GetChild(7).GetComponent<CameraFollow>().enabled = true;
        isOnTab = false;
    }

    public void button_Revival()
    {
        Cursor.visible = false;
        this.GetComponent<PlayerMovementAndAttack>().enabled = true;
        this.transform.GetChild(7).GetComponent<CameraFollow>().enabled = true;
        isOnTab = false;
        this.gameObject.transform.position=revival_Point.position;
        this.GetComponent<HealthController>().isDie=false;
        this.GetComponent<Animator>().Play("Idle1");
        ui_GameOver.SetActive(false);
    }


    public void button_Exit()
    {
        Application.Quit();
    }

    public void slider_Volume(Slider volumeSlider)
    {
        AudioListener.volume = volumeSlider.value;
    }
    public void slider_Brightness(Slider brightnessSlider)
    {
        GameObject the_Sun = GameObject.FindGameObjectWithTag("SUN");
        if(the_Sun)
        {
            the_Sun.GetComponent<Light>().intensity = brightnessSlider.value;
        }
        
    }

    //---------------------------------------------------------------------------------------------------------------------
    // CLOCK IN GAME SCREEN:
    void clockInGameScene()
    {
        this.GetComponent<PlayerMovementAndAttack>().enabled = false;
        this.transform.GetChild(7).GetComponent<CameraFollow>().enabled = false;
        isOnTab = true;
    }
}
