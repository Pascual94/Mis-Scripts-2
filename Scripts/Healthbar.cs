using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Image    health;
    [SerializeField] Text     textHealth;
                     float    hp, maxHp = 100f;

    void Awake()
    {
        hp = maxHp;
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        health.transform.localScale = new Vector2(hp / maxHp, 1);
        textHealth.text = hp.ToString();
        if (hp == 0f)
        {
            
        }
    }

}
