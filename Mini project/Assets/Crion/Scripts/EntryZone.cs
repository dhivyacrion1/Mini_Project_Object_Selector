using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryZone : MonoBehaviour
{
    public GameObject Welcomepanel;
    public TextMeshProUGUI WelcomeText;
    public bool isEntryZone;

    [SerializeField] private AudioSource waterAudio;

    private bool hasTriggered = false;

    void Start()
    {
        Welcomepanel.SetActive(false);
        WelcomeText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("MainCamera"))
        {
            Welcomepanel.SetActive(true);
            WelcomeText.enabled = true;
            WelcomeText.text = "Welcome To Machine Factories";

            
            if (waterAudio != null && !waterAudio.isPlaying)
            {
                waterAudio.Play();
            }

            StartCoroutine(ShowPanel());

            hasTriggered = true;
        }
    }

    public IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(3f);
        Welcomepanel.SetActive(false);
        WelcomeText.enabled = false;
    }
}
