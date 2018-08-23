using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets
{
    public class AudioPlay : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            var filename = "test.wav";
            var audioSource = GameObject.Find("Audio").GetComponentInChildren<AudioSource>();
            StartCoroutine(PlayMusic(filename, audioSource));
        }

        public IEnumerator PlayMusic(string filename, AudioSource audioSource)
        {
            var filepath = Path.Combine(Application.persistentDataPath, filename);
            WWW audioLoader = new WWW(@"file://" + filepath);
            yield return audioLoader;
            var audioclip = audioLoader.GetAudioClip();
            audioSource.clip = audioclip;
            audioSource.Play();
        }
    }
}
