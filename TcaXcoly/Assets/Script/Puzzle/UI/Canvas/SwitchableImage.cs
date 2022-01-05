using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class SwitchableImage : MonoBehaviour
    {
        private Image image;

        // Start is called before the first frame update
        private void Start()
        {
            image = GetComponent<Image>();
        }

        public void SwitchImage(string spritePath)
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
            Sprite loadedSprite = Resources.Load<Sprite>(spritePath);
            if (loadedSprite != null)
            {
                image.sprite = loadedSprite;
            }
            else
            {
                image.sprite = Resources.Load<Sprite>("MISSING_SPRITE");
            }
        }
    }
}