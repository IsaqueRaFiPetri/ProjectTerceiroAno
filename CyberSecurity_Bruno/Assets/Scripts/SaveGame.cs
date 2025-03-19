using UnityEngine;
using TMPro;
using System.IO;

public class SaveGame : MonoBehaviour
{
    [SerializeField]
    TMP_Text texto;
    private string savePath;
    [SerializeField]
    private PlayerData playerData;

    void Start()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
    }
}

[System.Serializable]
public class PlayerData
{
    public string nome;
    public int level;
    public float vida;
    public string[] inventario;
    string invTostring;

    /*public override string ToString()
    {
        foreach (var item in inventario)
        {
            invTostring += item.ToString() + " ";
        }
        return $@ {this.nome} {this.level}
        {this.vida} 
        { this.invTostring};
    }*/
}