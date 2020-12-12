using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ViewSwitcher : MonoBehaviour
{
    public ViewType vistaObjetivo;

    UIManager _UIManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        _UIManager = UIManager.GetInstance();
    }

    void OnButtonClicked()
    {
        _UIManager.SwitchView(vistaObjetivo);
    }
}
