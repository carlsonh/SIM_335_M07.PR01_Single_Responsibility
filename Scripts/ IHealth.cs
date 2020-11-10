using UnityEngine;

public interface IHealth
{
    public delegate void UpdateHpBar(float curHpPct);

    public event UpdateHpBar Ev_UpdateHpBar;

    

    public void TakeDamage(int dmg);

    public void Die();



}