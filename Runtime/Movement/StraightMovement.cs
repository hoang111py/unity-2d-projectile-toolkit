using UnityEngine;

namespace Hoang.ProjectileToolkit
{
    /// <summary>
    /// Moves a projectile in a fixed direction at its configured speed.
    /// </summary>
    public sealed class StraightMovement : IProjectileMovement
    {
        private Projectile projectile;
        private Vector2 direction;

        public void Initialize(Projectile projectile, ProjectileContext context)
        {
            this.projectile = projectile;
            direction = context.Direction.sqrMagnitude > 0f
                ? context.Direction.normalized
                : Vector2.right;
        }

        public void Tick(float deltaTime)
        {
            projectile.transform.position +=
                (Vector3)(direction * projectile.Speed * deltaTime);
        }
    }
}
