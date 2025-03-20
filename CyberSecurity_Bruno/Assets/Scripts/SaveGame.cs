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

    public void ToSaveGame()
    {
        string json = JsonUtility.ToJson(playerData, prettyPrint: true);
        File.WriteAllText(savePath, json);
        Debug.Log("Jogo salvo em: " + savePath);
    }
    public void ToLoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Jogo carregado");
            texto.text = playerData.ToString();
            return;
        }
        else
        {
            Debug.Log("Arquivo de save não encontrado.");
            return;
        }
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

    public override string ToString()
    {
        foreach (var item in inventario)
        {
            invTostring += item.ToString() + " ";
        }
        return $@" {this.nome} {this.level}
        {this.vida} 
        { this.invTostring}";
    }
}