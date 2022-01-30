using Assets.Scripts;
using UnityEngine;

public class BackgroundImageManager : MonoBehaviour
{
    public BackgroundName Bg;

    public Sprite Front;
    public Sprite School;
    public Sprite Classroom;
    public Sprite Combatroom;
    public Sprite Dungeon;

    public Sprite GetBackgroundSprite(Backgrounds BackgroundM)
    {
        switch (BackgroundM)
        {
            case Backgrounds.Front:
                return Front;

            case Backgrounds.School:
                return School ?? Front;

            case Backgrounds.Classroom:
                return Classroom ?? Front;

            default:
                Debug.Log($"Didn't find Sprite for backgroundname: {Bg},backgroundSprite{BackgroundM}");
                return Front;
        }
    }
}