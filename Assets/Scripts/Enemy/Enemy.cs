using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject enemyData;
    
    private float _health;
    private float _damage;
    private float _attackSpeed;
    private float _attackRange;

    private bool _canAttack = true;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= _attackRange)
        {
            if (_canAttack && Player.Instance.IsAlive)
            {
                StartCoroutine(AttackDelay());
                print("Attack");
                Player.Instance.TakeDamage(_damage);
            }
        }
    }

    private void Initialize()
    {
        _health = enemyData.Health;
        _damage = enemyData.Damage;
        _attackSpeed = enemyData.AttackSpeed;
        _attackRange = enemyData.AttackRange;
    }

    private IEnumerator AttackDelay()
    {
        _canAttack = false;
        
        yield return new WaitForSeconds(_attackSpeed);
        
        _canAttack = true;
    }

    private void Die()
    {
        if (_health <= 0)
            gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            _health -= damage;
        
            Die();
        }
    }
}
