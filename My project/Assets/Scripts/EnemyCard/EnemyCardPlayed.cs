using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class EnemyCardPlayed : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();

    public int Id;
    public int Power;
    public int Hp;

    public int NumberOfCardInDeck;

    public bool CardBack;

    public Text HpText;
    public Text DmgText;
    public Image Image;
    public Sprite ThisSprite;

    public void Start()
    {
        NumberOfCardInDeck = EnemyDeck.staticSize;
    }

    public void Update()
    {
        
        Id = thisCard[0].Id;
        Power = thisCard[0].Power;
        Hp = thisCard[0].Hp;
        ThisSprite = thisCard[0].ThisImage;

        DmgText.text = "" + Power;
        HpText.text = "" + Hp;

        Image.sprite = ThisSprite;

        if (this.tag == "enemyCard")
        {
            thisCard[0] = EnemyDeck.staticDeck[NumberOfCardInDeck - 1];
            NumberOfCardInDeck -= 1;
            EnemyDeck.staticSize -= 1;
            this.tag = "Untagged";
        }
    }
}
