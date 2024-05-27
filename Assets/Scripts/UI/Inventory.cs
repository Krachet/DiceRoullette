using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] public EquipmentInventory[] weapons;
    [SerializeField] public EquipmentInventory[] armors;
    [SerializeField] public EquipmentInventory[] helmets;
    [SerializeField] public EquipmentInventory[] pants;
    [SerializeField] Button[] changeEquipmentType;
    [SerializeField] GameObject[] equipmentType;

    private void Start()
    {
        ChangeEquipmentType(0);
        changeEquipmentType[0].onClick.AddListener(() => ChangeEquipmentType(0));
        changeEquipmentType[1].onClick.AddListener(() => ChangeEquipmentType(1));
        changeEquipmentType[2].onClick.AddListener(() => ChangeEquipmentType(2));
        changeEquipmentType[3].onClick.AddListener(() => ChangeEquipmentType(3));
    }

    public EquipmentInventory[] GetCurrentEquipmentTypes(int index)
    {
        if (index == 1)
        {
            return weapons;
        }
        else if (index == 2)
        {
            return armors;
        }
        else if (index == 3)
        {
            return helmets;
        }
        else if (index == 4)
        {
            return pants;
        }
        else
        {
            return null;
        }
    }

    private void ChangeEquipmentType(int v)
    {
        for (int i = 0; i < equipmentType.Length; i++)
        {
            if (i == v)
            {
                equipmentType[i].SetActive(true);
            }
            else
            {
                equipmentType[i].SetActive(false);
            }
        }
    }

}
