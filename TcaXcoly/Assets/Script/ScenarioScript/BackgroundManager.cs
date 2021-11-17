using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Assets.Scripts;


public class BackgroundManager : MonoBehaviour
{
    private List<Background> _backgrounds;
    [SerializeField]
    private GameObject _BackgroundPrefab;
    [SerializeField]
    private BackgroundImageManager _Bg;

    private void Start()
    {
        _backgrounds = new List<Background>();
    }

    public void ShowBackground(string name,string sprite,string position)
    {
        if(!Enum.TryParse(name,out BackgroundName name1))
        {
            Debug.LogWarning($"failed to parse background name to enum:{name}");
            return;
        }
        if (!Enum.TryParse(sprite, out Backgrounds backgrounds))
        {
            Debug.LogWarning($"failed to parse background sprite to enum:{sprite}");    
            return;
        }
        if (!Enum.TryParse(position, out BackgroundPosition positionEnum))
        {
            Debug.LogWarning($"Failed to parse background position to enum: {position}");
            return;
        }
        ShowBackground(name1, backgrounds,positionEnum);

    }
    public void ShowBackground(BackgroundName name,Backgrounds backgrounds,BackgroundPosition position)
    {
        var backg = _backgrounds.FirstOrDefault(x => x.Bg == name);
        if (backg == null)
        {
            var backgroundObject = Instantiate(_BackgroundPrefab, gameObject.transform, false);
            backg = backgroundObject.GetComponent<Background>();

            _backgrounds.Add(backg);

        }
        else if (backg.isShowing)
        {
            Debug.LogWarning($"Failed to show background {name}. background already showing");
            return;
        }
        backg.Init(name, backgrounds,position, GetBackgroundSprite(name));
    }
    public void HideBackground(string name)
    {
        if (!Enum.TryParse(name, out BackgroundName name1))
        {
            Debug.LogWarning($"failed to parse background name to enum:{name}");
            return;
        }
        HideBackground(name1);
    }

    public void HideBackground(BackgroundName name)
    {
        var backg = _backgrounds.FirstOrDefault(x => x.Bg == name);
        if (backg?.isShowing != true)
        {
            Debug.LogWarning($"Background {name} is not currently shown. Can't change the background.");
            return;

        }
        else
        {
            backg.Hide();
        }
    }
    public void ChangeBackground(string name, string sprite)
    {
        if (!Enum.TryParse(name, out BackgroundName name1))
        {
            Debug.LogWarning($"failed to parse background name to enum:{name}");
            return;
        }
        if (!Enum.TryParse(sprite, out Backgrounds backgrounds))
        {
            Debug.LogWarning($"failed to parse background sprite to enum:{sprite}");
            return;
        }
        ChangeBackground(name1, backgrounds);
    }
    public void ChangeBackground(BackgroundName name, Backgrounds sprite)
    {
        var backg = _backgrounds.FirstOrDefault(x => x.Bg == name);
        if(backg?.isShowing != true)
        {
            Debug.LogWarning($"Background {name} is not currently shown. Can't change the background.");
            return;
        }
        else
        {
            backg.ChangeBackground(sprite);
        }
    }

    private BackgroundImageManager GetBackgroundSprite(BackgroundName name)
    {
        switch (name)
        {
            case BackgroundName.Bg:
                return _Bg;
            default:
                Debug.LogError($"Could not find backgroundSprite for {name}");
                return null;
        }
    }
}
