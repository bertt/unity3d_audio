using Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets
{
    public class AudioRecord : MonoBehaviour, IPointerUpHandler
    {
        bool isRecording = false;

        AudioClip audioClip;

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!isRecording)
            {
                audioClip = Microphone.Start(null, false, 10, 44100);
                GetComponentInChildren<Text>().text = "Is recording...";
            }
            else
            {
                AudioLib.Save("test.wav", audioClip);
                GetComponentInChildren<Text>().text = "Start recording";
            }

            isRecording = !isRecording;
        }
    }
}
