using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/New Enemy", fileName = "New Enemy")] 
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    
    public float Health => health;
    public float Damage => damage;
    public float AttackSpeed => attackSpeed;
    public float AttackRange => attackRange;
}
