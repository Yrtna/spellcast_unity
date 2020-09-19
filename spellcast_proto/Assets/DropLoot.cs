using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public GameObject loot;
    public int dropRate = 20;

    public void Execute()
    {
        if (RollDice())
            InstantiateLoot();
    }

    private bool RollDice()
    {
        var step = 100 / dropRate;
        var rand = Random.Range(1, 100);
        return rand % step == 0;
    }

    private void InstantiateLoot()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        Instantiate(loot, pos, rot);
    }
}