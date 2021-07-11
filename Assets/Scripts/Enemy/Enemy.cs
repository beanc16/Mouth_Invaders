using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BulletManager bulletManager;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }



    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void FireBullet()
    {
        bulletManager.FireBullet(false, this);
    }
}
