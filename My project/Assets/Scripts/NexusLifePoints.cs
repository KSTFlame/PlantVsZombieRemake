using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexusLifePoints : MonoBehaviour
{

    public int enemyNexusHp;
    public int yourNexusHp;
    public Text enemyHpText;
    public Text yourHpText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpText.text = "Enemy Hp: " + enemyNexusHp;
        yourHpText.text = "Your Hp: " + yourNexusHp;

        if (enemyNexusHp <= 0 || yourNexusHp <= 0)
        {
            Application.Quit();
            Debug.Log("GGEZ");
        }
    }
}
