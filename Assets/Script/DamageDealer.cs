using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealer=10;
    public int GetDamage(){
        return damageDealer;
    }
    public void Hit(){
        Destroy(gameObject);
    }
    
}
