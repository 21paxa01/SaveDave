using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    Text text;
    public int mon;
    public int[] flesh = { 0, 0, 0 };
    private int i;
    void Start()
    {
        //flesh = new int[3];
        Load();
    }

    void Update()
    {
        
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath+"/MoneyCount.dat",FileMode.Create);
        Money money_count=new Money();
        money_count.count = mon;
        money_count.fl = flesh;
        formatter.Serialize(file, money_count);
        file.Close();
    }
    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/MoneyCount.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/MoneyCount.dat", FileMode.Open);
            Money money_count = (Money)formatter.Deserialize(file);
            file.Close();
            mon = money_count.count;
            flesh = money_count.fl;
        }
    }
    [Serializable]
    public class Money
    {
        public int count;
        public int[] fl;
    }
}
