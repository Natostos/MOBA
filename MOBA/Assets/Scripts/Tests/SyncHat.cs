using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncHat : NetworkBehaviour
{

    [SerializeField] private GameObject hat;

    [Command]
    public void CmdActivateHat(bool wearingHat)
    {
        RpcSyncHat();
        //hat.SetActive(true);
        
        //syncHat();
    }

    [ClientRpc]
    void RpcSyncHat()
    {
        hat.SetActive(true);
    }

    [Command]
    public void CmdDesactivateHat()
    {
        hat.SetActive(false);
    }
	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
