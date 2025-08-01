using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public GameObject weldingButton; // Assign in Inspector (the actual UI Button GameObject)

    void Start()
    {
        // Hide the button at the start
        if (weldingButton != null)
            weldingButton.SetActive(false);
    }

    void OnMouseDown()
    {
        // When user clicks this object (WeldingMachine), show the button
        if (weldingButton != null)
            weldingButton.SetActive(true);
    }

    public void LoadWorkshopScene()
    {
        Debug.Log("Loading WorkshopScene");
        SceneManager.LoadScene("WorkshopScene");
    }
}
