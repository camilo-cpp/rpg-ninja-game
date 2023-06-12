using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private CharacterMovement _characterMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterMovement = GetComponent<CharacterMovement>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (_characterMovement.isMoving == false)
        {
            return;
        }

        _animator.SetFloat("X", _characterMovement.movementDirection.x);
        _animator.SetFloat("Y", _characterMovement.movementDirection.y);
    }
}
