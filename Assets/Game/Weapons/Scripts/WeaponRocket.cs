using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : WeaponBase{
    Vector3 position;
    Vector3 direction;

    public override void Init(WeaponController _weaponController){
        base.Init(_weaponController);
    }

    public override void Tick(float _deltaTick) {
        base.Tick(_deltaTick);

        if(Input.GetMouseButtonDown(0) && !inCooldown){
            GameObject pooledObject = PoolManager.Instance.GetPooledObject("bulletRocket");
            BulletRocket newBullet = pooledObject.GetComponent<BulletRocket>();
            position = spawnPosition.GetPosition;
            newBullet.transform.position = position;
            direction = spawnPosition.GetDirection;
            newBullet.Init(direction, data.GetWeaponData.maxSpeed, data.GetBulletData);
            inCooldown = true;
        }
    }
}
