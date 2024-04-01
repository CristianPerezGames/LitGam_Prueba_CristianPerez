using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    
    private void OnTriggerEnter(Collider other) {
        Trigger trigger = other.GetComponent<Trigger>();
        if(trigger){
            weaponController.SetWeapon(trigger.GetWeapon);
        }
    }
}
