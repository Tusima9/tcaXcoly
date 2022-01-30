using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private static List<InGameMembers> characters = new List<InGameMembers>();

    public static void RegisterCharacter(InGameMembers member)
    {
        characters.Add(member);
    }

    public static List<InGameMembers> GetCharacters()
    {
        return characters;
    }

    public void Reset()
    {
        characters.Clear();
    }
}
