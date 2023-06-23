using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterProLoader : MonoBehaviour
{
    //Path:
    string data_Path = Path.Combine(Application.streamingAssetsPath, "Character.json");

    // Install-Package Newtonsoft.Json
    List <IDictionary> Chars;
    public string Name;
    private string Class;
    private int base_Strength;
    private int base_Dexterity;
    private int base_Intelligence;
    private int base_Vitality;

    //Add Property Property:
    public int char_Add_Strength =0;
    public int char_Add_Dexterity =0;
    public int char_Add_Intelligence=0;
    public int char_Add_Vitality=0;

    //Gold:
    public int char_Current_Gold=0;

    //Item Slot:
    public int char_Current_Blood_Poition = 0;
    public int char_Current_Mana_Poition = 0;


    //Current Property:
    public int char_Current_Strength;
    public int char_Current_Dexterity;
    public int char_Current_Intelligence;
    public int char_Current_Vitality;
    public int char_Current_maxHealth;
    public int char_Current_regHealth;
    public int char_Current_maxMana;
    public int char_Current_regMana;
    public int char_Current_Damage;
    public int char_Current_AttackRate;

    //Current Skills Level:
    public int char_Current_Skill_1_Level=0;
    public int char_Current_Skill_2_Level=0;
    public int char_Current_Skill_3_Level = 0;
    public int char_Current_Skill_4_Level = 0;

    //Current Skills Index:
    //Skill 1:
    public int skill_1_TimeTolive = 0;
    public int skill_1_deal_Damage = 0;
    //Skill 2:
    public int skill_2_maxHP = 0;
    public int skill_2_maxHP_regen = 0;
    //Skill 3:
    public int skill_3_deal_DamagePerSecond = 0;
    //Skill 4:
    public int skill_4_deal_DamagePerSword = 0;
    public int skill_4_TimeToLive = 0;


    //Leveling and UpgradePoint:
    public int char_Current_Exp=0;
    public int char_Current_maxExp=500;
    public int char_Current_Level=0;
    public int char_Current_UpgradePoint = 0;
    public int char_Current_SkillsPoint = 0;

    //Item Upgrade and Level:
    //Helmet Item:
    public int helmet_Current_Point = 0;
    public int helmet_Current_Level = 0;
    [SerializeField] GameObject on_player_Helmet;
    [SerializeField] GameObject ui_ShopKeeper_Helmet;
    //Braces Item:
    public int braces_Current_Point = 0;
    public int braces_Current_Level = 0;
    [SerializeField] GameObject on_player_rightBraces;
    [SerializeField] GameObject on_player_leftBraces;
    [SerializeField] GameObject ui_ShopKeeper_Braces;

    //Pauldrons Item:
    public int pauldrons_Current_Point = 0;
    public int pauldrons_Current_Level = 0;
    [SerializeField] GameObject on_player_rightPauldrons;
    [SerializeField] GameObject on_player_leftPauldrons;
    [SerializeField] GameObject ui_ShopKeeper_Pauldrons;

    //Weapons Item:
    public int weapons_Current_Point = 0;
    public int weapons_Current_Level = 0;
    [SerializeField] GameObject on_player_rightWeapons;
    [SerializeField] GameObject on_player_leftWeapons;
    [SerializeField] GameObject ui_ShopKeeper_rightWeapons;
    [SerializeField] GameObject ui_ShopKeeper_leftWeapons;

    //Item Upgrade Add Point:
    int helmet_Add_Point;
    int braces_Add_Point;
    int pauldrons_Add_Point;
    int weapons_Add_Point;

    private void Start()
    {
        GameObject theFirstAwake = GameObject.FindGameObjectWithTag("TheFirstAwake");

        PropertyLoader();
        if (theFirstAwake.GetComponent<MainMenuOptions>().isNewGame)
        {
            char_Current_Gold = 1000;
        }
        else
        {
            this.GetComponent<UISystem>().button_LoadGame();
        }

    }
    private void Update()
    {
        StatsCalculator();
        //Set up properties:
        set_Attack();
        set_EXP();
        set_Health();
        set_Mana();
        set_LevelUp();
        set_SkillIndex();

        //Set up Item:
        set_Helmet();
        set_Braces();
        set_Pauldrons();
        set_Weapons();
        set_ItemAddPoint();
    }




    private void PropertyLoader()
    {
        using (StreamReader streamReader = new StreamReader(data_Path))
        {
            string json = streamReader.ReadToEnd();
            Chars = JsonConvert.DeserializeObject<List<IDictionary>>(json);
        }
        if (this.gameObject.tag == "Warrior")
        {
            foreach (var property in Chars)
            {
                if ((string)property["ID"] == "001")
                {
                    this.Name = (string)property["Name"];
                    this.Class = (string)property["Class"];
                    this.base_Strength = int.Parse((string)property["Strength"]);
                    this.base_Dexterity = int.Parse((string)property["Dexterity"]);
                    this.base_Intelligence = int.Parse((string)property["Intelligence"]);
                    this.base_Vitality = int.Parse((string)property["Vitality"]);
                }
            }
        }
        if (this.gameObject.tag == "Berserker")
        {
            foreach (var property in Chars)
            {
                if ((string)property["ID"] == "002")
                {
                    this.Name = (string)property["Name"];
                    this.Class = (string)property["Class"];
                    this.base_Strength = int.Parse((string)property["Strength"]);
                    this.base_Dexterity = int.Parse((string)property["Dexterity"]);
                    this.base_Intelligence = int.Parse((string)property["Intelligence"]);
                    this.base_Vitality = int.Parse((string)property["Vitality"]);
                }
            }
        }
        if (this.gameObject.tag == "Marksman")
        {
            foreach (var property in Chars)
            {
                if ((string)property["ID"] == "003")
                {
                    this.Name = (string)property["Name"];
                    this.Class = (string)property["Class"];
                    this.base_Strength = int.Parse((string)property["Strength"]);
                    this.base_Dexterity = int.Parse((string)property["Dexterity"]);
                    this.base_Intelligence = int.Parse((string)property["Intelligence"]);
                    this.base_Vitality = int.Parse((string)property["Vitality"]);
                }
            }
        }
    }

    
    private void StatsCalculator()
    {
        //Warrior:
        if (this.gameObject.tag == "Warrior")
        {
            char_Current_Strength = this.base_Strength+ char_Add_Strength+ helmet_Add_Point;
            char_Current_Dexterity = this.base_Dexterity+ char_Add_Dexterity;
            char_Current_Intelligence = this.base_Intelligence+ char_Add_Intelligence;
            char_Current_Vitality = this.base_Vitality+ char_Add_Vitality;
            char_Current_maxHealth = (int)(char_Current_Strength*5 + char_Current_Vitality*10+ pauldrons_Add_Point);
            char_Current_regHealth = (int)((char_Current_maxHealth+ braces_Add_Point) /60);
            char_Current_maxMana = (int)(char_Current_Intelligence *5+ helmet_Add_Point);
            char_Current_regMana = (int)(char_Current_maxMana /50);
            char_Current_Damage = char_Current_Strength + char_Current_Dexterity/2+ weapons_Add_Point;
            char_Current_AttackRate = (int)char_Current_Dexterity /5;

        }
    }
    private void set_Attack()
    {
        if (this.GetComponent<PlayerMovementAndAttack>())
        {

            this.GetComponent<PlayerMovementAndAttack>().attackDamage = char_Current_Damage;
            if(this.transform.tag!="Marksman")
            {
                this.GetComponent<PlayerMovementAndAttack>().attackRateMeele = char_Current_AttackRate;
            }
            else
            {
                this.GetComponent<PlayerMovementAndAttack>().attackRateRanger = char_Current_AttackRate;
            }
        }
    }


        private void set_Health()
    {
        if(this.GetComponent<HealthController>())
        {
            this.GetComponent<HealthController>().maxHealth = char_Current_maxHealth+ skill_2_maxHP;
            this.GetComponent<HealthController>().regenHealth = char_Current_regHealth+ skill_2_maxHP_regen;
        }
        
    }
    private void set_Mana()
    {
        if (this.GetComponent<ManaController>())
        {
            this.GetComponent<ManaController>().maxMana = char_Current_maxMana;
            this.GetComponent<ManaController>().regenMana = char_Current_regMana;
        }

    }
    private void set_EXP()
    {
        if (this.GetComponent<EXPController>())
        {
            this.GetComponent<EXPController>().maxEXP = char_Current_maxExp;
            this.GetComponent<EXPController>().currentEXP = char_Current_Exp;
        }

    }



    private void set_LevelUp()
    {
        if (char_Current_Exp>=char_Current_maxExp)
        {
            char_Current_Level+=1;
            char_Current_UpgradePoint+=5;
            char_Current_SkillsPoint += 1;
            char_Current_maxExp += char_Current_Level*100 +500;
        }

    }

    private void set_Helmet()
    {
        on_player_Helmet.GetComponent<WeaponLoader>().item_Level = helmet_Current_Level;
        ui_ShopKeeper_Helmet.GetComponent<WeaponLoader>().item_Level = helmet_Current_Level;
        if (helmet_Current_Point >= 5)
        {
            helmet_Current_Level += 1;
            helmet_Current_Point = 0;
        }
    }

    private void set_Braces()
    {
        on_player_rightBraces.GetComponent<WeaponLoader>().item_Level = braces_Current_Level;
        on_player_leftBraces.GetComponent<WeaponLoader>().item_Level = braces_Current_Level;
        ui_ShopKeeper_Braces.GetComponent<WeaponLoader>().item_Level = braces_Current_Level;
        if (braces_Current_Point >= 5)
        {
            braces_Current_Level += 1;
            braces_Current_Point = 0;
        }
    }

    private void set_Pauldrons()
    {
        on_player_rightPauldrons.GetComponent<WeaponLoader>().item_Level = pauldrons_Current_Level;
        on_player_leftPauldrons.GetComponent<WeaponLoader>().item_Level = pauldrons_Current_Level;
        ui_ShopKeeper_Pauldrons.GetComponent<WeaponLoader>().item_Level = pauldrons_Current_Level;
        if (pauldrons_Current_Point >= 5)
        {
            pauldrons_Current_Level += 1;
            pauldrons_Current_Point = 0;
        }
    }
    private void set_Weapons()
    {
        on_player_rightWeapons.GetComponent<WeaponLoader>().item_Level = weapons_Current_Level;
        on_player_leftWeapons.GetComponent<WeaponLoader>().item_Level = weapons_Current_Level;
        ui_ShopKeeper_rightWeapons.GetComponent<WeaponLoader>().item_Level = weapons_Current_Level;
        ui_ShopKeeper_leftWeapons.GetComponent<WeaponLoader>().item_Level = weapons_Current_Level;
        if (weapons_Current_Point >= 5)
        {
            weapons_Current_Level += 1;
            weapons_Current_Point = 0;
        }
    }
    private void set_ItemAddPoint()
    {
        helmet_Add_Point= helmet_Current_Level * 5 + helmet_Current_Point;
        braces_Add_Point= braces_Current_Level * 5 + braces_Current_Point;
        pauldrons_Add_Point= pauldrons_Current_Level * 5 + pauldrons_Current_Point;
        weapons_Add_Point= weapons_Current_Level*5+ helmet_Current_Point;
    }

    private void set_SkillIndex()
    {
        //Skill 1:
        switch (char_Current_Skill_1_Level)
        {
            case 1:
                skill_1_TimeTolive = 1;
                skill_1_deal_Damage = 50;
                break;
            case 2:
                skill_1_TimeTolive = 2;
                skill_1_deal_Damage = 100;
                break;
            case 3:
                skill_1_TimeTolive = 3;
                skill_1_deal_Damage = 200;
                break;
            default:
                skill_1_TimeTolive = 0;
                skill_1_deal_Damage = 0;
                break;
        }

        //Skill 2:
        switch (char_Current_Skill_2_Level)
        {
            case 1:
                skill_2_maxHP = 50;
                skill_2_maxHP_regen = 1;
                break;
            case 2:
                skill_2_maxHP = 100;
                skill_2_maxHP_regen = 2;
                break;
            case 3:
                skill_2_maxHP = 200;
                skill_2_maxHP_regen = 4;
                break;
            default:
                skill_2_maxHP = 0;
                skill_2_maxHP_regen = 0;
                break;
        }
        //Skill 3:
        switch (char_Current_Skill_3_Level)
        {

            case 1:
                skill_3_deal_DamagePerSecond = 50;
                break;
            case 2:
                skill_3_deal_DamagePerSecond = 100;
                break;
            case 3:
                skill_3_deal_DamagePerSecond = 150;
                break;
            default:
                skill_3_deal_DamagePerSecond = 0;
                break;
        }

        //Skill 4:
        switch (char_Current_Skill_4_Level)
        {
            case 1:
                skill_4_deal_DamagePerSword = 50;
                skill_4_TimeToLive = 10;
                break;
            case 2:
                skill_4_deal_DamagePerSword = 100;
                skill_4_TimeToLive = 15;
                break;
            case 3:
                skill_4_deal_DamagePerSword = 200;
                skill_4_TimeToLive = 20;
                break;
            default:
                skill_4_deal_DamagePerSword = 0;
                skill_4_TimeToLive = 0;
                break;
        }
    }
}
