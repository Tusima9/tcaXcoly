using Assets.Scripts;
using UnityEngine;

public class BackgroundImageManager : MonoBehaviour
{
    public BackgroundName Bg;

    public Sprite House;
    public Sprite Bedroom;
    public Sprite Bedroom2;
    public Sprite Workingroom;
    public Sprite Livingroom;

    public Sprite GetBackgroundSprite(Backgrounds BackgroundM)
    {
        switch (BackgroundM)
        {
            case Backgrounds.House:
                return House;
            case Backgrounds.Bedroom:
                return Bedroom ?? House;
            case Backgrounds.Bedroom2:
                return Bedroom2 ?? House;
            case Backgrounds.Livingroom:
                return Livingroom ?? House;
            case Backgrounds.Workingroom:
                return Workingroom ?? House;
            default:
                Debug.Log($"Didn't find Sprite for backgroundname: {Bg},backgroundSprite{BackgroundM}");
                return House;
        }
    }

}
