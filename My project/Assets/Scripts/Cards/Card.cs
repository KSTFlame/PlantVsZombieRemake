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

    public Sprite ThisImage;

    public Card()
    {

    }

    public Card(int id, string cardName, int cost, int power, int hp, string cardDescription, Sprite thisImage)
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
