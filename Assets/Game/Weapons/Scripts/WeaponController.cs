using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour{

    [Header("DATA")]
    [SerializeField] private Weapon[] weapons;
    
    [Header("REFERENCES")]
    [SerializeField] private SpawnPosition spawnPosition;

    [Header("RUNTIME")]
    [SerializeField] private List<Weapon> lastWeapons;
    [SerializeField] private Weapon current;

    public SpawnPosition GetSpawnPosition => spawnPosition;

    private CharacterController characterController;

    public void Init(CharacterController _characterController){
        characterController = _characterController;

        InitWeapon();
    }

    private void Update() {
        if(current.weapon == null) return;
        current.weapon.Tick(Time.deltaTime);
    }

    private void LateUpdate() {
        if(current.weapon == null) return;
        current.weapon.LateTick();
    }

    public void SetWeapon(WeaponType _weaponType){
        if(_weaponType.Equals(current.type)){
                return;
        }
        //checks if there is a weapon
        for (int i = 0; i < lastWeapons.Count; i++) {
            if(lastWeapons[i].type.Equals(_weaponType)){
                SetWeapon(lastWeapons[i]);
                return;
            }
        }
        //creates a weapon
        for (int i = 0; i < weapons.Length; i++){
            if(_weaponType.Equals(weapons[i].type)){
                CreateWeapon(weapons[i]);
                return;
            }
        }
    }

    void CreateWeapon(Weapon _weapon){
        FinishWeapon();

        WeaponBase newWeapon = Instantiate(_weapon.weapon, this.transform);
        newWeapon.transform.localPosition = Vector3.zero;

        Weapon weaponObject = new Weapon(){
            type = _weapon.type,
            weapon = newWeapon
        };
        current = weaponObject;
        lastWeapons.Add(weaponObject);

        InitWeapon();
    }

    void SetWeapon(Weapon _weapon){
        FinishWeapon();
        current = _weapon;
        InitWeapon();
    }

    void InitWeapon(){
        if(current.weapon) current.weapon.Init(this);
    }

    void FinishWeapon(){
        if(current.weapon) current.weapon.Finish();
    }
}
