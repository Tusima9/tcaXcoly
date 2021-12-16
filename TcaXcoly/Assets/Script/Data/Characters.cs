using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Assets.Scripts.Data
{
public class Characters : MonoBehaviour
{
        private static Dictionary<string, string> characterSkillDict = new Dictionary<string, string>(); // array for skill

        private static readonly string characterDataJson = "character"; // file path to the data file

        public static void LoadCharacters() // load all game data in character.json
        {
            TextAsset jsonAsset = Resources.Load("data/" + characterDataJson) as TextAsset;
            string json = jsonAsset.ToString();
            CharacterJson loadedData = JsonUtility.FromJson<CharacterJson>(json);
            //store skill reference
            foreach(Character chara in loadedData.characters)
            {
                characterSkillDict.Add(chara.uuid, chara.skillUUID);
            }

        }

        public static string GetSkill(string charaUUID) // get skill uuid of a team member
        {
            return characterSkillDict[charaUUID];
        }

        [Serializable]
        public struct CharacterJson
        {
            public Character[] characters;// array of possible team member
        }

        [Serializable]
        public struct Character
        {
            public string uuid; // ID whoo identify this member

            public string skillUUID;
        }

}

}
