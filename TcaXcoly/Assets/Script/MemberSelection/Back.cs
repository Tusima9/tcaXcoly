using System.Collections;
using UnityEngine;

namespace Assets.Script.MemberSelection
{
    /// <summary>
    /// class for controlling the Back button for the member selection
    /// </summary>
    public class Back : MonoBehaviour
    {
        //GameObject for selecting the level
        public GameObject levelSelect;

        //GameObject for selecting member
        public GameObject memberSelect;

        public void onClick()
        {
            memberSelect.SetActive(false);
            levelSelect.SetActive(true);
        }
    }
}