using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public TMP_Text ammoText;
    public Weapon weapon;

    private void OnEnable()
    {
        weapon.OnAmmoChanged += UpdateAmmo;
    }

    private void OnDisable()
    {
        weapon.OnAmmoChanged -= UpdateAmmo;
    }

    private void UpdateAmmo(int inMagazine, int inInventory)
    {
        ammoText.text = $"{inMagazine} / {inInventory}";
    }
}
