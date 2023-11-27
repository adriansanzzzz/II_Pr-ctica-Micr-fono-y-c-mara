using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{   
    private Material tvMaterial;
    public string path;
    public WebCamTexture webcamTexture;
    private int CaptureCounter = 1;
    private bool bool_camera;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] cameras = WebCamTexture.devices;
        for (int i = 0; i < cameras.Length; i++)
            Debug.Log("Nombre camara: " + cameras[i].name); 

        
        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        tvMaterial = GetComponent<Renderer>().material;
        path = "/Users/adriansanz/Desktop/fot";
        bool_camera = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("s")) { // Active cam
        if (!bool_camera)
          Debug.Log("Camara activa.");
          bool_camera = true;
          tvMaterial.mainTexture = webcamTexture;
          webcamTexture.Play();
       }

       if (Input.GetKey("p")) { //Pause cam
         if (bool_camera)
          Debug.Log("Camara inactiva.");
          bool_camera = false;
          webcamTexture.Stop();
       }

       if (Input.GetKey("x")) { // Take snapshot
            if (bool_camera){
                Debug.Log("Foto");
                Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
                snap.SetPixels(webcamTexture.GetPixels());
                snap.Apply();
                System.IO.File.WriteAllBytes(path + CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
                ++CaptureCounter;
                Debug.Log(path + CaptureCounter.ToString());
            } else {
                Debug.Log("La camara debe estar activa para hacer capturas.");
            }
       }
       
    }
}
