using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsDisplay : Singleton<StatsDisplay>
{
    [SerializeField] public Character player;

    [SerializeField] public TextMeshProUGUI[] stats;

    private void Start()
    {
        StartCoroutine(InitStats());
    }

    public IEnumerator InitStats()
    {
        yield return new WaitForSeconds(1);
        stats[0].text = "Attack: " + player.attackStat;
        stats[1].text = "Defense: " + player.defenseStat;
        stats[2].text = "Magic: " + player.magicStat;
        stats[3].text = "Luck: " + player.luckStat;
    }
}
