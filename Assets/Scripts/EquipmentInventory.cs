using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentInventory : MonoBehaviour
{
    [SerializeField] Image[] rarity;
    [SerializeField] TextMeshProUGUI[] equipmentStatDisplay;
    [SerializeField] Image equippedImage;

    private Character player;

    public EquipmentStats equipmentStats;
    public bool isEquipped;

    private float attackStatsInc;
    private float defenseStatsInc;
    private float magicStatsInc;
    private float luckStatsInc;
    private int rarityIndex;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Knight>();
        this.attackStatsInc = equipmentStats.attackStatsInc;
        this.defenseStatsInc = equipmentStats.defenseStatsInc;
        this.magicStatsInc = equipmentStats.magicStatsInc;
        this.luckStatsInc = equipmentStats.luckStatsInc;
        this.rarityIndex = equipmentStats.rarityIndex;
        for (int i = 0; i < rarity.Length; i++)
        {
            if (i == rarityIndex)
            {
                GameObject storage = this.gameObject.transform.parent.gameObject;
                Storage equipmentStore = storage.GetComponent<Storage>();
                rarity[i].gameObject.SetActive(true);
                rarity[i].GetComponent<Button>().onClick.AddListener(() => equipmentStore.EquipItem(this));
            }
            else
            {
                rarity[i].gameObject.SetActive(false);
            }
        }
        equipmentStatDisplay[0].text +=  " " + attackStatsInc;
        equipmentStatDisplay[1].text += " " + defenseStatsInc;
        equipmentStatDisplay[2].text += " " + magicStatsInc;
        equipmentStatDisplay[3].text += " " + luckStatsInc;
    }

    public void OnEquip()
    {
        isEquipped = true;
        StartCoroutine(StatsDisplay.Instance.InitStats());
        player.attackStat += this.attackStatsInc;
        player.defenseStat += this.defenseStatsInc;
        player.magicStat += this.magicStatsInc;
        player.luckStat += this.luckStatsInc;
    }

    public void OnUnequip()
    {
        if (isEquipped)
        {
            player.attackStat -= this.attackStatsInc;
            player.defenseStat -= this.defenseStatsInc;
            player.magicStat -= this.magicStatsInc;
            player.luckStat -= this.luckStatsInc;
        }
        isEquipped = false;
    }

    private void Update()
    {
        if (isEquipped)
        {
            equippedImage.gameObject.SetActive(true);
        }
        else if (isEquipped == false)
        {
            equippedImage.gameObject.SetActive(false);
        }
    }
}
