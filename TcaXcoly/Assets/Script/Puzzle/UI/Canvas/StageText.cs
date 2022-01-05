using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Puzzle.UI.Canvas
{
    // ui responsible for displaying the stage transition text
    public class StageText : MonoBehaviour
    {
        public static StageText instance;

        public GenericAnimationCallBack animationEvent = new GenericAnimationCallBack(true);

        private Text text;

        private Animator textAnimator;

        // Start is called before the first frame update
        public void Start()
        {
            instance = this;
            text = GetComponent<Text>();
            textAnimator = GetComponent<Animator>();
        }

        // play transition event (current stage / maximum number of stage)
        public void Transition(int currentStage, int maxStage)
        {
            text.text = "Stage" + (currentStage + 1).ToString() + "/" + maxStage.ToString();
            textAnimator.SetBool("active", true);
        }

        public void OnAnimationDone()
        {
            textAnimator.SetBool("active", false);
            animationEvent.OnAnimationCompleted(EventArgs.Empty);
        }
    }
}