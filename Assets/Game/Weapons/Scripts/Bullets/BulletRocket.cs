using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRocket : BulletBase {

    [SerializeField] private LayerMask layerMask;

    public override void Init(Vector3 _direction, float _speed, BulletData _bulletData) {
        base.Init(_direction, _speed, _bulletData);
    }

    private void OnCollisionEnter(Collision other) {
        Explode();
        Finish();
    }

    private void FixedUpdate() {
        transform.forward = rgBody.velocity;
    }

    private void Explode() {
        var overlap = Physics.OverlapSphere(transform.position, bulletData.radius, layerMask);
        if(overlap.Length > 0){
            for (int i = 0; i < overlap.Length; i++) {
                DynamicObject obj = overlap[i].GetComponent<DynamicObject>();
                if(obj){
                    Vector3 direction = obj.transform.position - transform.position;
                    direction.y = Random.Range(0.4f, 1f);
                    direction = direction.normalized;
                    obj.Explosion(direction * bulletData.forceAttraction);
                }
            }
        }

        
    }
}
