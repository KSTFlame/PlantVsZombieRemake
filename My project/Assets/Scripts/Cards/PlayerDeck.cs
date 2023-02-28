using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public static List<Card> StaticDeck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int Size;
    public static int StaticSize;
    
    private int randomCardId;

    public int StartingHand;

    private int m_RandomIndex;

    public GameObject Hand;
    public GameObject CardToHand;

    private void Start()
    {
        for(int i = 0; i < Size; i++)
        {
            randomCardId = Random.Range(0, 12);
            deck[i] = CardList.list[randomCardId];
            //Debug.Log("deck["+i+"]: "+ deck[i]);
        }
        StaticSize = Size;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        StaticDeck = deck;
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i<StartingHand; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < Size; i++)
        {
            container[0] = deck[i];
            m_RandomIndex = Random.Range(i, Size);
            deck[i] = deck[m_RandomIndex];
            deck[m_RandomIndex] = container[0];
        }
    }
}
