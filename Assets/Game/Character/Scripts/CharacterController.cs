using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Camera characterCamera;
    [SerializeField] private SpawnPosition spawnPosition;

    private void Start() {
        weaponController.Init(this);
    }
}
