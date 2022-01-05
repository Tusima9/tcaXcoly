using UnityEngine;

public class PanelControl : MonoBehaviour
{
    //パネルをゲットする
    [SerializeField] private GameObject PanelUI;


    //パネルを開閉する
    public void OpenPanel( )
    {
        if (PanelUI != null)
        {
            bool isActive = PanelUI.activeSelf;
            PanelUI.SetActive(!isActive);
        }
    
    }

}
