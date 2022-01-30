using Assets.Script.Coordinator;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<InGameMembers> characters = Coordinator.GetCharacters();
        characters.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x)); // Sort object from left to right
        List<string> selectedCharacter = TeamManager.GetMembers();
        for (int i = 0; i < characters.Count; i++)
        {
            if (i < selectedCharacter.Count)
            {
                characters[i].InitSprite(selectedCharacter[i]); // Init team member sprite
            }
            else
            {
                characters[i].InitSprite(null); // Disable unused character
            }
        }
    }

   
}
