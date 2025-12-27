using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Ammo Type")]
public class AmmoType : ScriptableObject
{
    public string ammoName;

    [Header("UI")]
    public Sprite icon;

    [Header("Rules")]
    public int baseMaxCapacity;

    [Tooltip("Ex: pistolas, SMGs")]
    public string description;
}
