using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ApiCalls : MonoBehaviour {

    private JuegosGet juegoGet;
    private JuegosPost juegoPost;
    // Use this for initialization
    
    public void BasicLookup()
    {
        //StartCoroutine(PerformLookup());
        Post();
        //ConForm();
    }

    public void Post() {

        //Post

        juegoPost = new JuegosPost();
        juegoPost.Nombre = "aaaa";
        juegoPost.Categoria = "jjjjj";
        juegoPost.Estado = true;
        juegoPost.Descripcion = "fff";
        juegoPost.Multijugador = true;
        //string jsJuegos = juegoPost.getJson("Cacha", "Educativo", "algo", true, true);

        string jsJuegos = JsonUtility.ToJson(juegoPost);
        UnityWebRequest wr_Post = UnityWebRequest.Post("http://localhost:8085/api/Labic", jsJuegos);
        wr_Post.chunkedTransfer = false;
        wr_Post.SendWebRequest();

        Debug.Log(wr_Post.downloadHandler.text);
    }


    public void ConForm() {

        string uri = "http://localhost:8085/api/Labic";
        WWWForm form = new WWWForm();
        form.AddField("Nombre", "Con formulario---");
        form.AddField("Categoria", "algo");
        form.AddField("Descripcion", "si");
        form.AddField("Estado", "0");
        form.AddField("Multijugador", "0");

        WWW www = new WWW(uri,form);

        StartCoroutine(requerimiento(www));


    }
    IEnumerator requerimiento(WWW www)
    {
        yield return www;
        Debug.Log(www.text);
    }
    IEnumerator PerformLookup() {


        //desde archivo


        var filePath = Application.dataPath + "/JuegoArchivo.json";
        var jsonString = File.ReadAllText(filePath);
        JuegosGet juegoArchivo = JsonUtility.FromJson<JuegosGet>(jsonString);



        ////get 
        //UnityWebRequest wr_get = UnityWebRequest.Get("http://localhost:8085/api/Labic"+"/1");
        // wr_get.SendWebRequest();
        //var JuegoGet = JsonUtility.FromJson<JuegosGet>(wr_get.downloadHandler.text);







        //Post

        juegoPost = new JuegosPost();
        juegoPost.Nombre = "aaaa";
        juegoPost.Categoria = "jjjjj";
        juegoPost.Estado = true;
        juegoPost.Descripcion = "fff";
        juegoPost.Multijugador = true;
        //string jsJuegos = juegoPost.getJson("Cacha", "Educativo", "algo", true, true);

        string jsJuegos = JsonUtility.ToJson(juegoPost);
        UnityWebRequest wr_Post = UnityWebRequest.Post("http://localhost:8085/api/Labic", jsJuegos);

        wr_Post.SendWebRequest();




        yield return wr_Post.SendWebRequest();

        //Debug.Log(wr_Post.downloadHandler.text);

    }

    // ver opcion para guardar los datos
    //    clase pública PlayerState: MonoBehaviour
    //{
    //    cadena pública playerName;
    //    vida pública int
    //    salud pública flotante;

    //    cadena pública SaveToString()
    //    {
    //        devolver JsonUtility.ToJson(este);
    //    }

    //    // Dado:
    //    // playerName = "Dr Charles"
    //    // vidas = 3
    //    // salud = 0.8f
    //    // SaveToString devuelve:
    //    // {"playerName": "Dr Charles", "lives": 3, "health": 0.8}
    //}

}
