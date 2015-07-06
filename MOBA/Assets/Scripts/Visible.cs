using UnityEngine;
using System.Collections;
//using UnityEditor;

public class Visible : MonoBehaviour
{
    public GameObject player;

    private RaycastHit hit;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Jungle" && player.GetComponent<SyncLayerAndTeam>().AccessToTeam() == 1)
        {
            if (Physics.Linecast(player.transform.position, other.transform.position, out hit) && hit.collider.tag == other.tag)
            {
                other.gameObject.layer = 13; //Set the layer to Jungle Team1
            }
            else
            {
                other.gameObject.layer = 12;
            }
        }
        else if (other.tag == "Jungle" && player.GetComponent<SyncLayerAndTeam>().AccessToTeam() == 2)
        {
            if (Physics.Linecast(player.transform.position, other.transform.position, out hit) && hit.collider.tag == other.tag)
            {
                other.gameObject.layer = 14; //Set the layer to Jungle Team2
            }
            else
            {
                other.gameObject.layer = 12;
            }
        }
        else if ((other.tag == "Team2" || other.tag == "MinionTeam2") && player.GetComponent<SyncLayerAndTeam>().AccessToTeam() == 1)
        {
            if (Physics.Linecast(player.transform.position, other.transform.position, out hit) && hit.collider.tag == other.tag)
            {
                other.gameObject.layer = 10; //Set the layer to Visible Team1
            }
            else
            {
                other.gameObject.layer = 9; //Reset to the layer Team2
            }
        }
        else if ((other.tag == "Team1" || other.tag == "MinionTeam1") && player.GetComponent<SyncLayerAndTeam>().AccessToTeam() == 2)
        {
            if (Physics.Linecast(player.transform.position, other.transform.position, out hit) && hit.collider.tag == other.tag)
            {
                other.gameObject.layer = 11; //Set the layer to Visible Team2
            }
            else
            {
                other.gameObject.layer = 8; //Reset to the layer Team1
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 13)
        {
            other.gameObject.layer = 12; //Reset the layer to Jungle
        }

        else if (other.gameObject.layer == 10)
        {
            other.gameObject.layer = 9; //Reset the layer to Team2
        }

        else if (other.gameObject.layer == 11)
        {
            other.gameObject.layer = 8; //Reset the layer to Team1
        }
    }
}
