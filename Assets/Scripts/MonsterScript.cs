using UnityEngine;
using System.Collections;
using System;

public class MonsterScript : MonoBehaviour {

    //each monster is identified by its index and its monster value
    private static Monster m;
    public int index = m.getNumber();

	// Use this for initialization
	void Start () {
        setMonster();
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * //check if it's the local player
        if (!isLocalPlayer)
        {
            return;
        }
        */

        //controls
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    //upload new monster from given index
    void setMonster()
    {
        m = AccessMonsters.GetMonster(index);
    }

    //damage calculation
    void dealDamage()
    {

    }

    //when another object hits this object
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "attack")
        {
            //do calculation
        }
    }
}

