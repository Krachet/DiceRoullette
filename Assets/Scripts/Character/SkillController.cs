using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : Singleton<SkillController>
{
    public float totalDamage;
    [SerializeField] public Button confirm;
    [SerializeField] public Skill[] skills;

    public DamageNumber numberPrefab;
    public RectTransform rectParent;


    private void Start()
    {
        confirm.onClick.AddListener(() => Commit(totalDamage + BattleSystem.currentCharTurn.attackStat));
    }

    private void Update()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].availableSkill(DiceController.totalDice);
        }
    }

    public void Commit(float damage)
    {
        numberPrefab.SpawnGUI(rectParent, Vector2.zero, damage);
        GameController.Instance.DealDamage(damage);
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].OnInit();
        }
        RollDice.Instance.ResetDice();
        totalDamage = 0;
        StartCoroutine(WaitBetweenTurn());
    }

    public IEnumerator WaitBetweenTurn()
    {
        yield return new WaitForSeconds(1);
        BattleSystem.Instance.ChangeTurn();
        RollDice.Instance.ButtonFlipSwitch(false);
    }
}
