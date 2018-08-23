using JetBrains.Annotations;
using System.IO;
using UnityEngine;

public class AudioRecord : MonoBehaviour {
    AudioClip myAudioClip;

    void Start() { }
    void Update() { }

    [UsedImplicitly]
    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 10, 200, 100), "Record"))
        {
            Debug.Log("utrecht recording!");

            var devices =Microphone.devices;
            myAudioClip = Microphone.Start(null, false, 10, 44100);

        }
        if (GUI.Button(new Rect(50, 150, 200, 100), "Save"))
        {
            Debug.Log("utrecht saving!");
            // SavWav.TrimSilence(myAudioClip,2);
            SavWav.Save("myfile", myAudioClip);
        }
        if (GUI.Button(new Rect(50, 260, 200, 100), "Play"))
        {
            Debug.Log("utrecht playing!");
            // SavWav.TrimSilence(myAudioClip,2);
            var filename = "myfile.wav";
            var filepath = Path.Combine(Application.persistentDataPath, filename);
            filepath = @"C:\Users\bertt\myfile.wav";
            WWW audioLoader = new WWW(filepath);
            while (!audioLoader.isDone)
            {
                Debug.Log("uploading");
            }
            var audioclip = audioLoader.GetAudioClip();
            var audioSource = GameObject.Find("Audio").GetComponentInChildren<AudioSource>();
            audioSource.clip = audioclip;
            audioSource.Play();
        }


    }
}
