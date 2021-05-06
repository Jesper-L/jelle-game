using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]
    private Image[] hp;

    [SerializeField]
    private Sprite[] hpSprite;

    private playerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hp.Length; i++)
        {
            if(i >= pc.HP)
            {
                hp[i].sprite = hpSprite[1];
            }
            else
            {
                hp[i].sprite = hpSprite[0];
            }
        }
    }
}
