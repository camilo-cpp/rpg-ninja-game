using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterLife : BaseLife
{
    public static Action EventDeadCharacter;

    public bool DeadCharacter { get; private set; }
    public bool CanHealth => Health < MaxHealth;

    private BoxCollider2D _boxCollider2D;

    private void Awake() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateBarLife(Health, MaxHealth);
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestoreHealth(10);
        }
    }

    public void RestoreHealth(float quantity)
    {
        if (CanHealth)
        {
            Health += quantity;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            UpdateBarLife(Health, MaxHealth);
        }
    }

    protected override void UpdateBarLife(float actualLife, float maxLife)
    {
        UiManager.Instance.UpdateCharacterLife(actualLife, maxLife);
    }

    protected override void DefeatedCharacter()
    {
        DeadCharacter = true;
        EventDeadCharacter?.Invoke();
        _boxCollider2D.enabled = false;

        //if (EventDeadCharacter != null)
        //{
        //    EventDeadCharacter.Invoke();
        //}
    }

    public void ReviveCharacter() {
        _boxCollider2D.enabled = true;
        DeadCharacter = false;
        Health = initHealth;
        UpdateBarLife(Health, initHealth);
    }
}