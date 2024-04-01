using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody rgBody;

    protected BulletData bulletData;

    private float currentLifeTime;

    public virtual void Init(Vector3 _direction, float _speed , BulletData _bulletData){
        bulletData = _bulletData;
        rgBody.velocity = _direction * _speed;

        currentLifeTime = 0;

        gameObject.SetActive(true);
    }

    public virtual void Finish(){
        rgBody.velocity = Vector3.zero;
        rgBody.Sleep();
        gameObject.SetActive(false);
    }

    protected virtual void Update() {
        currentLifeTime += Time.deltaTime;
        if(currentLifeTime >= bulletData.lifeTime){
            Finish();
        }
    }
}
