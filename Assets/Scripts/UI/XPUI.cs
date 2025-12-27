using UnityEngine;
using UnityEngine.UI;

public class XPUI : MonoBehaviour
{
    public Image fillImage;
    public PlayerXP playerXP;

    private void OnEnable()
    {
        playerXP.OnXPChanged += UpdateXP;
    }

    private void OnDisable()
    {
        playerXP.OnXPChanged -= UpdateXP;
    }

    private void UpdateXP(int current, int max)
    {
        fillImage.fillAmount = (float)current / max;
    }
}
