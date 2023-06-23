using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [Header("Config")]
    [SerializeField]
    private Image healthPlayer;

    [SerializeField]
    private TextMeshProUGUI healthTMP;

    private float actualHealth;
    private float maxHealth;

    private void Awake() {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        UpdateUICharacter();
    }

    private void UpdateUICharacter() {
        healthPlayer.fillAmount = Mathf.Lerp(healthPlayer.fillAmount, actualHealth / maxHealth, 10f * Time.deltaTime);

        healthTMP.text = $"{actualHealth}/{maxHealth}";
    }

    public void UpdateCharacterLife(float pActualHealth, float pMaxHealth)
    {
        actualHealth = pActualHealth;
        maxHealth = pMaxHealth;
    }
}
