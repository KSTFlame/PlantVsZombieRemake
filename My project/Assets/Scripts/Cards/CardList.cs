using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public static List<Card> list = new List<Card>();

    // Start is called before the first frame update
    void Awake()
    {
        list.Add(new Card(0, "a1", 1, 1, 1, "normalAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(1, "a2", 1, 1, 1, "attackAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(2, "a3", 1, 1, 1, "defenseAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(3, "a4", 1, 1, 1, "spikeAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(4, "a5", 3, 3, 5, "normalAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(5, "a6", 3, 3, 5, "attackAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(6, "a7", 3, 3, 5, "defenseAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(7, "a8", 3, 3, 5, "spikeAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(8, "a9", 5, 6, 8, "normalAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(9, "a10", 5, 6, 8, "attackAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(10, "a11", 5, 6, 8, "defenseAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(11, "a12", 5, 6, 8, "spikeAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(12, "d1", 1, 1, 1, "normalDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(13, "d2", 1, 1, 1, "attackDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(14, "d3", 1, 1, 1, "defenseDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(15, "d4", 1, 1, 1, "spikeDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(16, "d5", 3, 3, 5, "normalDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(17, "d6", 3, 3, 5, "attackDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(18, "d7", 3, 3, 5, "defenseDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(19, "d8", 3, 3, 5, "spikeDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(20, "d9", 5, 6, 8, "normalDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(21, "d10", 5, 6, 8, "attackDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(22, "d11", 5, 6, 8, "defenseDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(23, "d12", 5, 6, 8, "spikeDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(24, "s1", 1, 0, 1, "shield", Resources.Load<Sprite>("1")));
        list.Add(new Card(25, "ma1", 2, 0, 0, "attackDestroyMagicAngel", Resources.Load<Sprite>("1")));
        list.Add(new Card(26, "ma2", 2, 0, 0, "attackNexusMagicAngel", Resources.Load<Sprite>("1"))); 
        list.Add(new Card(27, "md1", 2, 0, 0, "attackDestroyMagicDevil", Resources.Load<Sprite>("1")));
        list.Add(new Card(28, "md2", 2, 0, 0, "attackNexusMagicDevil", Resources.Load<Sprite>("1")));
    }
}
