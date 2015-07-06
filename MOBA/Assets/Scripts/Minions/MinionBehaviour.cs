using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MinionBehaviour : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    private float distanceMin;
    private float distance;

	// Use this for initialization
	void Start ()
	{
	    distanceMin = 250f;
	    if (tag == "MinionTeam1")
	    {
	        navMeshAgent.destination = new Vector3(10, 0, 37);
	    }
        else
        {
            navMeshAgent.destination = new Vector3(-10, 0, -37);
        }
	}

    void OnTriggerStay(Collider other)
    {
        if ((tag == "MinionTeam1" && other.tag == "Team2") || (tag == "MinionTeam2" && other.tag == "Team1") || (tag == "MinionTeam1" && other.tag == "MinionTeam2") || (tag == "MinionTeam2" && other.tag == "MinionTeam1"))
        {
            distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < distanceMin)
            {
                distanceMin = distance;
                navMeshAgent.destination = other.transform.position;
            }
            if (distance <= 1.5)
            {
                //navMeshAgent.destination = transform.position;
                navMeshAgent.ResetPath();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        resetDistanceMin();
    }

    public void resetDistanceMin()
    {
        distanceMin = 250;
        StartCoroutine(resetNavMesh(0.1f));
        if (tag == "MinionTeam1")
        {
            transform.parent.gameObject.layer = 8;
        }
        else
        {
            transform.parent.gameObject.layer = 9;
        }
    }

    IEnumerator resetNavMesh(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (tag == "MinionTeam1")
        {
            navMeshAgent.destination = new Vector3(10, 0, 37);
        }
        else
        {
            navMeshAgent.destination = new Vector3(-10, 0, -37);
        }
    }
}
