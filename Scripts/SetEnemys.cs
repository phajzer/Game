using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemys : MonoBehaviour {
    private static float num;
 

    public void SetEnem(float value)
    {
        num = value;
        
    
    }

    public static float EnemyValue
    {
        get
        {
            return num;
        }
        set
        {
            if (value < 0)
            {
                num = 1;
            }
            else
                num = value;
        }
    }

   
}
