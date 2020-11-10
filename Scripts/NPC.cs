using System;
using UnityEngine;
using UnityEngine.Events;


public class NPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 90f;

    //Update Health Bar

    // private void Update()
    // {
    //     transform.position += transform.forward * moveSpeed * Time.deltaTime;
    //     transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);

    // }

}