using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behaviours;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobSpawnerManager : MonoBehaviour
{
    public List<GameObject> Mobs = new List<GameObject>();
    public List<Transform> Spawners = new List<Transform>();
    public List<GameObject> ActiveMobs = new List<GameObject>();
    public int difficultyLevel = 1;
    public KillCounter _KillCounter;

    private void Start()
    {
        _KillCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        difficultyLevel = Mathf.Abs(_KillCounter.kills / 5) + 1;
        ActiveMobs = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        if (ActiveMobs.Count < difficultyLevel && difficultyLevel < Spawners.Count)
            SpawnMob();
    }

    private void SpawnMob()
    {
        var randSpawner = Random.Range(0, Spawners.Count - 1);
        var randMob = Random.Range(0, Mobs.Count - 1);

        var spawners = Spawners /*.Where(s => s.childCount == 0).ToList()*/;

        var spawner = spawners[randSpawner];
        var mob = Mobs[randMob];


        Instantiate(mob, spawner);
    }
}