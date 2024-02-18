using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;

    void Start()
    {
        if (hp == 0)
        {
            hp = maxHp;
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
    }

    void Update()
    {
        
    }
}
