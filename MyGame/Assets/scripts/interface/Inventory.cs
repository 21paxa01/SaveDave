using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Inventory_menu;
    public GameObject[] weapons_arr;
    public GameObject[] grenades_arr;
    public GameObject[] skins_arr;
    public GameObject[] now_skin;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject ak_47;
    public GameObject rpg;
    public GameObject p_90;
    public GameObject snowgun;
    public GameObject stick;
    public GameObject axe;
    public GameObject rifle;
    public GameObject punk, travler, defoalt,zombie;
    public GameObject inv_punk, inv_skin_1, inv_bill,inv_zombie;
    public GameObject infantry_grenade,dynamite,ice_grenade,fire_grenage,smoke_grenage;
    public bool clear;
    public GameObject fon;
    public int i;
    public int s_i;
    private int j = 0;
    private int k = 0, w, s, t, g;
    public Image img;
    public int[] now_weapon;
    public GameObject[] cells_arr, g_cells_arr,s_cells_arr,blue_light_arr;
    public int[] cell_ind_arr = { 0, 0, 0, 0, 0, 0,0,0,0 };
    public int[] g_cell_ind_arr = { 0, 0, 0, 0, 0, 0 };
    public int[] s_cell_ind_arr = { 0, 0, 0, 0, 0, 0 };
    public GameObject w_light_1, w_light_2, w_light_3, w_light_4, w_light_5, w_light_6, w_light_7, w_light_8, w_light_9;
    private GameObject[] w_light;
    private GameObject[] g_light;
    private GameObject[] s_light;
    public GameObject blue_light_1, blue_light_2, blue_light_3, blue_light_4, blue_light_5, blue_light_6, blue_light_7, blue_light_8;
    public GameObject g_light_1, g_light_2, g_light_3, g_light_4, g_light_5;
    public GameObject s_light_1, s_light_2, s_light_3, s_light_4;
    public Image weapon_sprite,grenade_sprite;
    public SpriteRenderer skin_sprite;
    public Image cell_sprite,g_cell_sprite,s_cell_sprite;
    public inventory_weapon script;
    public inventory_grenade g_script;
    public inventory_skin s_script;
    public Save save_script;
    public GameObject cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9;
    public GameObject g_cell1, g_cell2, g_cell3, g_cell4, g_cell5, g_cell6;
    public GameObject s_cell1, s_cell2, s_cell3, s_cell4, s_cell5, s_cell6;
    private string[] category = { "weapon", "skins", "grenade" };
    public int category_i;
    public GameObject cat_text;
    private Text category_text;
    private change_weapon change_weapon;
    public SpriteRenderer bill_sprite;
    public bill bill;

    public GameObject weapons_menu;
    public GameObject skins_menu;
    public GameObject granage_menu;
    public GameObject traps_menu;
    public bool stop;
    void Start()
    {
        fon.SetActive(false);
        w_light = new GameObject[9];
        w_light[0] = w_light_1; w_light[1] = w_light_2; w_light[2] = w_light_3; w_light[3] = w_light_4; w_light[4] = w_light_5; w_light[5] = w_light_6; w_light[6] = w_light_7; w_light[7] = w_light_8; w_light[8] = w_light_9;
        g_light = new GameObject[5];
        g_light[0] = g_light_1; g_light[1] = g_light_2; g_light[2] = g_light_3; g_light[3] = g_light_4; g_light[4] = g_light_5;
        s_light = new GameObject[4];
        s_light[0] = s_light_1; s_light[1] = s_light_2; s_light[2] = s_light_3; s_light[3] = s_light_4; 
        category_i = 0;
        //category_text = cat_text.GetComponent<Text>();
        save_script = GameObject.Find("save").GetComponent<Save>();
        change_weapon = GameObject.Find("Bill").GetComponent<change_weapon>();
        save_script.Load_weapon();
        save_script.Load_grenades();
        save_script.Load_skins();
        j = save_script.inv_j;
        k = save_script.inv_k;
        s = save_script.inv_s;
        now_weapon = new int[2];
        now_weapon[0]=-1; now_weapon[1] = -1;
        i = 0;
        bill_sprite = GameObject.Find("Bill").GetComponent<SpriteRenderer>();
        weapons_arr = new GameObject[9];
        weapons_arr[0] = pistol;weapons_arr[1] = shotgun;weapons_arr[2] = p_90; weapons_arr[3] = stick;weapons_arr[4]=rifle ; weapons_arr[5] = rpg; weapons_arr[6] = axe; weapons_arr[7] = ak_47; weapons_arr[8] = snowgun;
        cells_arr = new GameObject[9];
        cells_arr[0] = cell1;cells_arr[1] = cell2; cells_arr[2] = cell3; cells_arr[3] = cell4; cells_arr[4] = cell5; cells_arr[5] = cell6; cells_arr[6] = cell7; cells_arr[7] = cell8; cells_arr[8] = cell9;
        g_cells_arr = new GameObject[6];
        g_cells_arr[0] = g_cell1; g_cells_arr[1] = g_cell2; g_cells_arr[2] = g_cell3; g_cells_arr[3] = g_cell4; g_cells_arr[4] = g_cell5; g_cells_arr[5] = g_cell6;
        grenades_arr = new GameObject[5];
        grenades_arr[0] = infantry_grenade;grenades_arr[1] = dynamite;grenades_arr[2] = ice_grenade;grenades_arr[3] = fire_grenage;grenades_arr[4] = smoke_grenage;
        skins_arr = new GameObject[4];
        skins_arr[0]=defoalt; skins_arr[1] = travler;skins_arr[2] = punk;skins_arr[3] = zombie;
        now_skin = new GameObject[4];
        now_skin[0] = inv_bill;now_skin[1] = inv_skin_1;now_skin[2] = inv_punk;now_skin[3] = inv_zombie;
        s_cells_arr = new GameObject[6];
        s_cells_arr[0] = s_cell1; s_cells_arr[1] = s_cell2; s_cells_arr[2] = s_cell3; s_cells_arr[3] = s_cell4; s_cells_arr[4] = s_cell5; s_cells_arr[5] = s_cell6;
        bill = GameObject.Find("Bill").GetComponent<bill>();
        weapon_trans = weapon_category.GetComponent<RectTransform>();
        skins_trans= skins_category.GetComponent<RectTransform>();
        traps_trans= traps_category.GetComponent<RectTransform>();
        granage_trans= granage_category.GetComponent<RectTransform>();
        cells = new GameObject[12];
        cells[0] = weapon_cell_1;cells[1] = weapon_cell_2;cells[2] = weapon_cell_3;cells[3] = skins_cell_1;cells[4] = skins_cell_2;cells[5] = skins_cell_3;cells[6] = traps_cell_1;cells[7] = traps_cell_2;cells[8] = traps_cell_3;cells[9] = granage_cell_1;cells[10] = granage_cell_2;cells[11] = granage_cell_3;
        cells_pos = new float[12,2];
        for(int k = 0; k < 12; k++)
        {
            cell = cells[k].GetComponent<RectTransform>();
            cells_pos[k,0] = cell.anchoredPosition.x;cells_pos[k,1] = cell.anchoredPosition.y;
        }
        blue_light_arr = new GameObject[8];
        blue_light_arr[0] = blue_light_1; blue_light_arr[1] = blue_light_2; blue_light_arr[2] = blue_light_3; blue_light_arr[3] = blue_light_4; blue_light_arr[4] = blue_light_5; blue_light_arr[5] = blue_light_6; blue_light_arr[6] = blue_light_7; blue_light_arr[7] = blue_light_8;
        Weapon();
        skin_ind = 0;
        s_i = 0;
        bill.s_i = 0;
    }

    void Update()
    {
        //category_text.text = category[category_i];   
    }
    public void Inventory_ON()
    {
        Inventory_menu.SetActive(true);
        bill_sprite.sortingOrder = 16;
        fon.SetActive(true);
        clear = true;
        bill.stop = true;
        bill.rb.velocity = new Vector2(0f, 0f);
        bill.transform.position = new Vector3(6.5f, bill.transform.position.y, bill.transform.position.z);
        ZoomCamera.zoom = 0.4f;
        bill.weapons.SetActive(true);
    }
    public void Inventory_OFF()
    {
        Inventory_menu.SetActive(false);
        fon.SetActive(false);
        bill_sprite.sortingOrder = 9;
        ZoomCamera.zoom = 0.7f;
        bill.stop = false;
        bill.weapons.SetActive(false);
        for (int i = 0; i < 9; i++)
            change_weapon.weapons[i].SetActive(false);
    }
    public void Weapon_OFF()
    {
        weapons_arr[i].SetActive(false);
    }
    public void Weapon_ON()
    {
        weapons_arr[i].SetActive(true);
        img = weapons_arr[i].GetComponent<Image>();
    }
    public void Grenade_OFF()
    {
        grenades_arr[i].SetActive(false);
    }
    public void Grenade_ON()
    {
        grenades_arr[i].SetActive(true);
        for (int x = 0; x < 5; x++) {
            if (g_cell_ind_arr[x] == i)
            {
                img = g_cells_arr[x].GetComponent<Image>();
                break;
            } 
        }
    }
    public void Skin_OFF()
    {
        for (int x = 0; x <= s; x++)
            now_skin[x].SetActive(false);
    }
    private int skin_ind;
    public void Active_Skin()
    {
        skins_arr[skin_ind].SetActive(false);
        skin_ind = s_i;
        skins_arr[skin_ind].SetActive(true);
        bill.s_i = skin_ind;
    }
    public void Skin_ON()
    {
        now_skin[s_i].SetActive(true);
        img = now_skin[s_i].GetComponent<Image>();
    }
    public void NewWeapon()
    {
        save_script.Load_weapon();
        j = save_script.inv_j;
        ChekSells();
        script = cells_arr[j].GetComponent<inventory_weapon>();
        script.i = i;
        cell_sprite = cells_arr[j].GetComponent<Image>();
        weapon_sprite = weapons_arr[i].GetComponent<Image>();
        cell_sprite.sprite = weapon_sprite.sprite;
    }
    public void NewGrenade()
    {
        save_script.Load_grenades();
        k = save_script.inv_k;
        ChekGrenadeSells();
        g_script = g_cells_arr[k].GetComponent<inventory_grenade>();
        g_script.i = i;
        g_cell_sprite = g_cells_arr[k].GetComponent<Image>();
        grenade_sprite = grenades_arr[i].GetComponent<Image>();
        g_cell_sprite.sprite = grenade_sprite.sprite;
    }
    public void NewSkin()
    {
        save_script.Load_skins();
        s = save_script.inv_s;
        ChekSkinsCells();

    }
    public void ChekSells()
    {
        for (int x = 0; x <= j; x++)
        {
            cell_ind_arr = save_script.save_cell_ind_arr;
            cells_arr[x].SetActive(true);
            script = cells_arr[x].GetComponent<inventory_weapon>();
            script.i = cell_ind_arr[x];
            cell_sprite = cells_arr[x].GetComponent<Image>();
            weapon_sprite = weapons_arr[script.i].GetComponent<Image>();
            cell_sprite.sprite = weapon_sprite.sprite;
        }
    }
    public void ChekGrenadeSells()
    {
        for (int x = 0; x <= k; x++)
        {
            g_cell_ind_arr = save_script.save_g_cell_ind_arr;
            g_cells_arr[x].SetActive(true);
            g_script = g_cells_arr[x].GetComponent<inventory_grenade>();
            g_script.i = g_cell_ind_arr[x];
            g_cell_sprite = g_cells_arr[x].GetComponent<Image>();
            grenade_sprite = grenades_arr[g_script.i].GetComponent<Image>();
            g_cell_sprite.sprite = grenade_sprite.sprite;
        }
    }
    public void ChekSkinsCells()
    {
        for(int x = 0; x <= s; x++)
        {
            s_cell_ind_arr = save_script.save_s_cell_ind_arr;
            s_cells_arr[x].SetActive(true);
            s_script = s_cells_arr[x].GetComponent<inventory_skin>();
            s_script.i = s_cell_ind_arr[x];
            s_cell_sprite = s_cells_arr[x].GetComponent<Image>();
            skin_sprite = skins_arr[s_script.i].GetComponent<SpriteRenderer>();
            s_cell_sprite.sprite = skin_sprite.sprite;
        }
    }
    public GameObject weapon_light;
    public GameObject skins_light;
    public GameObject traps_light;
    public GameObject granage_light;
    private RectTransform weapon_trans;
    private RectTransform skins_trans;
    private RectTransform traps_trans;
    private RectTransform granage_trans;
    public GameObject weapon_category;
    public GameObject skins_category;
    public GameObject traps_category;
    public GameObject granage_category;
    public void Light_off()
    {
        for (int i = 0; i < 9; i++)
            w_light[i].SetActive(false);
        for (int i = 0; i < 5; i++)
            g_light[i].SetActive(false);
        for (int i = 0; i < 4; i++)
            s_light[i].SetActive(false);
        for (int i = 0; i < 9; i++)
            change_weapon.weapons[i].SetActive(false);
    }
    public void Weapon() 
    {
        category_i = 0;
        OFF_ALL();
        UpdateCells();
        ChangeColor(0, 1, 2);
        blue_light_arr[0].SetActive(true); blue_light_arr[1].SetActive(true);
        cell = weapon_cell_1.GetComponent<RectTransform>();
        cell.anchoredPosition = new Vector2(-420,cell.anchoredPosition.y+10);cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell = weapon_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell = weapon_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(-420, cell.anchoredPosition.y-10);
        skins_menu.SetActive(false);skins_light.SetActive(false);skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(false); traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false);granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(true); weapon_light.SetActive(true); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 289);
    }
    public void Skins() 
    {
        category_i = 1;
        OFF_ALL();
        UpdateCells();
        ChangeColor(3, 4, 5);
        blue_light_arr[2].SetActive(true); blue_light_arr[3].SetActive(true);
        cell = skins_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x-10,60);
        cell = skins_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell = skins_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x+10, 60);
        traps_menu.SetActive(false); traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false); granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false); weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        skins_menu.SetActive(true); skins_light.SetActive(true); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 289);
    }
    public void Traps()
    {
        category_i = 2;
        OFF_ALL();
        UpdateCells();
        ChangeColor(9, 10, 11);
        blue_light_arr[4].SetActive(true); blue_light_arr[5].SetActive(true);
        cell = traps_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x-10,29);
        cell = traps_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell = traps_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x+10,29);
        skins_menu.SetActive(false); skins_light.SetActive(false); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false); granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false); weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(true); traps_light.SetActive(true); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 289);
    }
    public void Granage()
    {
        category_i = 3;
        OFF_ALL();
        UpdateCells();
        ChangeColor(6, 7, 8);
        blue_light_arr[6].SetActive(true); blue_light_arr[7].SetActive(true);
        i = 0;
        cell = granage_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(-454,cell.anchoredPosition.y+10);
        cell = granage_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell = granage_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.5f, 1.5f, 1f);
        cell.anchoredPosition = new Vector2(-454,cell.anchoredPosition.y-10);
        skins_menu.SetActive(false); skins_light.SetActive(false); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(false);traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false);weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(true); granage_light.SetActive(true); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 289);
    }
    public GameObject weapon_cell_1;
    public GameObject weapon_cell_2;
    public GameObject weapon_cell_3;
    public GameObject skins_cell_1;
    public GameObject skins_cell_2;
    public GameObject skins_cell_3;
    public GameObject traps_cell_1;
    public GameObject traps_cell_2;
    public GameObject traps_cell_3;
    public GameObject granage_cell_1;
    public GameObject granage_cell_2;
    public GameObject granage_cell_3;

    public GameObject shadow_1, shadow_2, shadow_3, shadow_4, shadow_5, shadow_6, shadow_7, shadow_8, shadow_9, shadow_10, shadow_11, shadow_12;
    public GameObject contour_1, contour_2, contour_3, contour_4, contour_5, contour_6, contour_7, contour_8, contour_9, contour_10, contour_11, contour_12;
    private GameObject[] cells;
    private float[,] cells_pos;
    private RectTransform cell;
    private void UpdateCells() 
    { 
        for(int k = 0; k < 12; k++) {
            cell = cells[k].GetComponent<RectTransform>();
            cell.anchoredPosition=new Vector2(cells_pos[k,0],cells_pos[k, 1]);
            cell.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OFF_ALL()
    {
        for (int x = 0; x < weapons_arr.Length; x++)
            weapons_arr[x].SetActive(false);
        for (int x = 0; x < grenades_arr.Length; x++)
            grenades_arr[x].SetActive(false);
        for (int x = 0; x < 8; x++)
            blue_light_arr[x].SetActive(false);
        stop = true;
        for (int i = 0; i < 9; i++)
            w_light[i].SetActive(false);
        for (int i = 0; i < 5; i++)
            g_light[i].SetActive(false);
        for (int i = 0; i < 4; i++)
            s_light[i].SetActive(false);
    }
    private GameObject[] color_cells_arr;
    private GameObject[] contour_cells_arr;
    private void ChangeColor(int x, int y, int z)
    {
        color_cells_arr = new GameObject[12];
        contour_cells_arr = new GameObject[12];
        color_cells_arr[0] = shadow_1; color_cells_arr[1] = shadow_2; color_cells_arr[2] = shadow_3; color_cells_arr[3] = shadow_4; color_cells_arr[4] = shadow_5; color_cells_arr[5] = shadow_6; color_cells_arr[6] = shadow_7; color_cells_arr[7] = shadow_8; color_cells_arr[8] = shadow_9; color_cells_arr[9] = shadow_10; color_cells_arr[10] = shadow_11; color_cells_arr[11] = shadow_12;
        contour_cells_arr[0] = contour_1; contour_cells_arr[1] = contour_2; contour_cells_arr[2] = contour_3; contour_cells_arr[3] = contour_4; contour_cells_arr[4] = contour_5; contour_cells_arr[5] = contour_6; contour_cells_arr[6] = contour_7; contour_cells_arr[7] = contour_8; contour_cells_arr[8] = contour_9; contour_cells_arr[9] = contour_10; contour_cells_arr[10] = contour_11; contour_cells_arr[11] = contour_12;
        for (int k = 0; k < 12; k++)
            if (k != x && k != y && k != z)
            {
                color_cells_arr[k].SetActive(true);
                color_cells_arr[k].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.4f);
                contour_cells_arr[k].SetActive(false);
            }
            else
            {
                color_cells_arr[k].SetActive(false);
                color_cells_arr[k].GetComponent<Image>().color = new Color(1f, 1f,1f, 1f);
                contour_cells_arr[k].SetActive(true);
            }
    }
}
