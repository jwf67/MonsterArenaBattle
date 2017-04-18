using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnMonsterScript : NetworkBehaviour {

    //Number of monsters
    public const int NUM_MONSTERS = 30;

    //List of all RigidBodies
    public Rigidbody[] rigidbodies = new Rigidbody[NUM_MONSTERS];

    //Spawn every x amount of seconds
    public float timeInterval = 5.0f;

    //Live for y seconds
    public float timeLive = 30.0f;

    //values where monsters can spawn
    public const int MIN_X = -30;
    public const int MAX_X = 30;
    public const int MIN_Y = 1;
    public const int MAX_Y = 1;
    public const int MIN_Z = -30;
    public const int MAX_Z = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Spawn a new enemy in a surrounding area
    void SpawnMonster()
    {
        //store position of the monster
        float[] monster_xz = GenerateRandomPosition();

        //initialize position of the enemy
        Vector3 monsterPosition = new Vector3(monster_xz[0], 0.0f, monster_xz[1]);

        //Create a new enemy instance
        Rigidbody monsterInstance = Instantiate(rigidbodies[GenerateRandomMonster()], monsterPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
        monsterInstance.velocity = new Vector3(0, 0, 0);
    }

    //Generate a position on the xz plane for the monster to spawn at
    float[] GenerateRandomPosition()
    {
        //x is at index 0, z is at index 1
        float[] x_and_z = new float[2];

        float x = Random.Range(MIN_X, MAX_X);
        float z = Random.Range(MIN_Z, MAX_Z);

        return x_and_z;
    }

    //Generate a random monster index
    int GenerateRandomMonster()
    {
        int monster = Random.Range(1, NUM_MONSTERS);

        return monster;
    }
}
