using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyCardToHand : MonoBehaviour
{
    public GameObject EnemyHand;
    public GameObject EnemyCardPrefab;



    // Start is called before the first frame update
    void Start()
    {
        EnemyHand = GameObject.Find("EnemyHand");
        EnemyCardPrefab.transform.SetParent(EnemyHand.transform);
        EnemyCardPrefab.transform.localScale = Vector3.one;
        EnemyCardPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        EnemyCardPrefab.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
