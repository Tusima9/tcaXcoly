using UnityEngine;
using UnityEngine.UI;

public class MemberImgSwitcher : MonoBehaviour
{
    private Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// Load sprite in resources folder and change the sprite to the loaded img
    /// </summary>
    /// <param name="spritePath"> file path to the desired sprite</param>
    public void SwitchImage(string spritePath)
    {
        if (image==null)
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
            image.sprite = Resources.Load<Sprite>("question");
        }
    }
}
