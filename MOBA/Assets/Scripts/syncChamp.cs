using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class syncChamp : NetworkBehaviour
{
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject red;

    [Command]
    public void CmdSyncChamp(int champSelected)
    {
        RpcSyncChamp(champSelected);
    }

    [ClientRpc]
    void RpcSyncChamp(int champSelected)
    {
        switch (champSelected)
        {
            case 1:
                green.SetActive(true);
                break;
            case 2:
                red.SetActive(true);
                break;
        }
    }
}
