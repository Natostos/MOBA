using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MovingTest : NetworkBehaviour
{
    [SerializeField] public GameObject hat;

    private bool wearingHat = false;

	void movement()
    {
	    if (isLocalPlayer)
	    {
	        /*if (Input.GetKey(KeyCode.Space) && wearingHat)
	        {
                hat.SetActive(false);
	            GetComponent<SyncHat>().CmdDesactivateHat();
	            wearingHat = false;
	        }*/


	        if (Input.GetKey(KeyCode.Space) && !wearingHat)
	        {
                hat.SetActive(true);
	            GetComponent<SyncHat>().CmdActivateHat(true);
	            wearingHat = true;
	        }
                
            //transform.Translate(Vector3.up * 0.1f);

            if (Input.GetKey(KeyCode.Z))
                transform.Translate(Vector3.forward * 0.1f);

            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * 0.1f);

            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.left * 0.1f);

            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * 0.1f);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (isLocalPlayer)
	        movement();
	}
}
