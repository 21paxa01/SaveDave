using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_weapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;
    public GameObject awp;
    public GameObject stick;
    public GameObject rpg;
    public GameObject p_90;
    public GameObject snowgun;
    public GameObject axe;
    private bill script_bill;
    public GameObject shohtgun;
    public GameObject pistol_img, ak_47_img, shotgun_img, speeedgun_img, snowgun_img, rpg_img, stick_img, axe_img,rifle_img;
    public GameObject infantry_grenage,dynamite,ice_grenade,fire_grenage,smoke_grenage;
    public GameObject[] grenages_arr;
    public GameObject[] now_weapon;
    public static int change = 0;
    public AudioSource change_sound;
    public GameObject[] weapons;
    public GameObject shoting;
    private shoting script;
    public bool[] chek= { false,false,false,false,false,false,false,false,false};
    public bool[] g_chek = { false ,false,false,false,false};
    public bool[] reload = { true, true, true, false, true, true, false, true, true };
    private bool find;
    public static int k;
    private int l=9;
    public float test;
    public GameObject realod_button;
    private stick stick_script;
    public bool ult;
    private Save save;

    private ammo ammo_script;
    private GameObject[] ammo_arr;
    public GameObject pistol_ammo, shotgun_ammo, ak47_ammo, awp_ammo, rpg_ammo, p90_ammo, snowgun_ammo;
    void Start()
    {
        realod_button.SetActive(false);
        k = 0;
        script_bill = GetComponent<bill>();
        weapons = new GameObject[9];
        weapons[0] = pistol;weapons[1] = shohtgun;weapons[2] = p_90;weapons[3] = stick; weapons[4] = awp; weapons[5] = rpg; weapons[6] = axe; weapons[7] = ak47; weapons[8]=snowgun;
        now_weapon = new GameObject[9];
        now_weapon[0] = pistol_img;now_weapon[1] = shotgun_img;now_weapon[2] = speeedgun_img;now_weapon[3] = stick_img;now_weapon[4]=rifle_img ; now_weapon[5] = rpg_img; now_weapon[6] = axe_img; now_weapon[7] =ak_47_img;now_weapon[8] = snowgun_img;
        Chek();
        grenages_arr = new GameObject[5];
        grenages_arr[0] = infantry_grenage;grenages_arr[1] = dynamite;grenages_arr[2] = ice_grenade;grenages_arr[3] = fire_grenage;grenages_arr[4] = smoke_grenage;
        stick_script = stick.GetComponent<stick>();
        save=GameObject.Find("save").GetComponent<Save>();
        ammo_arr = new GameObject[7];
        ammo_arr[0] = pistol_ammo; ammo_arr[1] = shotgun_ammo; ammo_arr[5] = ak47_ammo; ammo_arr[4] = rpg_ammo; ammo_arr[2] = p90_ammo; ammo_arr[6] = snowgun_ammo; ammo_arr[3] = awp_ammo;
    }

    
    void Update()
    {
        if(ult==false)
            shoting= weapons[change];
    }
    public int button_i;
    public void Change()
    {
        if (reload[change] == true)
            realod_button.SetActive(true);
        else
            realod_button.SetActive(false);
        script.stop = false;
        change_sound.Play();
    }
    public void update()
    {
        stick_script.inventory = false;
        for(int i = 0; i < 9; i++)
        {
            if (chek[i] == true&&reload[i]==true)
            {
                script = weapons[i].GetComponent<shoting>();
                script.ReloaD = false;
                script.reload = 0;
                script.stop = false;
            }
        }
    }
    void Chek()
    {
        for(int i = 0; i < 7; i++)
        {
            if (chek[i] == true)
            {
                script_bill.weapon_chek = true;
                break;
            }
        }
    }
    private bool testik;
    public void Activate_weapon()
    {
        testik = false;
        for(int i = 0; i < 9; i++)
        {
            weapons[i].SetActive(false);
            now_weapon[i].SetActive(false);
            if (chek[i] == true&&testik==false)
            {
                testik = true;
                weapons[i].SetActive(true);
                now_weapon[i].SetActive(true);
                change = i;
            }
        }
    }
    private int kef;
    public void ChangeStats()
    {
        kef = 0;
        save.Load_upgrade();
        for (int i = 0; i < 9; i++)
        {
            if (reload[i] == true)
            {
                ammo_script = ammo_arr[i-kef].GetComponent<ammo>();
                script = weapons[i].GetComponent<shoting>();
                ammo_script.ammo_damage = ammo_script.default_damage + ammo_script.default_damage * (float)save.save_damage_count[i-kef]/5;
                script.Ammunition = script.DefaultAmmunition + script.DefaultAmmunition * (float)save.save_ammunition_count[i-kef]/5;
                script.startTime = script.DefaultstartTime * (1-(float)save.save_reload_count[i-kef]/10);
            }
            else
                kef++;
        }
    }
    public void Reload()
    {
        script = weapons[change].GetComponent<shoting>();
        if (script.reload < script.Ammunition)
        {
            script.reload = script.Ammunition;
            script.Shot();
        }
    }
    public void Reload_chek()
    {
        if (reload[change] == true)
            realod_button.SetActive(true);
        else
            realod_button.SetActive(false);
    }
}
