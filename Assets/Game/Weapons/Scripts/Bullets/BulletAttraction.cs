using System.Collections;
using UnityEngine;

public class BulletAttraction : BulletBase {

    [SerializeField] private LayerMask layerMask;

    public override void Init(Vector3 _direction, float _speed, BulletData _bulletData) {
        base.Init(_direction, _speed, _bulletData);
    }

    private void FixedUpdate() {
        var overlap = Physics.OverlapSphere(transform.position, bulletData.radius, layerMask);
        if(overlap.Length > 0){
            for (int i = 0; i < overlap.Length; i++) {
                DynamicObject obj = overlap[i].GetComponent<DynamicObject>();
                if(obj){
                    Vector3 direction = transform.position - obj.transform.position;
                    direction = direction.normalized;
                    obj.PushObject(direction * bulletData.forceAttraction);
                }
            }
        }
    }
}
