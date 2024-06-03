using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [SerializeField] public GameObject[] roads;
    [SerializeField] public PlayersControlled character;
    [SerializeField] public Button[] turnRight;
    [SerializeField] public Button[] turnLeft;
    [SerializeField] public Button rollDice;
    [SerializeField] public Healthbar enemyHealthbar;
    [SerializeField] public Healthbar playerHealthbar;

    public int sceneIndex;
    private int cornerIndex;
    private int index;
    private int moveIndex;
    private bool atCorner;
    private int biomeIndex;

    private void Start()
    {
        index = 0;
        moveIndex = 0;
        biomeIndex = 0;
        atCorner = false;
        cornerIndex = 0;
        if (sceneIndex == 1)
        {
            character.transform.position = roads[index].transform.position + new Vector3(0, 0.3f, 0);
            CornerInit();
        }
    }

    private void CornerInit()
    {
        turnLeft[0].onClick.AddListener(() => GetCornerIndex(6));
        turnRight[0].onClick.AddListener(() => GetCornerIndex(15));
        turnLeft[1].onClick.AddListener(() => GetCornerIndex((23)));
        turnRight[1].onClick.AddListener(() => GetCornerIndex(30));
    }

    public IEnumerator moveCharacter()
    {
        yield return new WaitForSeconds(0.2f);
        if (atCorner)
        {
            StopCoroutine(moveCharacter());
        }
        else if (index > roads.Length - 1)
        {
            index = roads.Length - 1;
            StopCoroutine(moveCharacter());
            moveIndex = 0;
        }
        else if (moveIndex <= DiceController.totalDice)
        {
            Move();
            StartCoroutine(moveCharacter());
        }
        else if (moveIndex > DiceController.totalDice)
        {
            moveIndex = 1;
            RollDice.Instance.ButtonFlipSwitch(false);
        }
    }

    private void Move()
    {
        character.transform.position = roads[index].transform.position;
        character.transform.position += new Vector3(0, 0.3f, 0);
        index++;
        moveIndex++;
    }

    public int onFinalTile()
    {
        if (biomeIndex == 0)
        {
            index = 20;
        }
        else if (biomeIndex == 1) 
        {
            index = 37;
        }
        biomeIndex++;
        return index;
    }

    public int GetCornerIndex(int nextIndex)
    {
        index = nextIndex;
        turnLeft[cornerIndex].gameObject.SetActive(false);
        turnRight[cornerIndex].gameObject.SetActive(false);
        cornerIndex++;
        atCorner = false;
        StartCoroutine(moveCharacter());
        RollDice.Instance.ButtonFlipSwitch(false);
        return index;
    }

    public void onCornerChoose()
    {
        atCorner = true;
        turnLeft[cornerIndex].gameObject.SetActive(true);
        turnRight[cornerIndex].gameObject.SetActive(true);
        StopCoroutine(moveCharacter());
    }

    public void DealDamage(float damage)
    {
        BattleSystem.currentCharTurn.DealDamage(damage);
    }
}
