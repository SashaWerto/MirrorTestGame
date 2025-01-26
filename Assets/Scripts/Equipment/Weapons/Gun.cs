using UnityEngine;
public class Gun : Weapon
{
    [Header("References")] 
    public Transform muzzlePoint;
    [Header("Prefabs")]
    public GameObject projectile;
    [Header("Settings")] 
    public int currentAmmo;
    public int maxAmmo;
    public float fireDelay = 0.1f;
    private protected float currentDelay;
    private void OnEnable()
    {
        Inputs.OnPrimaryHoldAction += HandleShoot;
        Inputs.OnReloadAction += HandleReload;
    }

    private void OnDisable()
    {
        Inputs.OnPrimaryHoldAction -= HandleShoot;
        Inputs.OnReloadAction -= HandleReload;
    }

    public override void Update()
    {
        base.Update();
        currentDelay -= Time.deltaTime;
    }
    public void HandleShoot()
    {
        if (currentAmmo <= 0 || animState.IsTag("isBusy") || currentDelay > 0) return;
        animator.SetTrigger("Shoot");
        Shoot();
    }
    public void HandleReload()
    {
        if(currentAmmo >= maxAmmo || animState.IsTag("isBusy")) return;
        animator.SetTrigger("Reload");
    }

    public virtual void Reload()
    {
        
    }

    public virtual void Shoot()
    {
        currentDelay = fireDelay;
    }
}
