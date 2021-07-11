using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledBulletShooter : MonoBehaviour
{
    [SerializeField]
    private BulletManager bulletManager;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        if (bulletManager == null)
        {
            bulletManager = FindObjectOfType<BulletManager>();
        }
    }



    private void FixedUpdate()
    {
        if (InputManager.shouldFire)
        {
            bulletManager.FireBullet(true, null);
        }
    }
}
