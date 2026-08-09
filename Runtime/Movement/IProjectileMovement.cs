namespace Hoang.ProjectileToolkit
{
    /// <summary>
    /// Defines how a projectile moves during its lifetime.
    /// </summary>
    public interface IProjectileMovement
    {
        void Initialize(Projectile projectile, ProjectileContext context);
        void Tick(float deltaTime);
    }
}
