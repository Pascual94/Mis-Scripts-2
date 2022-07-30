using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject systemPause;
    [SerializeField] GameObject systemLose;
    [SerializeField] GameObject systemYouWin;
    [SerializeField] Text textMonedas;
    [SerializeField] Healthbar healthbar;
    [SerializeField] CharacterData characterData;

    int coins;

    void Start()
    {
        systemYouWin.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown("c"))
        {
            systemYouWin.SetActive(!systemYouWin.activeInHierarchy);
        }
        // Prueba BarrExperience
        if (Input.GetKeyDown("z"))
        {
            characterData.AddExperience(20f);
        }
        if (Input.GetKeyDown("x"))
        {
            characterData.DiscountExperience(10f);
        }

        // Prueba Healthbar
        if (Input.GetKeyDown("i"))
        {
            healthbar.TakeDamage(20f);
        }


        // Prueba Coins
        if (Input.GetKeyDown("m"))
        {
            coins += 20;
            textMonedas.text = coins.ToString();
        }
        if (Input.GetKeyDown("n"))
        {
            coins -= 10;
            textMonedas.text = coins.ToString();
        }
        if(coins <= 0)
        {
            coins = 0;
            textMonedas.text = coins.ToString();
        } 

        // Test Pause
        if (Input.GetKeyDown("p"))
        {
            systemPause.SetActive(!systemPause.activeInHierarchy);
            Time.timeScale = (!systemPause.activeInHierarchy) ? 1f : 0;

        }

        // Test Play Again
        if (Input.GetKeyDown("v"))
        {
            systemLose.SetActive(!systemLose.activeInHierarchy);
            Time.timeScale = (!systemLose.activeInHierarchy) ? 1f : 0;
        }
    } 
}
