using System;

[Serializable]
public class Weapon{
    public WeaponType type;
    public WeaponBase weapon;
}

public enum WeaponType{
    None = -1,
    Parabolic = 0,
    Attraction = 1,
    Rocket = 2
}
