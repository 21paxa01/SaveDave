using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawing : MonoBehaviour
{
    public GameObject stick, rifle, rpg, axe,dinamyte,ice_grenade;
    public Rigidbody2D rb;
    public change_weapon script;
    private Save save;
    void Start()
    {
        script = GameObject.Find("Bill").GetComponent<change_weapon>();
        save = GameObject.Find("save").GetComponent<Save>();
        UpdatWeapon();
    }

   
    void Update()
    {
        if (transform.position.y <= -3.011614f)
        {
            transform.position = new Vector3(transform.position.x, -3.011614f, transform.position.z);
            rb.gravityScale = 0f;
        }
    }
    public void UpdatWeapon()
    {
        if (save.save_wave == 1)
            stick.SetActive(true);
        if (save.save_wave == 2)
            dinamyte.SetActive(true);
        if (save.save_wave == 3)
            rifle.SetActive(true);
        if (save.save_wave == 5)
            ice_grenade.SetActive(true);
    }
    private void NewWeapon()
    {
        if (save.save_wave == 1)
        {
            save.weapon_kol=3;
            save.Save_weapon();
        }
        if (save.save_wave == 3)
        {
            save.weapon_kol = 4;
            save.Save_weapon();
        }
        if (save.save_wave == 2)
        {
            save.grenades_kol = 2;
            save.Save_grenades();
        }
        if (save.save_wave == 5)
        {
            save.grenades_kol = 3;
            save.Save_grenades();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            NewWeapon();
        }
    }
}
