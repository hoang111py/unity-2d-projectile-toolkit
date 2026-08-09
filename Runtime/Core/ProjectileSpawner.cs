using System;
using UnityEngine;

namespace Hoang.ProjectileToolkit
{
    /// <summary>
    /// Creates and initializes projectiles. Pooling will replace Instantiate in a later milestone.
    /// </summary>
    public sealed class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab;

        public Projectile Fire(ProjectileContext context, Vector3 position)
        {
            if (projectilePrefab == null)
                throw new InvalidOperationException("ProjectileSpawner requires a projectile prefab.");

            Projectile projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
            projectile.Initialize(context);
            return projectile;
        }
    }
}
