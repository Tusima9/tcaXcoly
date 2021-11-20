using UnityEngine;

public class PanelControl : MonoBehaviour
{
    //パネルをゲットする
    [SerializeField] private GameObject PanelUI;

    void Start()
    {
        ClosePanel( );
    }

    //パネルを開く
    public void OpenPanel( )
    {
        PanelUI.SetActive( true );
    }

    //パネルを閉じる
    public void ClosePanel()
    {
        PanelUI.SetActive( false );
    }

}
