using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {


    public void TakeDamage(int amount)
    {
        Destroy(gameObject);

       
    }
}
