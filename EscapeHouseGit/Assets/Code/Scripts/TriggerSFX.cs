using System.Collections;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound;
    public bool triggered = false;
    public GameObject textbox;


    void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            playSound.Play();
            StartCoroutine(PlaySubtitle());
            triggered = true;
        }
    }

    IEnumerator PlaySubtitle()
    {
        textbox.SetActive(true);
        yield return new WaitForSeconds(5);
        textbox.SetActive(false);
    }
}
