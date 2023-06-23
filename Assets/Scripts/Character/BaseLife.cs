using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLife : MonoBehaviour
{
    [SerializeField]
    protected float initHealth;
    [SerializeField]
    protected float MaxHealth;

    public float Health{ get; protected set; }

    protected virtual void Start()
    {
        Health = initHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }

        if (Health > 0)
        {
            Health -= damage;
            UpdateBarLife(Health, MaxHealth);

            if (Health <= 0)
            {
                UpdateBarLife(Health, MaxHealth);
                DefeatedCharacter();
            }
        }
    }

    protected virtual void UpdateBarLife(float actualLife, float maxLife)
    {

    }

    protected virtual void DefeatedCharacter()
    {

    }
}
