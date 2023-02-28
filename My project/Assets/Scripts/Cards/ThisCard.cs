using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> thisCard = new List<Card>();
    public int ThisId;

    public int Id;
    public int Power;
    public int Hp;

    public Text HpText;
    public Text DmgText;

    public Sprite ThisSprite;
    public Image Image;

    public bool CardBack;
    public static bool StaticCardBack;

    public GameObject Hand;

    public int NumberOfCardInDeck;

    // Start is called before the first frame update
    void Start()
    {
        //thisCard[0] = CardList.list[ThisId];
        NumberOfCardInDeck = PlayerDeck.StaticSize;
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            CardBack = false;
        }

        Id = thisCard[0].Id;
        Power = thisCard[0].Power;
        Hp = thisCard[0].Hp;

        ThisSprite = thisCard[0].ThisImage;

        DmgText.text = "" + Power;
        HpText.text = "" + Hp;

        Image.sprite = ThisSprite;

        StaticCardBack = CardBack;

        if(this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.StaticDeck[NumberOfCardInDeck - 1];
            NumberOfCardInDeck -= 1;
            PlayerDeck.StaticSize -= 1;
            CardBack = false;
            this.tag = "Untagged";
        }
    }
}
