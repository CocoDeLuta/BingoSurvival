using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Animation Profile")]
public class WeaponAnimationProfile : ScriptableObject
{
    public RuntimeAnimatorController animator;
    public string shootTrigger = "Shoot";
    public string reloadTrigger = "Reload";
}
