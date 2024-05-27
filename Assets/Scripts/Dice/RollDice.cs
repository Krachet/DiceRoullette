using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : Singleton<RollDice>
{
    [SerializeField] Dice[] dice;
    [SerializeField] Button diceRoll;
    [SerializeField] public SkillController skillController;

    public int sceneIndex;

    private void Start()
    {
        diceRoll.onClick.AddListener(() => Invoke(nameof(DiceRoll), 0.1f));
    }


    public void DiceRoll()
    {
        DiceController.totalDice = 0;
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].DiceRoll();
        }
        Invoke(nameof(GetTotalDice), 3f);
        if (sceneIndex == 0)
        {
            //skillController.gameObject.SetActive(false);
            Invoke(nameof(CharacterMove), 3.1f);
        } 
        else if (sceneIndex == 1)
        {
            skillController.gameObject.SetActive(true);
        }
    }

    public void CharacterMove()
    {
        StartCoroutine(GameController.Instance.moveCharacter());
    }

    public void ButtonFlipSwitch(bool flip)
    {
        gameObject.SetActive(!flip);
    }

    public int GetTotalDice()
    {
        int sum = 0;
        for (int i = 0; i < dice.Length; i++)
        {
            sum = sum + dice[i].finalSide;
        }
        DiceController.totalDice = sum;
        return sum;
    }

    public void ResetDice()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].ResetDiceFace();
        }
        DiceController.totalDice = 0;
    }
}
