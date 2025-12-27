using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Fire Modes/Single Shot")]
public class SingleShotFire : FireMode
{
    public override void Fire(Weapon weapon)
    {
        weapon.SpawnProjectile(
            weapon.transform.forward,
            weapon.Data.damage
        );
    }
}
