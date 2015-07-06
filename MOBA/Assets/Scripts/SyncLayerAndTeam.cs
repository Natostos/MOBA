using UnityEngine;
using System.Collections;
using Camera = UnityEngine.Camera;
using UnityEngine.Networking;

public class SyncLayerAndTeam : NetworkBehaviour
{

    public GameObject camera;

	private int team = 0; //1 for Blue team, 2 for Red team

    void UpdateCamera()
    {
        CmdUpdateCamera(team);
    }

    public void UpdateAll(int team)
    {
        this.team = team;
        UpdateCamera();
    }

    public int AccessToTeam()
    {
        return team;
    }

    void ChangeLayersRecursively(Transform trans, int layer, string tag)
    {
        trans.gameObject.layer = layer;
        trans.gameObject.tag = tag;
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, layer, tag);
        }
    }

    [Command]
    public void CmdUpdateCamera(int i)
    {
        RpcUpdateCamera(i);
    }

    [ClientRpc]
    private void RpcUpdateCamera(int i)
    {
        if (i == 1)
        {
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 8);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 10);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 11);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 13);
            tag = "Team1";
            ChangeLayersRecursively(transform, 8, "Team1");
            transform.position = new Vector3(-10, 0, -37);
        }
        else
        {
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 9);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 10);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 11);
            camera.GetComponent<UnityEngine.Camera>().cullingMask |= (1 << 14);
            tag = "Team2";
            ChangeLayersRecursively(transform, 9, "Team2");
            transform.position = new Vector3(10, 0, 37);
        }
    }
}
