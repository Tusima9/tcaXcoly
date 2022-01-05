using UnityEngine;
using System;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class SkillDialogueBox : MonoBehaviour
    {
        public event EventHandler ConfirmSkill;

        public static SkillDialogueBox instance;

        private GameObject core;

        private SwitchableImage description;

        // Start is called before the first frame update
        public void Start()
        {
            instance = this;
            core = transform.GetChild(0).gameObject;
            description = core.GetComponentInChildren<SwitchableImage>();
        }

        public void displaySkill(string uuid)
        {
            Coordinator.Coordinator.NotifyDialogActive();
            core.SetActive(true);
            description.SwitchImage("SkillDescription/" + uuid);
        }

        public void OnConfirm()
        {
            Script.Puzzle.Sound.SoundSystem.instance.PlayTapSFX();
            core.SetActive(false);
            OnConfirmSkill(EventArgs.Empty);
            ConfirmSkill = null;
            Coordinator.Coordinator.NotifyDialogDeactive();
        }

        public void OnCancel()
        {
            Script.Puzzle.Sound.SoundSystem.instance.PlayTapBackSFX();
            core.SetActive(false);
            ConfirmSkill = null;
            Coordinator.Coordinator.NotifyDialiogDeactive();
        }

        protected virtual void OnConfirmSkill(EventArgs e)
        {
            EventHandler handler = ConfirmSkill;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}