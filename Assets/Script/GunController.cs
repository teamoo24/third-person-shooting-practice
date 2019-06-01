using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Transform WeaponHold;
    public Gun stratingGun;
    Gun equippedGun;

    void Start()
    {
        if (stratingGun != null)
        {
            EquipGun(stratingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, WeaponHold.position, WeaponHold.rotation) as Gun;
        equippedGun.transform.parent = WeaponHold;
    }

    public void OnTriggerHold() {
        if (equippedGun != null) {
            equippedGun.OnTriggerHold();
        }
    }
    public void OnTriggerRelease() {
        if (equippedGun != null) {
            equippedGun.OnTriggerRelease();
        }
    }

    public float GunHeight{
        get {
            return WeaponHold.position.y;
        }
    }

    public void Aim(Vector3 aimPoint) {
        if (equippedGun != null)
        {
            equippedGun.Aim(aimPoint);
        }
    }

    public void Reload() {
        if (equippedGun != null)
        {
            equippedGun.Reload();
        }
    }
}