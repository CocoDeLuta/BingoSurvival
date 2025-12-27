using UnityEngine;

public enum ItemType
{
    Ammo,
    Currency,
    Heal,
    XP,
    Damage
}

[CreateAssetMenu(menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public string promptKey;

    public Sprite icon;
    public int amount;

    [Header("Ammo Settings")]
    public AmmoType ammoType; // <-- só usado se itemType == Ammo
}
