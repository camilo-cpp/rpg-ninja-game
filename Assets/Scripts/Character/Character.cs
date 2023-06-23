using UnityEngine;

public class Character : MonoBehaviour {
    private CharacterLife _characterLife;

    private void Awake() {
        _characterLife = GetComponent<CharacterLife>();
    }

    public void ReviveCharacter() {
        _characterLife.ReviveCharacter();
    }
}