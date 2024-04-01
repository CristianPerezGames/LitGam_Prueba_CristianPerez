using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rgbody;

    private void OnValidate() {
        if(rgbody == null) rgbody = GetComponent<Rigidbody>();
    }

    public void PushObject(Vector3 _velocity){
        rgbody.AddForce(_velocity, ForceMode.Force);
    }

    public void Explosion(Vector3 _velocity){
        rgbody.velocity = _velocity;
    }
}
