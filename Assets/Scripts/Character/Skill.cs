using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private int cost;
    private int damage;
    private float statsUp;
    [SerializeField] public Button active;
    [SerializeField] public Image inactive;
    [SerializeField] public Button selected;
    [SerializeField] public TextMeshProUGUI skillName;

    public SkillsScriptable skillsScriptable;
    private bool isSelected;

    private void Start()
    {
        cost = skillsScriptable.cost;
        damage = skillsScriptable.damage;
        statsUp = skillsScriptable.statsUp;
        skillName.text = cost.ToString() + " | " + skillsScriptable.skillName;
        OnInit();
        active.onClick.AddListener(() => selectSkill());
        selected.onClick.AddListener(() => unselectSkill());
    }

    public void OnInit()
    {
        isSelected = false;
        inactive.gameObject.SetActive(true);
        active.gameObject.SetActive(false);
        selected.gameObject.SetActive(false);
    }

    public void selectSkill()
    {
        if (isSelected)
        {
            return;
        }
        isSelected = true;  
        skillState(true);
        SkillController.Instance.totalDamage += damage;
        DiceController.totalDice -= cost;
    }

    public void unselectSkill()
    {
        isSelected = false;
        skillState(false);
        SkillController.Instance.totalDamage -= damage;
        DiceController.totalDice += cost;
    }

    public void availableSkill(int totalSkillPoints)
    {
        if (cost <= totalSkillPoints)
        {
            inactive.gameObject.SetActive(false);
            if (isSelected)
            {
                skillState(true);
            }
            else
            {
                skillState(true);
            }
        }
        else if (cost > totalSkillPoints && !isSelected)
        {
            inactive.gameObject.SetActive(true);
            active.gameObject.SetActive(false);
            selected.gameObject.SetActive(false);
        }
    }

    private void skillState(bool state)
    {
        if (isSelected)
        {
            selected.gameObject.SetActive(state);
            active.gameObject.SetActive(!state);    
            inactive.gameObject.SetActive(!state);
        }
        else
        {
            active.gameObject.SetActive(state);
            selected.gameObject.SetActive(!state);
        }
    }
}
