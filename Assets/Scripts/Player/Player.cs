
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    [SerializeField] private float health = 100f;
    [SerializeField] private Weapon startWeapon;

    private List<Weapon> _weapons = new List<Weapon>();
    private bool _isAlive;

    public bool IsAlive => _isAlive;
    private int weaponIndex;
    
    private void Awake()
    {
        if(Instance == null)Instance = this;
        else if(Instance == this) Destroy(gameObject);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _isAlive = true;
        _weapons.Add(startWeapon);
    }

    private void Update()
    {
        ChangeWeapon();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickUpWeapon weapon))
        {
            _weapons.Add(weapon.WeaponToPickUp());
            weapon.PickUp();
        }
    }

    private void Die()
    {
        Camera.main.transform.parent = null;
        gameObject.SetActive(false);
    }

    private void ChangeWeapon()
    {
        if (_weapons.Count <= 1) return;
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _weapons[weaponIndex].Drop();
            weaponIndex++;

            if (weaponIndex >= _weapons.Count) weaponIndex = 0;
            
            _weapons[weaponIndex].PickUp();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        health -= damage;
        
        if(health <= 0) Die();
    }
}
