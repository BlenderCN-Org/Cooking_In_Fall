using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceipeTemplate : MonoBehaviour {
    public Receipe[] availableRecipes;
}

[System.Serializable]
public struct Receipe
{
    public string recipeName;
    public Ingredients[] ingredientsArray;

}
