using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject GUI;
    private NetworkManagerHUD hud;

    private GameObject choice;

	// Use this for initialization
	void Start ()
    {
	    if (isLocalPlayer)
	    {
	        hud = GameObject.Find("NetworkManager").GetComponent<NetworkManagerHUD>();

	        hud.enabled = false;
	        GetComponent<NavMeshAgent>().enabled = true;
	        GetComponent<Movement>().enabled = true;
            camera.SetActive(true);
            GUI.SetActive(true);
	    }
	}
}
