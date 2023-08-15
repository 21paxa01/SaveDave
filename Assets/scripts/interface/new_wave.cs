using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_wave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NeW_Wave()
    {
        GameObject.Find("save").GetComponent<Save>().save_wave++;
        GameObject.Find("save").GetComponent<Save>().Save_progress();
    }
}
