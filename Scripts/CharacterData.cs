using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    [SerializeField] Image          headPj;
    [SerializeField] Image          maskPj;
    [SerializeField] Image          earPj;
    [SerializeField] GameObject     rename;
    [SerializeField] InputField     inputFieldNameUser;
    [SerializeField] Text           textNamePj;
    [SerializeField] Text           textLevelPj;
    [SerializeField] Text           textExpPj;

                     bool           active;
                     int            lvlPj = 1;
                     float          expPj = 0, expToNextLevel = 100f;

    void Start()
    {
        rename.SetActive(active);
        textLevelPj.text            = lvlPj.ToString();
        textExpPj.text              = expPj.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            AddExperience(20f);

        }
        if (Input.GetKeyDown("z"))
        {
            DiscountExperience(10f);
        }
    }

    public void ChangeName()
    {
        active = (active) ? false : true;
        rename.SetActive(active);
        Time.timeScale = (active) ? 0 : 1f;
    }

    public void AssignName()
    {
        textNamePj.text = inputFieldNameUser.text;
        active = (active) ? false : true;
        rename.SetActive(active);
        Time.timeScale = (active) ? 0 : 1f;

    }

    public void AddExperience(float amount)
    {
        expPj += amount;
        textExpPj.text = expPj.ToString();
        if(expPj >= expToNextLevel)
        {
            lvlPj++;
            textLevelPj.text = lvlPj.ToString();
            expToNextLevel *= 2;
        }
    }
    public void DiscountExperience(float amount)
    {
        if(expPj > 0)
        {
            expPj -= amount;
            textExpPj.text = expPj.ToString();
        }
        else
        {
            expPj = 0;
            textExpPj.text = expPj.ToString();
        }
    }
}
