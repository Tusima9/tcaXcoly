using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonScript1 : MonoBehaviour
{
    private InkManager1 _inkManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _inkManager = FindObjectOfType<InkManager1>();
        if(_inkManager == null)
        {
            Debug.LogError("ink manager was not found!");
        }
        
    }

    public void OnClick()
    {
        _inkManager?.DisplayNextLine(); 
    }
    
}
