using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class LostDialogueBox : MonoBehaviour
    {
        public static LostDialogueBox instance;

        private GameObject core;

        
        
        
        // Start is called before the first frame update
       public void Start()
        {
            instance = this;

            core = transform.GetChild(0).gameObject;
        }

        public void EndGame()
        {
            core.SetActive(true);
            Coordinator.Coordinator.NotifyDialogActive();
        }

        public void OnConfirmEndGame()
        {
            Coordinator.Coordinator.NotifyEndGame();
        }

      
    }

}


