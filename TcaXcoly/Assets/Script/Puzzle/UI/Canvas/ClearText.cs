using UnityEngine;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class ClearText : MonoBehaviour
    {
        public static ClearText instance;

        private GameObject core;

        // Start is called before the first frame update
        public void Start()
        {
            instance = this;
            core = transform.GetChild(0).gameObject;
        }

        public void DisplayClearText()
        {
            core.SetActive(true);
        }
    }
}