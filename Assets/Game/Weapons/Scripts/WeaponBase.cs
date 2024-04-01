using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBase : MonoBehaviour
{
    [Header("DATA")]
    [SerializeField] protected WeaponScriptable data;
    
    protected WeaponController weaponController;
    protected SpawnPosition spawnPosition;

    [Header("UI")]
    [SerializeField] private Image cooldownUI;
    [SerializeField] private Image cooldownFill;

    protected bool inCooldown;
    private float elapseCooldown;

    public virtual void Init(WeaponController _weaponController){
        weaponController = _weaponController;
        spawnPosition = _weaponController.GetSpawnPosition;
        gameObject.SetActive(true);
    }

    public virtual void Finish(){
        gameObject.SetActive(false);
    }

    public virtual void Tick(float _deltaTick){ 
        if(inCooldown){
            cooldownUI.gameObject.SetActive(true);
            elapseCooldown += _deltaTick;
            cooldownFill.fillAmount = elapseCooldown / data.GetWeaponData.cooldownShot;
            if(elapseCooldown >= data.GetWeaponData.cooldownShot){
                elapseCooldown = 0;
                inCooldown = false;
            }
        }
        else{
            cooldownUI.gameObject.SetActive(false);
        }
    }

    public virtual void LateTick(){ }
}
