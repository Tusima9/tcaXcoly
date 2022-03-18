using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerImage : MonoBehaviour
{
    public int selectedImage = 0;
    public GameObject[] Images;
    [SerializeField] private GameObject tutorial;


    public void NextImage()
    {
        Images[selectedImage].SetActive(false);
        selectedImage = (selectedImage + 1) % Images.Length;
        Images[selectedImage].SetActive(true);
      if(selectedImage == 5)
        {
            ClosePanel();
        } 
      
    }
    public void ClosePanel()
    {
        tutorial.SetActive(false);
    }
}
