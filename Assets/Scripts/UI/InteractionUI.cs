using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text;
    public GameObject iconSprite;

    private void Awake()
    {
        Hide();
    }

    public void Show(Vector3 worldPosition, string message, Sprite icon )
    {
        canvas.enabled = true;
        text.text = message;
        transform.position = worldPosition;
        iconSprite.GetComponent<UnityEngine.UI.Image>().sprite = icon;

    }

    public void UpdatePosition(Vector3 worldPosition)
    {
        transform.position = worldPosition;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}
