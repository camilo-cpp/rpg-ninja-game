using UnityEngine;

public class Character : MonoBehaviour {
    public CharacterLife CharacterLife { get; private set; }
    public CharacterAnimation CharacterAnimation { get; private set; }

    private void Awake() {
        CharacterLife = GetComponent<CharacterLife>();
        CharacterAnimation = GetComponent<CharacterAnimation>();
    }

    public void ReviveCharacter() {
        CharacterLife.ReviveCharacter();
        CharacterAnimation.ReviveCharacter();
    }
}