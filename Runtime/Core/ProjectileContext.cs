using UnityEngine;

namespace Hoang.ProjectileToolkit
{
    /// <summary>
    /// Runtime data supplied when a projectile is fired.
    /// </summary>
    public sealed class ProjectileContext
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Lifetime { get; set; } = 5f;
        public Vector2 Direction { get; set; }
        public Transform Target { get; set; }
        public IProjectileMovement Movement { get; set; }
    }
}
