using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Boundary : MonoBehaviour
{
    public static float Left_Side = -3.5f;
    public static float Right_Side = 3.5f;
    public float Internal_Left;
    public float Internal_Right;

    void Update()
    {
        Internal_Left = Left_Side;
        Internal_Right = Right_Side;
    }
}
