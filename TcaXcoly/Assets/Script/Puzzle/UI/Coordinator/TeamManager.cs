using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Puzzle.Coordinator { 

    public class TeamManager 
    {
        public static List<string> members = new List<string>();

        public static bool AddMember(string member)
        {
            if (members.Count >=6)
            {
                return false;
            }
            else
            {
                members.Add(member);
                return true;
            }
        }

        public static void RemoveMember(string member)
        {
            members.Remove(member);
        }

        public static List<string> GetMembers()
        {
            return members;
        }

        public static void Reset()
        {
            members.Clear();
        }
    }
}
