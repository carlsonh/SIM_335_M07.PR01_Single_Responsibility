using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class RegenHealth : MonoBehaviour, IHealth
{

    public event IHealth.UpdateHpBar Ev_UpdateHpBar;


    [SerializeField]
    private float timeUntilRegenStarts = 5f;


    private float damageTime = 0;


    [SerializeField]
    private int maxHp = 125;

    [SerializeField]
    private int currentHp;



    private void Start()
    {
        currentHp = maxHp;
    }


    public void Die()
    {
        GetComponent<NPCParticles>()?.PlayDeathParticle();
        GameObject.Destroy(this.gameObject);
    }

    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if ( currentHp <= 0)
        {
            Die();
            return;
        }

        damageTime = Time.time;
        UpdateHpBar();
    }

    internal void UpdateHpBar()
    {
        Ev_UpdateHpBar?.Invoke((float)currentHp/maxHp);
    }




    private void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(3);
        }

    }

    private void FixedUpdate() {
        
        var bCanUpdateHealth = Time.time >= damageTime + timeUntilRegenStarts;
        
        if(bCanUpdateHealth)
        {
            currentHp = Mathf.Min(++currentHp, maxHp);
            UpdateHpBar();
        }
    }
}