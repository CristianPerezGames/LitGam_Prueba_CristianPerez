using System;
using UnityEngine;

[Serializable]
public class WeaponData
{
    public WeaponType name;
    public string displayName;
    public float minSpeed = 2f;
    public float maxSpeed = 15f;
    public float increaseStrength = 5f;
    public float firingInterval = 1f;
    public float cooldownShot = 1f;
    public float damage = 10;
}