using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public GameObject EnemyCard;

    public int size;
    public static int staticSize;

    public void Start()
    {
        size = 5;
        staticSize = size;

        deck[4] = CardList.list[12];
        deck[3] = CardList.list[12];
        deck[2] = CardList.list[12];
        deck[1] = CardList.list[16];
        deck[0] = CardList.list[20];
        StartCoroutine(StartGame());
    }

    public void Update()
    {
        staticDeck = deck;
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(EnemyCard, transform.position, transform.rotation);
        }
    }
}
