using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterLife : BaseLife
{
    public static Action EventDeadCharacter;
    public bool CanHealth => Health < MaxHealth;

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

    }

    protected override void DefeatedCharacter()
    {
        EventDeadCharacter?.Invoke();

        //if (EventDeadCharacter != null)
        //{
        //    EventDeadCharacter.Invoke();
        //}
    }
}