using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour {
    public static float initialFuel = 2000.0f;
    public static float fuel = initialFuel; // liters
    public static float fuelConsumption = 0.4f; // liters/second


    public static bool HasEmptyFuel()
    {
        return fuel <= 0;
    }
}