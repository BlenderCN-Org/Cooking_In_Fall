using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe")]
public class RecipeTemplate : ScriptableObject {
    public Ingredient[] listIngredients;
}
