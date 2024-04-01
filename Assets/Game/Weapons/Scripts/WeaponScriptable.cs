using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "LTG/Weapon", order = 0)]
public class WeaponScriptable : ScriptableObject {
    
    [Header("WEAPON")]
    [SerializeField] private WeaponData weaponData;
    
    [Header("BULLET")]
    [SerializeField] private BulletData bulletData;

    public WeaponData GetWeaponData => weaponData;
    public BulletData GetBulletData => bulletData;
}