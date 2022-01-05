using UnityEngine;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class ClearDialogueBox : MonoBehaviour
    {
        public static ClearDialogueBox instance;

        private GameObject core;

        private SwitchableImage description;

        public void start()
        {
            instance = this;
            core = transform.GetChild(0).gameObject;
            description = core.GetComponentInChildren<SwitchableImage>();
        }

        public void EndGame(string gameUUID)
        {
            description.SwitchImage("Tips/" + gameUUID);
            core.SetActive(true);
            Coordinator.Coordinator.NotifyDialoActive();
        }

        public void OnConfirmEndGame()
        {
            Coordinator.Coordinator.NotifyEndGame();
        }
    }
}