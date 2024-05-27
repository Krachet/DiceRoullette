using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : Singleton<BattleSystem>
{
    [SerializeField] Knight knight;
    [SerializeField] Archer archer;
    [SerializeField] Wizard wizard;
    [SerializeField] Enemy enemy1;

    public static Character currentCharTurn;

    public enum CharTurn
    {
        Player,
        Enemy
    }

    public CharTurn currentTurn;

    // Start is called before the first frame update
    void Start()
    {
        currentCharTurn = knight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTurn()
    {
        currentCharTurn.OnEndTurn();
    }
}
