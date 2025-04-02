using System.Security.Cryptography;
using UnityEngine;
using System.Text;
using System.IO;
using TMPro;
using System;

public class SaveGame : MonoBehaviour
{
    [SerializeField]
    TMP_Text texto;
    private string savePath;
    [SerializeField]
    private PlayerData playerData;

    private static readonly string key = "123456789123456"; //chave de 16 bytes (16 dígitos).
    private static readonly string iv = "abcdefghijklmnop"; //IV de 16 bytes (16 dígitos).

    void Start()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
    }

    public void ToSaveGame()
    {
        string json = JsonUtility.ToJson(playerData, prettyPrint: true);
        string encryptedJson = Encrypted(json);
        File.WriteAllText(savePath, encryptedJson);
        Debug.Log("Jogo salvo em: " + savePath);
    }

    private string Encrypted(string plainText)

    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return System.Convert.ToBase64String(ms.ToArray());
            }
        }
    }


    public void ToLoadGame()
    {
        if (File.Exists(savePath))
        {
            string encryptedJson = File.ReadAllText(savePath);
            string json = Decrypt(encryptedJson);
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

    private string Decrypt(string chipertext)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(chipertext)))
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                return sr.ReadToEnd();
                }
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