using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    public WallSide wallSide = WallSide.Right;
}



public enum WallSide
{
    Left,
    Right
}