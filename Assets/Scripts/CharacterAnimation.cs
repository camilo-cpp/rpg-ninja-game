using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private string layerIdle;
    [SerializeField]
    private string layerWalk;
    private Animator _animator;
    private CharacterMovement _characterMovement;
    private readonly int directionX = Animator.StringToHash("X");
    private readonly int directionY = Animator.StringToHash("Y");

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
        UpdateLayer();

        if (!_characterMovement.isMoving)
        {
            return;
        }

        _animator.SetFloat(directionX, _characterMovement.movementDirection.x);
        _animator.SetFloat(directionY, _characterMovement.movementDirection.y);
    }

    private void ActivateLayer(string layerName)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(layerName), 1);
    }

    private void UpdateLayer()
    {
        if (_characterMovement.isMoving)
        {
            ActivateLayer(layerWalk);
        } else
        {
            ActivateLayer(layerIdle);
        }
    }
}
