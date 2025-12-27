using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public string weaponName;
    public Sprite icon;

    [Header("Ammo")]
    public AmmoType ammoType;
    public int magazineSize;

    [Header("Stats")]
    public float damage;
    public float fireRate; // tiros por segundo
    public float reloadTime;

    [Header("Behavior")]
    public FireMode fireMode;
    public WeaponAnimationProfile animationProfile;

    [Header("Visual")]
    public GameObject modelPrefab;
}
