using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FallingCooking
{
    public class GameManager : MonoBehaviour
    {
        //public enum gameStates { Playing, End };
        //public gameStates gameState = gameStates.Playing;

        public static GameManager instance = null;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}