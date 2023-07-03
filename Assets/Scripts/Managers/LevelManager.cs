using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField]
    private Transform respawnPoint;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (character.CharacterLife.DeadCharacter)
            {
                character.transform.localPosition = respawnPoint.position;
                character.ReviveCharacter();
            }
        }
    }
}
