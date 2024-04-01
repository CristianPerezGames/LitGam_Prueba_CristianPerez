using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;

    public WeaponType GetWeapon => weaponType;
}
