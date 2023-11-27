using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private AudioSource audioSource;
    
    private bool isRecording;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        isRecording = true;
    }

    // Update is called once per frame
    void Update()
    {           
        // En cada frame verificar si se ha pulsado la tecla para iniciar la
        // recogida de audio desde el micrófono.
        if (Input.GetKey("r") && !isRecording)
        {
            // Iniciar la recogida de audio por el micrófono
            audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
            isRecording = true;
        }

        // En cada frame verificar si el usuario ha decidido parar el micrófono
        if (Input.GetKey("s") && isRecording)
        {
            // Finalizar la captación de audio por el micrófono.
            Microphone.End(Microphone.devices[0]);
            audioSource.Play(); // Reproducir el clip que se ha vinculado al AudioSource
            isRecording = false;
        }
    }
}