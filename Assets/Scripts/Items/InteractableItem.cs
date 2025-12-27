using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractableItem : MonoBehaviour
{
    public ItemData itemData;
    public Transform promptAnchor; // onde o texto aparece

    private void Reset()
    {
        // Garante que o collider seja trigger
        GetComponent<Collider>().isTrigger = true;
    }

    public void Interact(RunInventory playerInventory, PlayerXP playerXP, Weapon playerWeapon, PlayerHealth playerHealth)
    {
        ApplyEffect(playerInventory, playerXP, playerWeapon, playerHealth);
        Destroy(gameObject);
    }

    private void ApplyEffect(RunInventory playerInventory, PlayerXP playerXP, Weapon playerWeapon, PlayerHealth playerHealth)
    {
        switch (itemData.itemType)
        {
            case ItemType.Ammo:
                //print("Adding ammo: " + itemData.ammoType + " x" + itemData.amount);
                playerInventory.AddAmmo(itemData.ammoType, itemData.amount);
                playerWeapon.UpdateAmmoUI();
                break;
            case ItemType.XP:
                //print("Adding XP: " + itemData.amount);
                playerXP.AddXP(itemData.amount);
                break;
            case ItemType.Damage:
                playerHealth.TakeDamage(itemData.amount);
                break;

        }
    }
}
