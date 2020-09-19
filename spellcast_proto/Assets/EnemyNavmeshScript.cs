using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavmeshScript : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        _navMeshAgent.Warp(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = player.transform.position;
    }
}
