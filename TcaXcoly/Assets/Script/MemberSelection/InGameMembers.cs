using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMembers : MonoBehaviour
{
    private MemberImgSwitcher switchImage;
    

    public void Start()
    {
        switchImage = transform.GetChild(0).GetChild(0).GetComponentInChildren<MemberImgSwitcher>();
        Coordinator.RegisterCharacter(this);
    }

    public void InitSprite(string uuid)
    {
        if (uuid != null)
        {
            switchImage.SwitchImage("Characters/" + uuid);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
