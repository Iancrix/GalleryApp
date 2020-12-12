using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public enum ViewType
{
    Principal,
    Catalogo,
    Artistas,
    Exposiciones,
    CameraUI
}

public class UIManager : Singleton<UIManager>
{
    List<UIController> UIControllerList;
    UIController lastActiveView;

    [SerializeField]
    GameObject MovePhoneGO;

    ARPlaneManager _ARPlaneManager = null;
    List<ARPlane> planes = new List<ARPlane>();

    protected override void Awake()
    {
        _ARPlaneManager = FindObjectOfType<ARPlaneManager>();
        if(_ARPlaneManager != null)
        {
            Debug.Log("No es null");
        }
        else
        {
            Debug.Log("es null");
        }

        HideMovePhoneAnim();

        UIControllerList = GetComponentsInChildren<UIController>().ToList();
        UIControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchView(ViewType.Principal);
    }

    public void SwitchView(ViewType _viewType)
    {
        if(lastActiveView != null)
        {
            lastActiveView.gameObject.SetActive(false);
        }

        UIController vistaObjetivo = UIControllerList.Find(x => x.viewType == _viewType);

        if (vistaObjetivo != null)
        {
            vistaObjetivo.gameObject.SetActive(true);
            lastActiveView = vistaObjetivo;
        }
        else
        {
            Debug.LogWarning("La vista objetivo no  se encontro en el canvas");
        }
    }

    public bool showMovePhone = false;

    void Update()
    {
        if (PlanesFoundAndTracking())
        {
            if (showMovePhone)
            {
                HideMovePhoneAnim();
            }
        }
        else
        {
            
        }
    }

    bool PlanesFoundAndTracking()
    {
        return _ARPlaneManager.trackables.count > 0;
    }

    public void ShowMovePhoneAnim()
    {
        MovePhoneGO.SetActive(true);
        showMovePhone = true;

        
    }

    public void HideMovePhoneAnim()
    {
        MovePhoneGO.SetActive(false);
        showMovePhone = false;

        Debug.Log("Desaparece");
    }


}
