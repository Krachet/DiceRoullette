using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : Singleton<DiceController>
{
    [SerializeField] public Dice dice1;
    [SerializeField] public Dice dice2;
    public static int totalDice;
}
