using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Assets.Scripts.MemberSelection
{
public class Members
{
        private static Dictionary<string, string> characterSkillDict = new Dictionary<string, string>(); // array for skill

        private static readonly string characterDataJson = "member"; // file path to the data file

        public static void LoadCharacters() // load all game data in character.json
        {
            TextAsset jsonAsset = Resources.Load("Data/" + characterDataJson) as TextAsset;
            string json = jsonAsset.ToString();
            MemberJson loadedData = JsonUtility.FromJson<MemberJson>(json);
            //store skill reference
            foreach(Member chara in loadedData.members)
            {
                characterSkillDict.Add(chara.uuid, chara.skillUUID);
            }

        }

        public static string GetSkill(string charaUUID) // get skill uuid of a team member
        {
            return characterSkillDict[charaUUID];
        }

        [Serializable]
        public struct MemberJson
        {
            public Member[] members;// array of possible team member
        }

        [Serializable]
        public struct Member
        {
            public string uuid; // ID whoo identify this member

            public string skillUUID;
        }

}

}
