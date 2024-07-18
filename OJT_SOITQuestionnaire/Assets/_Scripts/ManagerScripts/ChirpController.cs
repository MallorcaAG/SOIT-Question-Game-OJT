using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChirpController : MonoBehaviour
{
    [SerializeField] private GameObject chirpObj;
    [Tooltip("X: MaxInclusive Range\nY: Chirp limit \n\t(Number less than MaxInclusive Range, greater than 0.\n\tCloser the number to Max range, lesser the odds of chirping)")]
    [SerializeField] private Vector2 chirpingOdds;
    [SerializeField] private AudioClip[] chirps;

    public void Chirp(Component sender, object data)
    {
        int ToChirpOrNotToChirp = Random.Range(0, (int)chirpingOdds.x + 1);

        if(ToChirpOrNotToChirp >= (int)chirpingOdds.y)
        {
            int whatToChirp = Random.Range(0, chirps.Length);

            GameObject obj = Instantiate(chirpObj);
            AudioSource objAudio = obj.GetComponent<AudioSource>();

            objAudio.clip = chirps[whatToChirp];
            objAudio.Play();

            Destroy(obj, 2f);
        }
    }
}
