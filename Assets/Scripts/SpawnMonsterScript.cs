using UnityEngine;
using UnityEngine.Networking;

using System;

public class SpawnMonsterScript : NetworkBehaviour {

    //Number of monsters
    public const int NUM_MONSTERS = 30;

    //make the new monster
    public Monster thisMonster;

    //List of all RigidBodies
    //public Rigidbody[] rigidbodies = new Rigidbody[NUM_MONSTERS];
    public Rigidbody monster;

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

    //time of most recent spawn
    private float recentSpawn = 0.0f;

	// Use this for initialization
	void Start () {
        recentSpawn = Time.time;
        SpawnMonster();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > recentSpawn + timeInterval)
        {
            SpawnMonster();
            recentSpawn = Time.time;
        }
	}

    //Spawn a new enemy in a surrounding area
    void SpawnMonster()
    {
        //store position of the monster
        float[] monster_xz = GenerateRandomPosition();

        //initialize position of the enemy
        Vector3 monsterPosition = new Vector3(monster_xz[0], 0.0f, monster_xz[1]);

        //Create a new enemy instance
        Rigidbody monsterInstance = Instantiate(monster, monsterPosition, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
        monsterInstance.velocity = new Vector3(0, 0, 0);
    }

    //Generate a position on the xz plane for the monster to spawn at
    float[] GenerateRandomPosition()
    {
        //x is at index 0, z is at index 1
        float[] x_and_z = new float[2];

        float x = UnityEngine.Random.Range(MIN_X, MAX_X);
        float z = UnityEngine.Random.Range(MIN_Z, MAX_Z);

        x_and_z[0] = x;
        x_and_z[1] = z;

        return x_and_z;
    }

    //Generate a random monster index
    int GenerateRandomMonster()
    {
        //ambiguity between UnityEngine and System random
        System.Random rand = new System.Random();

        int monster = rand.Next(NUM_MONSTERS);
        Debug.Log(monster);

        return monster;
    }
}

public class Monster
{
    //Properties of a Monster
    String name;
    int attack;
    int defense;
    int hp;
    int currHP;
    int number;

    public Monster(String name, int attack, int defense, int hp, int number)
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
        this.hp = hp;
        currHP = hp;
        this.number = number;
    }
}

public class AccessMonsters
{
    Monster[] monsters = new Monster[5];

    Monster a = new Monster("", 5, 5, 5, 1);
    Monster b = new Monster("", 7, 7, 7, 2);
    Monster c = new Monster("", 9, 9, 9, 3);
    Monster d = new Monster("", 1, 1, 1, 4);
    Monster e = new Monster("", 5, 3, 9, 5);

    public void AddMonster()
    {
        monsters[0] = a;
        monsters[1] = b;
        monsters[2] = c;
        monsters[3] = d;
        monsters[4] = e;
    }
}
