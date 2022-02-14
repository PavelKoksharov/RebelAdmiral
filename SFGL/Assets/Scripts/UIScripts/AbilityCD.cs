using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCD : MonoBehaviour
{
    [SerializeField]
    public Image[] coolDowns;

    public void SetCD(int abilityNumb)
    {
       coolDowns[abilityNumb].fillAmount = 1;
    }

    public void RadialCD(float[] cooldowns)
    {
        for(int i=cooldowns.Length-1; i>= 0; i-=1)
        {
            if (coolDowns[i].fillAmount >= 0)
            {
                coolDowns[i].fillAmount -= (Time.deltaTime / cooldowns[i]);
            }
        }
    }
}
