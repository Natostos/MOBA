using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public UnityEngine.Camera cam;
    public GameObject BlueMeleeMinion;
    public GameObject RedMeleeMinion;

    private Ray raycast;
    private RaycastHit RC;
    private float distance;
    private NavMeshAgent agent;
    private LayerMask layerMask;

    private bool cameraLock;

    // Use this for initialization
    void Start()
    {
        cameraLock = true;
        agent = GetComponent<NavMeshAgent>();
        raycast = new Ray();
        layerMask = new LayerMask();
        layerMask |= (1 << 15); // So the Raycast stops on the Terrain layer (all the environment are layered Terrain)
    }

    [Command]
    void CmdPopMinions()
    {
        RpcPopMinions();
    }

    [ClientRpc]
    void RpcPopMinions()
    {
        GameObject blueMinion = (GameObject)Instantiate(BlueMeleeMinion, new Vector3(-10, 0, -37), Quaternion.identity);
        GameObject redMinion = (GameObject)Instantiate(RedMeleeMinion, new Vector3(10, 0, 37), Quaternion.identity);
        NetworkServer.Spawn(blueMinion);
        NetworkServer.Spawn(redMinion);
    }

    // Update is called once per frame
    void Update()
    {
        raycast = cam.ScreenPointToRay(Input.mousePosition);
        cam.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        if (Physics.Raycast(raycast, out RC, 500, layerMask) && Input.GetMouseButton(1))
        {
            Debug.DrawLine(raycast.origin, RC.point);
            agent.SetDestination(RC.point);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            cameraLock = !cameraLock;
            if (cameraLock)
            {
                cam.transform.SetParent(transform);
                cam.transform.position = transform.position;
                cam.transform.Translate(0, 0, -33);
            }

            else
                cam.transform.SetParent(null);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying to sync champs");
            GetComponent<syncChamp>().CmdSyncChamp(GetComponent<ChoseChamp>().accessChampSelected());
            GetComponent<SyncLayerAndTeam>().CmdUpdateCamera(GetComponent<SyncLayerAndTeam>().AccessToTeam());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            CmdPopMinions();
        }


        if (!cameraLock)
        {
            if (Input.mousePosition.x < 100)
                cam.transform.Translate(-0.3f, 0, 0);

            else if (Input.mousePosition.x > Screen.width - 100)
                cam.transform.Translate(0.3f, 0, 0);

            if (Input.mousePosition.y < 100)
                cam.transform.Translate(0, -0.3f, 0);

            else if (Input.mousePosition.y > Screen.height - 100)
                cam.transform.Translate(0, 0.3f, 0);
        }
    }
}
