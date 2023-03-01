using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{

    public GameObject Hand;
    public GameObject CardToHandPrefab;

    private void Start()
    {
        Hand = GameObject.Find("Hand");
        CardToHandPrefab.transform.SetParent(Hand.transform);
        CardToHandPrefab.transform.localScale = Vector3.one;
        CardToHandPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        CardToHandPrefab.transform.eulerAngles = new Vector3(25,0,0);
    }
}
