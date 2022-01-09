using System.Collections;
using System.Collections.Generic;
using Assets.Script.Puzzle.Coordinator;
using Assets.Script.Puzzle.Sound;
using UnityEngine;

public class Member : MonoBehaviour
{
    public string memberUID;

    public GameObject selectedMask;

    private float mouseDownTime = -1;

    /*private void Update()
    {
        
    }*/

    public void OnMouseDown()
    {
        mouseDownTime = Time.time;
    }

    public void OnMouseUp()
    {
        if (mouseDownTime!= -1)
        {
            if (selectedMask.activeSelf)
            {
                // Play SFX
                SoundSystem.instance.PlayTapSFX();
                // Disable selection
                TeamManager.RemoveMember(memberUID);
                // Disable selected mask if chosen
                selectedMask.SetActive(false);
            }
            else
            {
                // Try to add the member to team member selection
                if (TeamManager.AddMember(memberUID))
                {
                    // Play SFX
                    SoundSystem.instance.PlayTapSFX();
                    // Enable selected mask if successful
                    selectedMask.SetActive(true);
                }
                else
                {
                    // Play SFX
                    SoundSystem.instance.PlayTapErrorSFX();
                }
            }
            // Reset mouseDownTime
            mouseDownTime = -1;
        }
    }
}
