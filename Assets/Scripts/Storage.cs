using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public EquipmentInventory[] equipmentInventory;

    public int equipmentTypes;

    public Character player;

    public GameObject equipmentContainer;

    public List<EquipmentInventory> equipmentInventoryList = new List<EquipmentInventory>();

    public void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        equipmentInventory = Inventory.Instance.GetCurrentEquipmentTypes(equipmentTypes);
        AddItem();
    }

    public void AddItem()
    {   
        for (int i = 0; i < equipmentInventory.Length; i++)
        {
            EquipmentInventory equipment = Instantiate(equipmentInventory[i], Vector3.zero, Quaternion.identity);
            equipmentInventoryList.Add(equipment);
            equipment.transform.SetParent(equipmentContainer.transform);
        }
    }

    public void EquipItem(EquipmentInventory equipment)
    {
        for (int i = 0; i < equipmentInventoryList.Count; i++)
        {
            if (equipmentInventoryList[i].isEquipped)
                {
                    equipmentInventoryList[i].OnUnequip();
                }
        }
        equipment.OnEquip();
    }
}
