using System;
using UnityEngine;

namespace Hoang.ProjectileToolkit
{
    /// <summary>
    /// Runtime projectile. Movement is delegated to an IProjectileMovement implementation.
    /// </summary>
    public sealed class Projectile : MonoBehaviour
    {
        public float Damage { get; private set; }
        public float Speed { get; private set; }
        public ProjectileContext Context { get; private set; }

        public event Action<Projectile> Expired;

        private IProjectileMovement movement;
        private float remainingLifetime;
        private bool initialized;

        public void Initialize(ProjectileContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Movement == null)
                throw new ArgumentException("ProjectileContext requires a movement implementation.", nameof(context));

            Context = context;
            Damage = context.Damage;
            Speed = context.Speed;
            remainingLifetime = Mathf.Max(0.01f, context.Lifetime);
            movement = context.Movement;
            movement.Initialize(this, context);
            initialized = true;
        }

        private void Update()
        {
            if (!initialized)
                return;

            movement.Tick(Time.deltaTime);
            remainingLifetime -= Time.deltaTime;

            if (remainingLifetime <= 0f)
                Expire();
        }

        public void Expire()
        {
            if (!initialized)
                return;

            initialized = false;
            Expired?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
