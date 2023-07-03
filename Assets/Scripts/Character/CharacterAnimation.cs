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
    private readonly int dead = Animator.StringToHash("Dead");

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

    public void ReviveCharacter() {
        ActivateLayer(layerIdle);
        _animator.SetBool(dead, false);
    }

    private void ResponseDefeatCharacter()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1)
        {
            _animator.SetBool(dead, true);
        }
    }

    private void OnEnable()
    {
        CharacterLife.EventDeadCharacter += ResponseDefeatCharacter;
    }

    private void OnDisabled()
    {
        CharacterLife.EventDeadCharacter -= ResponseDefeatCharacter;
    }
}
