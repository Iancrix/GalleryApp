using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ObraSwitcher : MonoBehaviour
{
    ObraManager _ObraManager;
    Button obraButton;

    Obra obraData;

    // Start is called before the first frame update
    void Start()
    {
        obraButton = GetComponent<Button>();
        obraButton.onClick.AddListener(OnButtonClicked);
        _ObraManager = ObraManager.GetInstance();
    }

    void OnButtonClicked()
    {
        Debug.Log("Fue clickeada la obra " + obraData.name);
        _ObraManager.SwitchObra(obraData);
    }

    public void setObraData(Obra obraData)
    {
        this.obraData = obraData;
    }

    public Obra getObraData()
    {
        return this.obraData;
    }
}
