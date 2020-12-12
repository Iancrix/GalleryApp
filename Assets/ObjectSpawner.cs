using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;

    GameObject objectSpawned;
    private int obraID = 0;

    public Camera ARCamera;

    public float verticalOffset = 1.500f;
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit, 500))
        {
            if(hit.transform.tag == "Obra")
            {
                GameObject animObra = hit.transform.GetChild(2).gameObject;
                //animObra.GetComponent<SpriteRenderer>().enabled = true;
                animObra.GetComponent<SpriteRenderer>().enabled = false;

                Animator animatorObra = animObra.GetComponent<Animator>();
                animatorObra.SetInteger("ObraID", obraID);
            }
            else
            {
                if (objectSpawned)
                {
                    GameObject animObra = objectSpawned.transform.GetChild(2).gameObject;
                    animObra.GetComponent<SpriteRenderer>().enabled = false;

                    Animator animatorObra = animObra.GetComponent<Animator>();
                    animatorObra.SetInteger("ObraID", obraID);
                }
            }
        }
        else
        {
            if (objectSpawned)
            {
                GameObject animObra = objectSpawned.transform.GetChild(2).gameObject;
                animObra.GetComponent<SpriteRenderer>().enabled = false;

                Animator animatorObra = animObra.GetComponent<Animator>();
                animatorObra.SetInteger("ObraID", obraID);
            }
        }
        /*
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position + new Vector3(0, 0.500f, 0), placementIndicator.transform.rotation);
        }
        */
    }

    /*
    public void ChangeTexture(Texture2D texture)
    {
        GameObject cuadro = objectToSpawn.transform.GetChild(0).gameObject;
        cuadro.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = texture;

        GameObject marco = objectToSpawn.transform.GetChild(1).gameObject;
        GameObject anim = objectToSpawn.transform.GetChild(2).gameObject;

        float scaleX = texture.width/10000f;
        float scaleY = texture.height/10000f;

        cuadro.transform.localScale = new Vector3(scaleX, 1f, scaleY);
        marco.transform.localScale = new Vector3(scaleX*10, 0.1f, scaleY*10);
        anim.transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }*/

    public void ChangeObra(Obra obra)
    {
        Sprite sprite = obra.getSprite();

        GameObject cuadro = objectToSpawn.transform.GetChild(0).gameObject;
        cuadro.GetComponent<SpriteRenderer>().sprite = sprite;

        GameObject marco = objectToSpawn.transform.GetChild(1).gameObject;
        GameObject anim = objectToSpawn.transform.GetChild(2).gameObject;

        float scaleX = (sprite.texture.width / 1000f);
        float scaleY = (sprite.texture.height / 1000f);

        cuadro.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        marco.transform.localScale = new Vector3(scaleX, 0.1f, scaleY);
        anim.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        BoxCollider colliderObra = objectToSpawn.GetComponent<BoxCollider>();
        colliderObra.size = new Vector3(scaleX, scaleY, 0.1f);

        colliderObra.center = marco.transform.position;

        obraID = obra.getId();
    }

    public void SpawnObject()
    {
        if(!objectSpawned && placementIndicator.isVisualShowing)
        {
            objectSpawned = Instantiate(objectToSpawn, placementIndicator.transform.position + new Vector3(0f, verticalOffset, 0f), placementIndicator.transform.rotation);
            placementIndicator.setEnableVisual(false);
        }
    }

    public void DestroyObject()
    {
        if (objectSpawned)
        {
            Destroy(objectSpawned);
            placementIndicator.setEnableVisual(true);
        }
    }
}
