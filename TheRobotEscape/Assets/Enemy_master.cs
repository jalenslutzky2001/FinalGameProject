using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_master : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public float Speed;

    public bool isAngered;

    public NavMeshAgent _agent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        _agent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if(Distance <= 5)
        {
            isAngered = true;
        }
        if(Distance > 5)
        {
            isAngered = false;
        }

        if(isAngered)
        {
            _agent.isStopped = false;

            _agent.SetDestination(Player.transform.position);
        }
        if (!isAngered && _agent.remainingDistance < _agent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            _agent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }

    }

    private void OnCollisionEnter(Collision Player)
    {
        SceneManager.LoadScene("SampleScene");
    }

}
