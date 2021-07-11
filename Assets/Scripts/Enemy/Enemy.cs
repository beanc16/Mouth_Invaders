using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
