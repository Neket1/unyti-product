using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enem : MonoBehaviour
{
    public NavMeshAgent enems;
    public Transform player;
    void Start()
    {
        enems= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enems.SetDestination(player.position);
    }
}
