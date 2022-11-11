using System.Collections.Generic;
using UnityEngine;

public class Orbs : ActiveSkill
{
    public RotatingProjectile projectile;
    public List<RotatingProjectile> spawnedProjectile = new List<RotatingProjectile>();
    public int maxOrb = 1;
    private const float radius = 1f;

    public override void Action()
    {
        base.Action();
        if (spawnedProjectile.Count < maxOrb)
        {
            var obj = Instantiate(projectile);
            obj.rotateAround = transform;
            obj.transform.position = transform.position + Vector3.forward;
            spawnedProjectile.Add(obj);

            if (spawnedProjectile.Count > 0)
            {
                int i = 0;
                foreach (RotatingProjectile orb in spawnedProjectile)
                {
                    orb.angle = 6.29f / spawnedProjectile.Count * i;
                    i++;
                }
            }
        }
    }

    public override void OnLevelUp()
    {
        base.OnLevelUp();
        maxOrb++;
    }
}