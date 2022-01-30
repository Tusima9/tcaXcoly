using UnityEngine;
using UnityEngine.EventSystems;

namespace Asset.Script.MemberSelection
{
    public class Member : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        //UUId that represent this instance
        public string memberUUID;
    
        //Mask that will be displayed id character selected
        public GameObject selectMask;

        //float that will keep track player's click
        //private float mouseDownTime = -1;
    
        /// <summary>
        /// called every frame to detect long-press
        /// </summary>
        /*public void Update()
        {

            if (mouseDownTime != -1 && Time.time - mouseDownTime >= 1)
            {
                //MemberDescription.instance.ShowDescription(memberUUID);
                Debug.Log("Show Description");
                mouseDownTime = -1;
            }


        }*/

        /*public void OnMouseDown()
        {
            mouseDownTime = Time.time;
        }

        public void OnMouseUp()
        {
            if (mouseDownTime != -1)
            {
                Debug.Log("error");
                if (selectMask.activeSelf)
                {
                    Assets.Script.Coordinator.TeamManager.RemoveMember(memberUUID);
                    selectMask.SetActive(false);
                }
                else
                {
                    if (Assets.Script.Coordinator.TeamManager.AddMember(memberUUID))
                    {
                        selectMask.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("error");
                    }
                }
                mouseDownTime = -1;
            }
            Debug.Log("pressed");
        }

        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0)){
                //displayRotation.isRotating = false;
                Debug.Log("Mouse is down");
            }

        }*/

       

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("The cursor entered the selectable UI element.");
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Use this to tell when the user right-clicks on the Button
            if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
                //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
                Debug.Log("Show Description");
            }

            //Use this to tell when the user left-clicks on the Button
            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log(name + " Game Object Left Clicked!");
                if (selectMask.activeSelf)
                {
                    Assets.Script.Coordinator.TeamManager.RemoveMember(memberUUID);
                    selectMask.SetActive(false);
                }
                else
                {
                    if (Assets.Script.Coordinator.TeamManager.AddMember(memberUUID))
                    {
                        selectMask.SetActive(true);
                    }
                }
            }
        }
    }

}
