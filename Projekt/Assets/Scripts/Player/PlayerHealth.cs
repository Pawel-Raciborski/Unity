using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;

    public static void Damage(float damage)
    {
        health -= damage;
    }

    public static float GetInterpolatedHealth()
    {
        return health / 100f;
    }
}
