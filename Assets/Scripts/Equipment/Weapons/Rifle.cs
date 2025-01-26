using UnityEngine;
public class Rifle : Gun
{
    public override void Shoot()
    {
        base.Shoot();
        if (projectile)
        {
            Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        }
        currentAmmo--;
    }

    public override void Reload()
    {
        base.Reload();
        currentAmmo = maxAmmo;
    }
}
