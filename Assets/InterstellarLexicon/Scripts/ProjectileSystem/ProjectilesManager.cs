using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProjectileSystem
{
    public class ProjectilesManager : GloballyAccessibleBase<ProjectilesManager>
    {
        public event Action<Transform> OnTargetShot;

        [SerializeField] private List<GameObject> projectilePrefabs;
        [SerializeField] private Transform projectilesParent;
        [SerializeField] private float projectileLaunchDistance;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField] private Transform planet;
        [SerializeField] private float planetRadius;

        public void ShootTarget(Transform target)
        {
            var projectile = Instantiate(projectilePrefabs.GetRandomElement(), projectilesParent).GetComponent<Projectile>();
            projectile.transform.position = RandomPointOnPlanet(planetRadius, planet);
            projectile.name = $"Projectile_{target.name}";

            Vector3[] projectilePath = new Vector3[]
            {
                (projectile.transform.position - planet.position).normalized * projectileLaunchDistance + projectile.transform.position,
                target.position
            };

            projectile.OnHit += () => ProjectileHitTarget(target, projectile);
            projectile.ShootTarget(projectilePath, projectileSpeed, animationCurve);
        }

        private void ProjectileHitTarget(Transform target, Projectile projectile)
        {
            OnTargetShot?.Invoke(target);
            Destroy(projectile.gameObject);
        }

        private Vector3 RandomPointOnPlanet(float radius, Transform planet)
        {
            var vector2 = UnityEngine.Random.insideUnitCircle.normalized * radius;
            return new Vector3(Mathf.Abs(vector2.x), vector2.y, 0f) + planet.transform.position;
        }

#if UNITY_EDITOR
        [SerializeField] private bool drawPlanetRadiusGizmos;
        [SerializeField] private Color gizmosColor;
        private void OnDrawGizmos()
        {
            if (!drawPlanetRadiusGizmos) return;
            if (planet == null) return;

            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(planet.position, planetRadius);
        }
#endif
    }
}