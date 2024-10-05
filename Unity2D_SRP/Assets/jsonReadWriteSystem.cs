using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class jsonReadWriteSystem : MonoBehaviour
{
    public InputField IDinputField;
    public InputField NameinputField;
    public InputField InforinputField;

    public void SaveButton() { 
    
        LoginJson data = new LoginJson();

        // nhập dữ liệu người chơi 
        data.ID = IDinputField.text;
        data.NAME = NameinputField.text;
        data.INFOMATION = InforinputField.text;

        // tạo 1 file mới lưu dữ liệu người chơi
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/FormLogin.json", json);
    }

    // đọc dữ liệu từ json form đã tạo
    public void LoadButton() {

        string json = File.ReadAllText(Application.dataPath + "/FormLogin.json");

        LoginJson data = JsonUtility.FromJson<LoginJson>(json);
        IDinputField.text = data.ID;
        NameinputField.text = data.NAME;
        InforinputField .text = data.INFOMATION;
    }
}
