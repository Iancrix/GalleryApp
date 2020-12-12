using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObraManager : Singleton<ObraManager>
{
    public List<Obra> obras;
    public GameObject ObraPanel;
    public Transform panel;

    ObjectSpawner objectSpawner;
    UIManager _UIManager;

    public ViewType targetView;
    public ViewType exitView;

    protected override void Awake()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = UIManager.GetInstance();

        foreach(Obra o in obras)
        {
            GameObject obra = Instantiate(ObraPanel);
            GameObject imagePanel = obra.transform.GetChild(0).GetChild(0).gameObject;

            /*
            Texture2D texture = o.getImage();
            Rect rect = new Rect(0, 0, texture.width, texture.height);*/
            imagePanel.GetComponent<Image>().sprite = o.getSprite();//Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100);

            GameObject obraName = obra.transform.GetChild(1).gameObject;
            GameObject artistName = obra.transform.GetChild(2).gameObject;

            obraName.GetComponent<Text>().text = o.getName();
            artistName.GetComponent<Text>().text = o.getArtist();

            ObraSwitcher os = obra.AddComponent<ObraSwitcher>() as ObraSwitcher;
            os.setObraData(o);

            obra.transform.SetParent(panel.transform, false);
        }

    }

    public void SwitchObra(Obra obra)
    {
        Sprite obraSprite = obra.getSprite();

        objectSpawner.ChangeObra(obra);

        _UIManager.ShowMovePhoneAnim();
        _UIManager.SwitchView(targetView);
    }

    public void SpawnObra()
    {
        objectSpawner.SpawnObject();
    }

    public void DestroyObra()
    {
        objectSpawner.DestroyObject();
    }

    public void onExitObra()
    {
        objectSpawner.DestroyObject();
        _UIManager.SwitchView(exitView);
        _UIManager.HideMovePhoneAnim();
    }

}


