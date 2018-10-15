using UnityEngine;
using System.IO;


public class Ejemplojson : MonoBehaviour {

    // Use this for initialization
    string filePath;
    string jsonString;

    private void Awake()
    {
        filePath = Application.dataPath + "/Personaje.json";
        jsonString = File.ReadAllText(filePath);
        Personaje personaje = JsonUtility.FromJson<Personaje>(jsonString);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public class Personaje {
    public string nombre;
    public string profecion;
    public int nivel; 

}

