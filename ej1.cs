using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej1 : MonoBehaviour
{
    public string arañaTag = "araña"; // Etiqueta del zombie
    public AudioSource audioSource; // Arrastra el AudioSource al Inspector de Unity
    public AudioClip clipToPlay; // Agrega esta variable y asígnale un AudioClip desde el Inspector
    
    private bool isRecording;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(arañaTag)){
            Debug.Log(" colision con araña");
            
            audioSource.PlayOneShot(clipToPlay);
            
        }

    }

   
}
