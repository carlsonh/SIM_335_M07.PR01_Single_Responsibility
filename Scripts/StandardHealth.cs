using UnityEngine;
using System;

public class StandardHealth : MonoBehaviour, IHealth {
    
    [SerializeField] private int currentHp;
    [SerializeField] private int startingHp = 100;


    public event IHealth.UpdateHpBar Ev_UpdateHpBar;



    private void Start()
    {
        currentHp = startingHp;
    }


    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHp -= amount;

        Ev_UpdateHpBar?.Invoke((float)currentHp/startingHp);

        if (currentHp <= 0)
            Die();
    }



    public void Die()
    {
        // PlayDeathParticle();
        // NPCParticles.PlayDeathParticle();

        GetComponent<NPCParticles>().PlayDeathParticle();
        GameObject.Destroy(this.gameObject);
    }


    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(startingHp / 10);
        }
    }

}