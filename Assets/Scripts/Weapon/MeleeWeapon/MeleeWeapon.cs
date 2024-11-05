using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var colliders = Physics.OverlapSphere(this.transform.position, attackRange);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(Damage);
                }
            }
        }
    }
}
