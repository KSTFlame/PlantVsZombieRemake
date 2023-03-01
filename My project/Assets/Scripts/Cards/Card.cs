using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public int Id;
    public string CardName;
    public int Cost;
    public int Power;
    public int Hp;
    public string CardDescription;
    public int Effect;  //1 - Draw, 2 - 1 dmg to enemy nexus

    public Sprite ThisImage;

    public Card()
    {

    }

    public Card(int id, string cardName, int cost, int power, int hp, string cardDescription, Sprite thisImage, int effect) //Monster
    {
        Id = id;
        CardName = cardName;
        Cost = cost;
        Power = power;
        Hp = hp;
        CardDescription = cardDescription;
        ThisImage = thisImage;
        Effect = effect;
    }

    public Card(int id, string cardName, int cost, int power, int hp, string cardDescription, Sprite thisImage) //Spell and Shield
    {
        Id = id;
        CardName = cardName;
        Cost = cost;
        Power = power;
        Hp = hp;
        CardDescription = cardDescription;
        ThisImage = thisImage;
    }
}
