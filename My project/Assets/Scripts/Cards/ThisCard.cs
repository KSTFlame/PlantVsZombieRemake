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
    public int Cost;
    public int Power;
    public int Hp;
    public int totalHp;

    public Text HpText;
    public Text DmgText;

    public Sprite ThisSprite;
    public Image Image;

    public bool CardBack;
    public static bool StaticCardBack;

    public GameObject Hand;
    public GameObject CardToHand;

    public int NumberOfCardInDeck;

    public bool canBeSummon;
    public bool summoned;

    public GameObject battleZone1;
    public GameObject battleZone2;
    public GameObject battleZone3;
    public GameObject battleZone4;
    public GameObject battleZone5;

    public static int CardEffectId;

    // Start is called before the first frame update
    void Start()
    {
        //thisCard[0] = CardList.list[ThisId];
        NumberOfCardInDeck = PlayerDeck.StaticSize;

        canBeSummon = false;
        summoned = false;        
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            CardBack = false;
        }

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.StaticDeck[NumberOfCardInDeck - 1];
            NumberOfCardInDeck -= 1;
            PlayerDeck.StaticSize -= 1;
            CardBack = false;
            this.tag = "Untagged";
        }

        Id = thisCard[0].Id;
        Cost = thisCard[0].Cost;
        Power = thisCard[0].Power;
        Hp = thisCard[0].Hp;
        CardEffectId = thisCard[0].Effect;

        ThisSprite = thisCard[0].ThisImage;

        DmgText.text = "" + Power;

        if (summoned == false)
            HpText.text = "" + Hp;
        else
            HpText.text = "" + totalHp;

        Image.sprite = ThisSprite;

        StaticCardBack = CardBack;

        if (summoned == false)
        {
            canBeSummon = true;
        } else canBeSummon= false;

        if(StateManager.currentMana >= Cost && canBeSummon)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else gameObject.GetComponent<Draggable>().enabled = false;

        battleZone1 = GameObject.Find("YSummZone1");
        battleZone2 = GameObject.Find("YSummZone2");
        battleZone3 = GameObject.Find("YSummZone3");
        battleZone4 = GameObject.Find("YSummZone4");
        battleZone5 = GameObject.Find("YSummZone5");

        if(summoned==false && (this.transform.parent == battleZone1.transform || this.transform.parent == battleZone2.transform || this.transform.parent == battleZone3.transform || this.transform.parent == battleZone4.transform || this.transform.parent == battleZone5.transform))
        {
            gameObject.GetComponent<Draggable>().enabled = false;
            Summon();
        }
    }

    public void Summon()
    {
        Debug.Log("Summoned");
        switch (CardEffectId)
        {
            case 1: StartCoroutine(Draw());
                break;
            case 2:
                break;
            case 3:
                break;
            default: break;
        }
        StateManager.currentMana -= Cost;
        canBeSummon = false;
        summoned = true;
        totalHp = Hp;
    }

    private IEnumerator Draw()
    {
        yield return new WaitForSeconds(1);
        if(NumberOfCardInDeck > 0)
            Instantiate(CardToHand, transform.position, transform.rotation);
    }
}
