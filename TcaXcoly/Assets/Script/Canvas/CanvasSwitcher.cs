using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using System;

[RequireComponent(typeof(Button))]

public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(onButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    public void onButtonClicked()
    {
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
