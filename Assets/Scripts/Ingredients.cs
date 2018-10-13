using FallingCooking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constitute one or several ingredients of a recipe (ex : Tomato soup = 3 tomatoes)
/// </summary>
[System.Serializable]
public struct Ingredients {

    public int number;
    public GameManager.Type type;

}
