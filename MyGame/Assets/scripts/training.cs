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
    void Start()
    {
        save = GameObject.Find("save").GetComponent<Save>();
        save.inventory = true;
        if(save.training==true)
            save.inventory = false;
        frames = new GameObject[9];
        frames[0] = frame_1; frames[1] = frame_2; frames[2] = frame_3; frames[3] = frame_4; frames[4] = frame_5; frames[5] = frame_6; frames[6] = frame_7; frames[7] = frame_8; frames[8] = frame_9;
        j = 0;
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
            save.Save_training();
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
}
