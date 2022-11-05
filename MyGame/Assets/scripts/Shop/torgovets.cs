using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class torgovets : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject SkinsMenu;
    public GameObject WeaponsMenu,Granades_menu;
    public GameObject ChoiseMenu;
    public GameObject WeaponsChoiseMenu,GrenadesChoiseMenu,SkinsChoiceMenu;
    public GameObject capsul_1,capsul_2,capsul_3,skin_1, skin_2, skin_3;
    public GameObject travler,punk,zombie;
    private GameObject[] now_skins;
    private int[] now_skins_ind= { 0,0,0};
    private GameObject[] skins_arr;
    public GameObject fon;
    public GameObject shotgun, ak47, rpg, p90, snowgun, stick, axe,awp;
    public GameObject l_shotgun, l_ak47, l_rpg, l_p90, l_snowgun, l_stick, l_axe, l_awp;
    public SpriteRenderer sp;
    public GameObject little_granade,dynamite,ice_grenade,fire_grenage,smoke_grenage;
    public GameObject l_little_granade, l_dynamite, l_ice_grenade, l_fire_grenage, l_smoke_grenage;
    public SpriteRenderer weap_sp;
    public static bool shop;
    private float[] x_arr = { 0.87f, 1.3f, 1.7f };
    private float[] y_arr ={ 0.35f,0.275f,0.425f };
    private GameObject[] capsul_arr;
    private GameObject[] weapons_arr, l_weapons_arr;
    private GameObject[] granades_arr, l_granades_arr;
    private int[] w_prise_arr = { 150,300,50,200,200,100,250,350};
    private string[] w_range_arr = { "short","middle", "short","long", "middle", "middle", "middle", "short" };
    private string[] w_info_arr = { " ", "the time between shots decreases as the weapon is used", "","", "rockets are bought separately for each round", "  ", "", "gun ammo slows down zombies" };
    private float[] w_damage_arr = { 30f,10f,10f,40f,60f,10f,10f,15f };
    private string[] w_reload_arr = { "1.5", "3/1.5","0.4","1f","3","0.2","0.1","0.5" };
    private float[] w_ammunition_arr = { 15f, 45f,1f,5f,1f,1f,30f,20f };
    private string[] w_name_arr = { "raptor", "speedgun", "a cool stick","rifle", "RPG", "axe", "marauder","snowgun" };
    private int[] g_prise_arr = { 150,400,300,400,500};
    private string[] g_range_arr = { "short","middle","middle","middle", "middle" };
    private string[] g_info_arr = { "boom" ,"BOOOOM","boom and FREEZE","FIIIIRE", "smoke" };
    private float[] g_damage_arr = {50f,100f,10f,0f,0f};
    private string[] g_reload_arr = {"7","15","12","13", "20" };
    private float[] g_ammunition_arr = {1f,1f,1f,1f,1f};
    private string[] g_name_arr = { "infantry \n granade","dynamite","ice \n grenade","fire\n grenage", "smoke\n grenage" };
    private int[] s_prise_arr = { 200, 300, 400 };
    private string[] s_name_arr = {"toxic","punk","zombie" };

    private int weap_kol;

    public Text w_prise;
    public Text buy_prise;
    public Text w_range;
    public Text w_damage;
    public Text w_reload;
    public Text w_ammunition;
    public Text w_name;
    public Text w_info;

    public Text g_prise, g_range, g_damage, g_reload, g_ammunition, g_name, g_info;
    public Text s_prise, s_name;

    private int i;
    public int j;
    public  float[] buy_arr = { 1, 0, 0, 0, 0, 0,0 };
    public int[] prise_arr = { 40, 0, 0, 0, 0, 0,0 };

    public float[] g_buy_arr = { 0, 0, 0, 0, 0, 0, 0 };

    public Save save_script;
    private bill bill;
    public Inventory script;
    public GameObject choise_text;
    private Text text;
    private typewriter text_scr;
    private MoneyCount MoneyCount;

    public GameObject w_buy_button, s_buy_button, g_buy_button;
    public GameObject w_mon,w_lock_img, w_lock_text, g_mon, g_lock_img, g_lock_text;
    void Start()
    {
        save_script = GameObject.Find("save").GetComponent<Save>();
        save_script.Load_weapon();
        save_script.Load_grenades();
        save_script.Load_skins();
        buy_arr = save_script.w_buy_arr;
        prise_arr = save_script.w_prise_arr;
        g_buy_arr= save_script.g_buy_arr;
        weap_kol = save_script.weapon_kol;
        capsul_arr = new GameObject[3];
        capsul_arr[0] = capsul_1;capsul_arr[1] = capsul_2;capsul_arr[2] = capsul_3;
        weapons_arr = new GameObject[8];
        weapons_arr[0] = shotgun; weapons_arr[1] = p90; weapons_arr[2] = stick; weapons_arr[3] = awp; weapons_arr[4] = rpg; weapons_arr[5] = axe; weapons_arr[6] = ak47; weapons_arr[7] = snowgun;
        l_weapons_arr = new GameObject[8];
        l_weapons_arr[0] = l_shotgun; l_weapons_arr[1] = l_p90; l_weapons_arr[2] = l_stick; l_weapons_arr[3] = l_awp; l_weapons_arr[4] = l_rpg; l_weapons_arr[5] = l_axe; l_weapons_arr[6] = l_ak47; l_weapons_arr[7] = l_snowgun;
        granades_arr = new GameObject[5];
        granades_arr[0] = little_granade;granades_arr[1] = dynamite;granades_arr[2] = ice_grenade;granades_arr[3] = fire_grenage;granades_arr[4] = smoke_grenage;
        j = 0;
        l_granades_arr = new GameObject[5];
        l_granades_arr[0] = l_little_granade; l_granades_arr[1] = l_dynamite; l_granades_arr[2] = l_ice_grenade; l_granades_arr[3] = l_fire_grenage; l_granades_arr[4] = l_smoke_grenage;
        weapons_arr[j].SetActive(true);
        weap_sp = weapons_arr[j].GetComponent<SpriteRenderer>();
        weap_sp.sortingOrder = 3;
        skins_arr = new GameObject[3];
        skins_arr[0] = travler;skins_arr[1] = punk;skins_arr[2] = zombie;
        now_skins = new GameObject[3];
        now_skins[0] = skin_1;now_skins[1] = skin_2;now_skins[2] = skin_3;
        Update_Skins();
        bill = GameObject.Find("Bill").GetComponent<bill>();
        text = choise_text.GetComponent<Text>();
        text_scr = choise_text.GetComponent<typewriter>();
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
    }
    void Update()
    {
        if (shop == true)
        {
            ShopMenu.SetActive(true);
            fon.SetActive(true);
        }
        else
        {
            ShopMenu.SetActive(false);
            fon.SetActive(false);
        }
    }
    public void Skins()
    {
        if (save_script.s_buy_arr[now_skins_ind[i] + 1] == 0)
            s_buy_button.SetActive(true);
        else
            s_buy_button.SetActive(false);
        sp = capsul_arr[0].GetComponent<SpriteRenderer>();
        i = 0;
        //sp.sortingOrder = 21;
        //sp = now_skins[0].GetComponent<SpriteRenderer>();
        //sp.sortingOrder = 22;
        skins_arr[now_skins_ind[i]].SetActive(true);
        SkinsMenu.SetActive(true);
        s_name = GameObject.Find("s_name").GetComponent<Text>();
        s_prise = GameObject.Find("s_prise").GetComponent<Text>();
        s_name.text = s_name_arr[now_skins_ind[i]];
        s_prise.text = s_prise_arr[now_skins_ind[i]].ToString();
        //ShopCamera.x = 0.87f;
        //ShopCamera.y=0.35f;
        //ZoomCamera.zoom = 0.3f;
        ChoiseMenu.SetActive(false);
    }
    public void Weapons()
    {
        if (save_script.w_buy_arr[j + 1] == 0)
            w_buy_button.SetActive(true);
        else
            w_buy_button.SetActive(false);
        if (j<2)
            granades_arr[j].SetActive(false);
        j = 0;
        weap_sp = weapons_arr[j].GetComponent<SpriteRenderer>();
        weap_sp.sortingOrder = 22;
        weapons_arr[j].SetActive(true);
        sp = capsul_arr[0].GetComponent<SpriteRenderer>();
        WeaponsMenu.SetActive(true);
        w_prise = GameObject.Find("prise").GetComponent<Text>();
        w_range = GameObject.Find("range").GetComponent<Text>();
        w_damage = GameObject.Find("damage").GetComponent<Text>();
        w_reload = GameObject.Find("reload").GetComponent<Text>();
        w_info = GameObject.Find("info").GetComponent<Text>();
        w_ammunition = GameObject.Find("ammunition").GetComponent<Text>();
        w_name = GameObject.Find("name").GetComponent<Text>();
        w_prise.text = w_prise_arr[j].ToString();
        w_name.text = w_name_arr[j].ToString();
        w_range.text = w_range_arr[j].ToString();
        w_damage.text = w_damage_arr[j].ToString();
        w_reload.text = w_reload_arr[j].ToString();
        w_info.text = w_info_arr[j].ToString();
        w_ammunition.text = w_ammunition_arr[j].ToString();
        ShopCamera.x = -0.85f;
        ShopCamera.y = 0.5f;
        ZoomCamera.zoom = 0.37f;
        Granades_menu.SetActive(false);
        ChoiseMenu.SetActive(false);
    }
    public void Granades()
    {
        if (save_script.g_buy_arr[j] == 0)
            g_buy_button.SetActive(true);
        else
            g_buy_button.SetActive(false);
        weapons_arr[j].SetActive(false);
        l_weapons_arr[j].SetActive(false);
        j = 0;
        granades_arr[j].SetActive(true);
        Granades_menu.SetActive(true);
        WeaponsMenu.SetActive(false);
        g_prise = GameObject.Find("g_prise").GetComponent<Text>();
        g_range = GameObject.Find("g_range").GetComponent<Text>();
        g_damage = GameObject.Find("g_damage").GetComponent<Text>();
        g_reload = GameObject.Find("g_reload").GetComponent<Text>();
        g_info = GameObject.Find("g_info").GetComponent<Text>();
        g_ammunition = GameObject.Find("g_ammunition").GetComponent<Text>();
        g_name = GameObject.Find("g_name").GetComponent<Text>();
        g_prise.text = g_prise_arr[j].ToString();
        g_name.text = g_name_arr[j].ToString();
        g_range.text = g_range_arr[j].ToString();
        g_damage.text = g_damage_arr[j].ToString();
        g_reload.text = g_reload_arr[j].ToString();
        g_info.text = g_info_arr[j].ToString();
        g_ammunition.text = g_ammunition_arr[j].ToString();
    }
    public void BackToChoise()
    {
        SkinsMenu.SetActive(false);
        skins_arr[now_skins_ind[i]].SetActive(false);
        WeaponsMenu.SetActive(false);
        Granades_menu.SetActive(false);
        weapons_arr[j].SetActive(false);
        l_weapons_arr[j].SetActive(false);
        text.text = text_scr.text;
        if (j < 5)
            granades_arr[j].SetActive(false);
        if (i < 3)
        {
            sp = capsul_arr[i].GetComponent<SpriteRenderer>();
            sp.sortingOrder = 1;
            sp = now_skins[i].GetComponent<SpriteRenderer>();
            sp.sortingOrder = 3;
        }
        weapons_arr[0].SetActive(true);
        weap_sp = weapons_arr[0].GetComponent<SpriteRenderer>();
        weap_sp.sortingOrder = 3;
        ShopCamera.x = 0f;
        ZoomCamera.zoom = 0.7f;
        ShopCamera.y = 0.2f;
        ChoiseMenu.SetActive(true);
    }
    public void ShopOff()
    {
        shop = false;
        bill.stop = false;
    }
    public void Skins_left()
    {
        /*sp = capsul_arr[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 1;
        sp = now_skins[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 2;
        */
        skins_arr[now_skins_ind[i]].SetActive(false);
        i--;
        if (i == -1)  
            i = 2;
        if (save_script.s_buy_arr[now_skins_ind[i] + 1] == 0)
            s_buy_button.SetActive(true);
        else
            s_buy_button.SetActive(false);
        skins_arr[now_skins_ind[i]].SetActive(true);
        s_name.text = s_name_arr[now_skins_ind[i]];
        s_prise.text = s_prise_arr[now_skins_ind[i]].ToString();
        /*sp = capsul_arr[i].GetComponent<SpriteRenderer>(); 
        sp.sortingOrder = 21;
        sp = now_skins[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 22;
        ShopCamera.x = x_arr[i];
        ShopCamera.y = y_arr[i];
    */}
    public void Skins_right()
    {
        /*sp = capsul_arr[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 1;
        sp = now_skins[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 2;
        */
        skins_arr[now_skins_ind[i]].SetActive(false);
        i++;
        if (i == 3)
            i = 0;
        if (save_script.s_buy_arr[now_skins_ind[i] + 1] == 0)
            s_buy_button.SetActive(true);
        else
            s_buy_button.SetActive(false);
        skins_arr[now_skins_ind[i]].SetActive(true);
        s_name.text = s_name_arr[now_skins_ind[i]];
        s_prise.text = s_prise_arr[now_skins_ind[i]].ToString();
        /*sp = capsul_arr[i].GetComponent<SpriteRenderer>(); 
        sp.sortingOrder = 21;
        sp = now_skins[i].GetComponent<SpriteRenderer>();
        sp.sortingOrder = 22;
        ShopCamera.x = x_arr[i];
        ShopCamera.y = y_arr[i];
*/
    }
    public void Weapons_rigth()
    {
        weapons_arr[j].SetActive(false);
        l_weapons_arr[j].SetActive(false);
        j++;
        if (j == weap_kol+3||j==8)
            j = 0;
        if (j < weap_kol)
        {
            w_mon.SetActive(true);
            w_lock_img.SetActive(false);
            w_lock_text.SetActive(false);
            weapons_arr[j].SetActive(true);
            w_prise.text = w_prise_arr[j].ToString();
            w_name.text = w_name_arr[j].ToString();
            w_range.text = w_range_arr[j].ToString();
            w_damage.text = w_damage_arr[j].ToString();
            w_reload.text = w_reload_arr[j].ToString();
            w_ammunition.text = w_ammunition_arr[j].ToString();
            w_info.text = w_info_arr[j].ToString();
            if (save_script.w_buy_arr[j+1] == 0)
                w_buy_button.SetActive(true);
            else
                w_buy_button.SetActive(false);
        }
        else
        {
            w_mon.SetActive(false);
            w_lock_img.SetActive(true);
            w_lock_text.SetActive(true);
            l_weapons_arr[j].SetActive(true);
            w_prise.text = "";
            w_name.text = "";
            w_range.text = "?";
            w_damage.text = "?";
            w_reload.text = "?";
            w_ammunition.text = "?";
            w_info.text = "";
            w_buy_button.SetActive(false);
        }
    }
    public void Weapons_left()
    {
        weapons_arr[j].SetActive(false);
        l_weapons_arr[j].SetActive(false);
        j--;
        if (j == -1)
            j = weap_kol-1;
        if (j < weap_kol)
        {
            w_mon.SetActive(true);
            w_lock_img.SetActive(false);
            w_lock_text.SetActive(false);
            weapons_arr[j].SetActive(true);
            w_prise.text = w_prise_arr[j].ToString();
            w_name.text = w_name_arr[j].ToString();
            w_range.text = w_range_arr[j].ToString();
            w_damage.text = w_damage_arr[j].ToString();
            w_reload.text = w_reload_arr[j].ToString();
            w_ammunition.text = w_ammunition_arr[j].ToString();
            w_info.text = w_info_arr[j].ToString();
            if (save_script.w_buy_arr[j+1] == 0)
                w_buy_button.SetActive(true);
            else
                w_buy_button.SetActive(false);
        }
        else
        {
            w_mon.SetActive(false);
            w_lock_img.SetActive(true);
            w_lock_text.SetActive(true);
            l_weapons_arr[j].SetActive(true);
            w_prise.text = "";
            w_name.text = "";
            w_range.text = "?";
            w_damage.text = "?";
            w_reload.text = "?";
            w_ammunition.text = "?";
            w_info.text = "";
            w_buy_button.SetActive(false);
        }
    }
    public void Grenades_right() 
    {
        granades_arr[j].SetActive(false);
        l_granades_arr[j].SetActive(false);
        j++;
        if (j ==save_script.grenades_kol+3||j==5)
            j = 0;
        if (j < save_script.grenades_kol)
        {
            if (save_script.g_buy_arr[j] == 0)
                g_buy_button.SetActive(true);
            else
                g_buy_button.SetActive(false);
            granades_arr[j].SetActive(true);
            g_prise.text = g_prise_arr[j].ToString();
            g_name.text = g_name_arr[j].ToString();
            g_range.text = g_range_arr[j].ToString();
            g_damage.text = g_damage_arr[j].ToString();
            g_reload.text = g_reload_arr[j].ToString();
            g_info.text = g_info_arr[j].ToString();
            g_mon.SetActive(true);
            g_lock_img.SetActive(false);
            g_lock_text.SetActive(false);
        }
        else
        {
            g_buy_button.SetActive(false);
            l_granades_arr[j].SetActive(true);
            g_prise.text = "";
            g_name.text = "";
            g_range.text = "?";
            g_damage.text = "?";
            g_reload.text = "?";
            g_info.text = "";
            g_mon.SetActive(false);
            g_lock_img.SetActive(true);
            g_lock_text.SetActive(true);
        }
    }
    public void Grenades_left() 
    {
        granades_arr[j].SetActive(false);
        l_granades_arr[j].SetActive(false);
        j--;
        if (j < 0)
            j = save_script.grenades_kol-1;
        if (j < save_script.grenades_kol)
        {
            if (save_script.g_buy_arr[j] == 0)
                g_buy_button.SetActive(true);
            else
                g_buy_button.SetActive(false);
            granades_arr[j].SetActive(true);
            g_prise.text = g_prise_arr[j].ToString();
            g_name.text = g_name_arr[j].ToString();
            g_range.text = g_range_arr[j].ToString();
            g_damage.text = g_damage_arr[j].ToString();
            g_reload.text = g_reload_arr[j].ToString();
            g_info.text = g_info_arr[j].ToString();
            g_mon.SetActive(true);
            g_lock_img.SetActive(false);
            g_lock_text.SetActive(false);
        }
        else
        {
            g_buy_button.SetActive(false);
            l_granades_arr[j].SetActive(true);
            g_prise.text = "";
            g_name.text = "";
            g_range.text = "?";
            g_damage.text = "?";
            g_reload.text = "?";
            g_info.text = "";
            g_mon.SetActive(false);
            g_lock_img.SetActive(true);
            g_lock_text.SetActive(true);
        }
    }
    public void Buy_weapon()
    {
        if (save_script.w_buy_arr[j + 1]==0&&MoneyCount.mon>=w_prise_arr[j])
        {
            MoneyCount.mon -= w_prise_arr[j];
            MoneyCount.Save();
            script = GameObject.Find("Home_Canvas").GetComponent<Inventory>();
            script.i = j+1;
            save_script.inv_j++;
            save_script.w_buy_arr[j + 1] = 1;
            save_script.w_prise_arr[j + 1] = ((int)(w_prise_arr[j] * 0.4f));
            save_script.save_cell_ind_arr[save_script.inv_j] = j + 1;
            save_script.Save_weapon();
            save_script.Load_weapon();
            script.NewWeapon();
            w_buy_button.SetActive(false);
        }
        WeaponsChoiseMenu.SetActive(false);
    }
    public void Weapon_Buy_Or_Not()
    {
        WeaponsChoiseMenu.SetActive(true);
        buy_prise= GameObject.Find("buy_prise").GetComponent<Text>();
        buy_prise.text = w_prise_arr[j].ToString()+"?";

    }
    public void BackToWeapons()
    {
        WeaponsChoiseMenu.SetActive(false);
    }
    public void Grenades_Buy_Or_Not()
    {
        GrenadesChoiseMenu.SetActive(true);
        buy_prise = GameObject.Find("g_buy_prise").GetComponent<Text>();
        buy_prise.text = g_prise_arr[j].ToString() + "?";

    }
    public void BackToGrenades()
    {
        GrenadesChoiseMenu.SetActive(false);
    }
    public void Skins_Buy_Or_Not()
    {
        SkinsChoiceMenu.SetActive(true);
        buy_prise = GameObject.Find("s_buy_prise").GetComponent<Text>();
        buy_prise.text = s_prise_arr[now_skins_ind[i]].ToString() + "?";
    }
    public void BackToSkins()
    {
        SkinsChoiceMenu.SetActive(false);
    }
    public void Buy_granades()
    {
        if (save_script.g_buy_arr[j] == 0 && MoneyCount.mon >= g_prise_arr[j])
        {
            MoneyCount.mon -= g_prise_arr[j];
            MoneyCount.Save();
            script = GameObject.Find("Home_Canvas").GetComponent<Inventory>();
            script.i = j;
            save_script.inv_k++;
            save_script.g_buy_arr[j] = 1;
            save_script.save_g_cell_ind_arr[save_script.inv_k] = j;
            save_script.Save_grenades();
            save_script.Load_grenades();
            script.NewGrenade();
            g_buy_button.SetActive(false);
        }
        GrenadesChoiseMenu.SetActive(false);
    }
    public void Buy_skins()
    {
        if (save_script.s_buy_arr[now_skins_ind[i]] == 0 && MoneyCount.mon >= s_prise_arr[now_skins_ind[i]])
        {
            MoneyCount.mon -= s_prise_arr[now_skins_ind[i]];
            MoneyCount.Save();
            script = GameObject.Find("Home_Canvas").GetComponent<Inventory>();
            script.s_i = now_skins_ind[i] + 1;
            save_script.s_buy_arr[now_skins_ind[i]] = 1;
            save_script.inv_s++;
            save_script.save_s_cell_ind_arr[save_script.inv_s] = now_skins_ind[i] + 1;
            save_script.Save_skins();
            save_script.Load_skins();
            script.NewSkin();
            s_buy_button.SetActive(false);
        }
        SkinsChoiceMenu.SetActive(false);
    }
    private int k;
    private Image img;
    public void Update_Skins()
    {
        for (int x = 0; x < 3; x++)
        {
            now_skins_ind[x] = -1;
            do
            {
                k = Random.Range(0, 3);
            } while (now_skins_ind[0] == k || now_skins_ind[1] == k || now_skins_ind[2] == k);
            now_skins_ind[x] = k;
            sp=now_skins[x].GetComponent<SpriteRenderer>();
            sp.sprite = skins_arr[k].GetComponent<Image>().sprite;
        }
    }
}