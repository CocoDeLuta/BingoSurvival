using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;
    public RunInventory inventory;
    public WeaponData testWeaponData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //WeaponData startWeapon = GameState.Instance.selectedLoadout[0];
        currentWeapon.Initialize(testWeaponData, inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon == null) return;

        if (InputManager.Instance.IsFiring)
        {
            currentWeapon.TryFire();
        }
    }

    
}
