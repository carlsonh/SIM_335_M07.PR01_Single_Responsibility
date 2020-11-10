using UnityEngine;
using UnityEngine.Events;

public class HPBar : MonoBehaviour
    {
    [SerializeField] private UnityEngine.UI.Slider hpBarSlider = null;


    private void Awake() => GetComponent<IHealth>().Ev_UpdateHpBar += UpdateHP;

    private void UpdateHP(float currentHpPct)
    {
        hpBarSlider.value = currentHpPct;
    }

    

    private void Update() => hpBarSlider.transform.LookAt(Camera.main.transform);
}
