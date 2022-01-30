using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(AudioSource))]
public class PieceDestructionSFX : MonoBehaviour
{
        private float selfDestruct = 0; // self destruction timer

        private float selfDestructLimit = 1; // self destruction lifespan 

        public void SetEternal() // instance for not self destruction
        {
            selfDestructLimit = float.MaxValue;
        }

        public void Update() // check for self destruction per frame till destroyed
        {
            if(selfDestruct < selfDestructLimit)
            {
                selfDestruct += Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        //play match sound
        public void PlaySound(float pitch, float delay) 
        {
            GetComponent<AudioSource>().pitch = pitch;
            GetComponent<AudioSource>().PlayDelayed(delay);
            selfDestructLimit += delay; // prolong this instance for delay seconds
        
        }

    }


