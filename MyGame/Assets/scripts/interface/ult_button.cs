using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ult_button : MonoBehaviour
{
    public GameObject mashine;
    public GameObject skins;
    public change_weapon change;
    public ultimate ult;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UltOn()
    {
        change.ult = true;
        mashine.SetActive(true);
        skins.SetActive(false);
        gameObject.SetActive(false);
        ult.Activate();
    }
}

