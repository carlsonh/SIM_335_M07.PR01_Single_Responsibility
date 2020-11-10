using System.Collections;
using UnityEngine;

public class NumHitHealth : MonoBehaviour, IHealth
{

    public event IHealth.UpdateHpBar Ev_UpdateHpBar;



    private bool bCanTakeDamage = true;

    [SerializeField]
    private float invulnTime = 5f;


    [SerializeField]
    private int maxHitHealth = 5;

    private int hitsRemain;


    private void Start(){
        hitsRemain = maxHitHealth;
    }


    public void Die()
    {
        GetComponent<NPCParticles>().PlayDeathParticle();
        GameObject.Destroy(this.gameObject);

    }

    public void TakeDamage(int dmg)
    {
        if(bCanTakeDamage)
        {
            StartCoroutine(InvulnWait());
            hitsRemain--;
            Ev_UpdateHpBar?.Invoke((float)hitsRemain/maxHitHealth);

            if (hitsRemain == 0)
            {
                Die();
            }
        }
    }

    private IEnumerator InvulnWait()
    {
        bCanTakeDamage = false;
        yield return new WaitForSeconds(invulnTime);
        bCanTakeDamage = true;
    }



        private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
}
