using System;

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
    private static Monster[] monsters = new Monster[5];

    Monster a = new Monster("", 5, 5, 5, 1);
    Monster b = new Monster("", 7, 7, 7, 2);
    Monster c = new Monster("", 9, 9, 9, 3);
    Monster d = new Monster("", 1, 1, 1, 4);
    Monster e = new Monster("", 5, 3, 9, 5);

    //add all the monsters to the pool of monsters (no back end yet)
    public void AddMonster()
    {
        monsters[0] = a;
        monsters[1] = b;
        monsters[2] = c;
        monsters[3] = d;
        monsters[4] = e;
    }


    //get the monster at the specified index
    public static Monster GetMonster(int i)
    {
        return monsters[i];
    }
}