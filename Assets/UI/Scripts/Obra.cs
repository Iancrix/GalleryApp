using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Obra
{
    public int id;
    public string name;
    public string artist;
    public Sprite sprite;

    public Obra()
    {

    }

    public Obra(int id, string name, string artist, Sprite sprite)
    {
        this.id = id;
        this.name = name;
        this.artist = artist;
        this.sprite = sprite;
    }
    
    public void setId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return this.id;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return this.name;
    }

    public void setArtist(string artist)
    {
        this.artist = artist;
    }

    public string getArtist()
    {
        return this.artist;
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return this.sprite;
    }

}
