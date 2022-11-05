using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioSource sound;
    private Save save_script;
    void Start()
    {
        save_script = GameObject.Find("save").GetComponent<Save>();
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = save_script.save_Sounds;
    }
}
