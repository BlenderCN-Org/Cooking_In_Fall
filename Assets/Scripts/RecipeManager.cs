using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

    public static RecipeManager recipeManagerInstance;

    [SerializeField]
    public List<Ingredients[]> recipes;

    //SINGLETON
    private void Awake()
    {
        if (recipeManagerInstance == null)
        {
            // recipes = new Recipe[5];
            recipeManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(recipeManagerInstance); // We keep one instance for music that should never be destroyed
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
