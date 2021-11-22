using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public BackgroundName Bg { get; private set; }
    public BackgroundPosition Position { get; private set; }
    public Backgrounds BackgroundImage { get; private set; }

    public bool isShowing { get; private set; }

    private BackgroundImageManager _BIM;
    private float _offScreenX;
    private float _onScreenX;
    [SerializeField]
    private readonly float _animationSpeed = -0.1f;

    public void Init(BackgroundName bg,Backgrounds backgroundimage,BackgroundPosition position, BackgroundImageManager bim)
    {
        Bg = bg;
        BackgroundImage = backgroundimage;
        Position = position;
        _BIM = bim;
        Show();
    }
    
    public void Show()
    {
        SetAnimationValues();
       // transform.position = new Vector3(_offScreenX, transform.position.y, transform.localPosition.z);
        UpdateSprite();
        isShowing = true;
        //LeanTween.moveX(gameObject, _onScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() =>
        //{
        //    isShowing = true;
        //});
    }
    public void Hide()
    {
        LeanTween.moveX(gameObject, _offScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
            isShowing = false;
        });
    }
    public void ChangeBackground(Backgrounds background)
    {
        BackgroundImage = background;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        var sprite = _BIM.GetBackgroundSprite(BackgroundImage);
        var image = GetComponent<Image>();
        image.sprite = sprite;
        image.preserveAspect = true;
    }
    private void SetAnimationValues()
    {
        switch (Position)
        {
            case BackgroundPosition.center:
                _onScreenX = Screen.width * 0.5f;
                _offScreenX = -Screen.width * 0.25f;
                break;
        }
    }
}
