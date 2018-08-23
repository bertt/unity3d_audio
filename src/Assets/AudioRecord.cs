using Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets
{
    public class AudioRecord : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        AudioClip audioClip;

        public void OnPointerDown(PointerEventData eventData)
        {
            audioClip = Microphone.Start(null, false, 10, 44100);

            GetComponentInChildren<Text>().text = "Is recording...";
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            AudioLib.Save("test.wav", audioClip);
            GetComponentInChildren<Text>().text = "Start recording";
        }
    }
}
