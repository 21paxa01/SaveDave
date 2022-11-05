using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training : MonoBehaviour
{
    private Save save;
    public GameObject train_menu;
    public GameObject other;
    private GameObject[] frames;
    public GameObject frame_1, frame_2, frame_3, frame_4, frame_5, frame_6, frame_7, frame_8, frame_9;
    private int  j;
    public anonim_phrases script;
    private Inventory inv;
    private int[] w_prise_arr = { 150, 300, 50, 200, 200, 100, 250, 350 };
    void Start()
    {
        save = GameObject.Find("save").GetComponent<Save>();
        inv= GameObject.Find("Home_Canvas").GetComponent<Inventory>();
        /*save.inventory = true;
        if(save.training==true)
            save.inventory = false;*/
        frames = new GameObject[9];
        frames[0] = frame_1; frames[1] = frame_2; frames[2] = frame_3; frames[3] = frame_4; frames[4] = frame_5; frames[5] = frame_6; frames[6] = frame_7; frames[7] = frame_8; frames[8] = frame_9;
        j = 0;
        if (save.training == true)
        {
            for (int k = 1; k < 9; k++)
            {
                save.w_buy_arr[k] = 1;
                save.inv_j = k;
                save.w_prise_arr[k] = ((int)(w_prise_arr[k - 1] * 0.4f));
                save.save_cell_ind_arr[save.inv_j] = k;
                inv.NewWeapon();
            }
            for (int k = 1; k < 4; k++)
            {
                save.s_buy_arr[k] = 1;
                save.inv_s++;
                save.save_s_cell_ind_arr[save.inv_s] = k;
                inv.NewSkin();
            }
            for (int k = 0; k < 5; k++)
            {
                save.g_buy_arr[k] = 1;
                save.inv_k = k;
                save.save_g_cell_ind_arr[save.inv_k] = k;
                inv.NewGrenade();
            }
            save.weapon_kol = 8;
            save.grenades_kol = 5;
            save.save_wave = 10;
        }
    }

    void Update()
    {
        
    }
    public void TrainingStart()
    {
        if (save.training == true)
        {
            train_menu.SetActive(true);
            save.training_phrases = true;
            StartCoroutine(TrainingMenu());
        }
    }
    public void TrainingEnd()
    {
        if (save.training == true)
        {
            save.training = false;
            Time.timeScale = 1f;
            train_menu.SetActive(false);
            frames[j].SetActive(false);
            other.SetActive(false);
            //save.Save_training();
            Invoke("UpdateTraining", 0.1f);
        }
    }
    IEnumerator TrainingMenu()
    {
        yield return new WaitForSeconds(2.5f);
        //Time.timeScale = 0f;
        other.SetActive(true);
        frames[j].SetActive(true);
    }
    public void Change()
    {
        frames[j].SetActive(false);
        j = script.i;
        frames[j].SetActive(true);
    }
    private void UpdateTraining()
    {
        save.training = true;
    }
}
