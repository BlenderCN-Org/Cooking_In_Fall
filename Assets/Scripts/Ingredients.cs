using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredients {
    
    public int number;
    public enum Ingredient { Tomato, Herb, Banana, Apple, Cherry };

    public Ingredient type;

}
