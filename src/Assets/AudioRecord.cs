using Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets
{
    public class AudioRecord : MonoBehaviour, IPointerUpHandler
    {
        AudioClip audioClip;
        bool isRecording;

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!isRecording)
            {
                audioClip = Microphone.Start(null, false, 10, 44100);
                GetComponentInChildren<Text>().text = "Is recording...";
                isRecording = true;
            }
            else
            {
                Microphone.End(null);
            }
        }

        void Update()
        {
            if (!Microphone.IsRecording(null) && isRecording)
            {
                AudioLib.Save("test.wav", audioClip);
                GetComponentInChildren<Text>().text = "Start recording";
                isRecording = false;
            }
        }
    }
}
