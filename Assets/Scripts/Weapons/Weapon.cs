using UnityEngine;
using System.Collections;
using System;


public class Weapon : MonoBehaviour
{
    public event Action<int, int> OnAmmoChanged;
    public WeaponData Data { get; private set; }

    private int currentAmmo;
    private bool isReloading;
    private float nextFireTime;

    private RunInventory inventory;
    private Animator animator;

    public int CurrentAmmo => currentAmmo;
    public bool IsReloading => isReloading;

    public void Initialize(WeaponData data, RunInventory inv)
    {
        Data = data;
        inventory = inv;

        currentAmmo = data.magazineSize;

        // Limpa modelo antigo
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Instancia modelo
        if (Data.modelPrefab != null)
            Instantiate(Data.modelPrefab, transform);

        animator = GetComponentInChildren<Animator>();
        animator.runtimeAnimatorController = Data.animationProfile.animator;

        isReloading = false;

        UpdateAmmoUI();
    }

    public void TryFire()
    {
        if (isReloading) return;
        if (Time.time < nextFireTime) return;
        if (currentAmmo <= 0) return;

        currentAmmo--;
        nextFireTime = Time.time + (1f / Data.fireRate);

        Data.fireMode.Fire(this);
        animator.SetTrigger(Data.animationProfile.shootTrigger);
        UpdateAmmoUI();
    }

    public void TryReload()
    {
        if (isReloading) return;
        if (currentAmmo >= Data.magazineSize) return;

        int availableAmmo = inventory.GetAmmo(Data.ammoType);
        if (availableAmmo <= 0) return;

        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        isReloading = true;
        animator.SetTrigger(Data.animationProfile.reloadTrigger);

        //comentado para testes, usando reload instantaneo
        yield return new WaitForSeconds(0f);
        //yield return new WaitForSeconds(Data.reloadTime);

        int needed = Data.magazineSize - currentAmmo;
        int available = inventory.GetAmmo(Data.ammoType);

        int reloadAmount = Mathf.Min(needed, available);

        inventory.ConsumeAmmo(Data.ammoType, reloadAmount);
        currentAmmo += reloadAmount;

        isReloading = false;
        UpdateAmmoUI();
    }


    // Chamado pelo FireMode
    public void SpawnProjectile(Vector3 direction, float damage)
    {
        // Raycast ou projétil físico
        //print("Spawned projectile with damage: " + damage);
        Camera cam = Camera.main;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

            // if (hit.collider.TryGetComponent(out Enemy enemy))
            // {
            //     enemy.TakeDamage(finalDamage);
            // }
        }

    }

    public void UpdateAmmoUI()
    {
        int inventoryAmmo = inventory.GetAmmo(Data.ammoType);
        OnAmmoChanged?.Invoke(currentAmmo, inventoryAmmo);
    }

}