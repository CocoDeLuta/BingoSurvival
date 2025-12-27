using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image fillImage;
    public PlayerHealth playerHealth;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int current, int max)
    {
        fillImage.fillAmount = (float)current / max;
    }
}
