using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Data
{
public class DataInitialisation : MonoBehaviour
{

        private static bool initialized = false; // boolean stating wheter the data has already been initialized
   

    public void Start() // initalize data classes
    {
            if (initialized)
            {
                Games.LoadGame();
                Characters.LoadCharacters();
                initialized = true;
            }
    }

 
}

}
