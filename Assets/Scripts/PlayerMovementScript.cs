using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMovementScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        //check if it's the local player
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    //when the local player is created
    public override void OnStartLocalPlayer()
    {
        //change its color to green
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
