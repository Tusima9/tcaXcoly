using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Coordinator
{
    public static class TeamManager 
    {
        private static List<string> members = new List<string>();

        // Add member to the selection

        ///<param name="member"> UUID of the new team member</param>
        ///<returns>Boolea string wheter the addition is succesful or not</returns>
        public static bool AddMember(string member)
        {
            if (members.Count >= 6)
            {
                //reject id the team has 6 members already
                return false;
            }
            else
            {
                //add member
                members.Add(member);
                return true;
            }
        }

        //Remove member from the party
        ///<param name="member"> Member that will be remove</param>
        public static void RemoveMember(string member)
        {
            members.Remove(member);
        }

        //Return the list of the selected members
        public static List<string> GetMembers()
        {
            return members;
        }

        // Reset all static variable in this classs
        public static void Reset()
        {
            members.Clear();
        }
    }
}