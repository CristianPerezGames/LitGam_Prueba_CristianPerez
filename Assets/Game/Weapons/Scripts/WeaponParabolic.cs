using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponParabolic : WeaponBase
{
    [Header("REFERENCES")]
    [SerializeField] private TrajectoryLine trajectoryLine;

    private float targetStrength;
    private bool activeShoot;

    public override void Init(WeaponController _weaponController)
    {
        base.Init(_weaponController);

        targetStrength = data.GetWeaponData.minSpeed;
        inCooldown = false;
    }

    public override void Tick(float _deltaTick)
    {
        base.Tick(_deltaTick);

        if(Input.GetMouseButtonDown(1)){
            activeShoot = true;
        }

        if(Input.GetMouseButton(1)){
            targetStrength += _deltaTick * data.GetWeaponData.increaseStrength;
            targetStrength = Mathf.Clamp(targetStrength, data.GetWeaponData.minSpeed, data.GetWeaponData.maxSpeed);
        }

        if(Input.GetMouseButtonUp(1) || inCooldown){
            activeShoot = false;
            targetStrength = data.GetWeaponData.minSpeed;
        }

        if(Input.GetMouseButtonDown(0) && !inCooldown){
            GameObject pooledObject = PoolManager.Instance.GetPooledObject("bullet");
            BulletBase newBullet = pooledObject.GetComponent<BulletBase>();
            newBullet.transform.position = spawnPosition.GetPosition;
            newBullet.Init(spawnPosition.GetDirection, targetStrength, data.GetBulletData);

            inCooldown = true;
        }
    }

    public override void LateTick(){
        if(!activeShoot || inCooldown){
            trajectoryLine.HideTrajectory();
            return;
        }

        trajectoryLine.DrawTrajectory(spawnPosition.GetPosition, spawnPosition.GetDirection, targetStrength, 1);
    }
}
