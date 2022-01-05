using System;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class GenericAnimationCallBack
    {
        private bool clearOnRaise;

        public GenericAnimationCallBack(bool clearListener) // if listener is true = all listerner reset every time the event is raised
        {
            clearOnRaise = clearListener;
        }

        public event EventHandler AnimationCompleted;

        public virtual void OnAnimationCompleted(EventArgs e)
        {
            EventHandler handler = AnimationCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
            if (clearOnRaise)
            {
                AnimationCompleted = null; // clear listener
            }
        }
    }
}