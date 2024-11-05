using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour, IPickable
{
    [SerializeField] private Weapon weapon;

    public Weapon WeaponToPickUp()
    {
        return weapon;
    }
    
    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    public void Drop()
    {
        gameObject.SetActive(true);
    }
}
