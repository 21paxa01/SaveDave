using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawing : MonoBehaviour
{
    public GameObject stick, rifle, rpg, axe;
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
        if (spawn.wave == 1)
            stick.SetActive(true);
    }
    private void NewWeapon()
    {
        if (spawn.wave == 1)
        {
            save.weapon_kol=3;
            save.Save_weapon();
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
