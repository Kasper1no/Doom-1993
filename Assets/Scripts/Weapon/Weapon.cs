using UnityEngine;

public abstract class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] protected float Damage;
    [SerializeField] protected float attackRange;

    protected abstract void Attack();

    public void PickUp()
    {
        gameObject.SetActive(true);
    }

    public void Drop()
    {
        gameObject.SetActive(false);
    }
}
