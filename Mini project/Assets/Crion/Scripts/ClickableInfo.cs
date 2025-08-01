using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickableInfo : MonoBehaviour
{
    public GameObject Cube;
    public GameObject MillingMachine;
    public GameObject WeldingMachine;

    public GameObject Panel;

    public Button infoMillingButton;
    public Button millingProcessButton;
    public Button weldingButton;

    public GameObject infoPanelForMilling;
    public GameObject millingProcessPanel;

    public GameObject[] weldingPanels;
    public Button backButton;

    void Start()
    {
        
        Panel.SetActive(false);
        infoPanelForMilling.SetActive(false);
        millingProcessPanel.SetActive(false);

        infoMillingButton.gameObject.SetActive(false);
        millingProcessButton.gameObject.SetActive(false);
        weldingButton.gameObject.SetActive(false); 
        backButton.gameObject.SetActive(false);

        foreach (GameObject panel in weldingPanels)
        {
            panel.SetActive(false);
        }

        infoMillingButton.onClick.AddListener(ShowInfoMillingPanel);
        millingProcessButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnMouseDown()
    {
        ShowPanelOnly();
        ShowMillingButtons();
        ShowWeldingUI();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObj = hit.collider.gameObject;

                if (clickedObj == Cube)
                {
                    ShowPanelOnly();
                }
                else if (clickedObj == MillingMachine)
                {
                    ShowMillingButtons();
                }
                else if (clickedObj == WeldingMachine)
                {
                    ShowWeldingUI();
                }
                else
                {
                    HideAllUI();
                }
            }
            else
            {
                HideAllUI();
            }
        }
    }
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ShowPanelOnly()
    {
        Panel.SetActive(true);
        HideMillingUI();
        HideWeldingUI();
    }

    void ShowMillingButtons()
    {
        Panel.SetActive(true);
        infoMillingButton.gameObject.SetActive(true);
        millingProcessButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        weldingButton.gameObject.SetActive(false);
        HideWeldingPanels();
    }

    void ShowWeldingUI()
    {
        Panel.SetActive(true);
        HideMillingUI();
        foreach (GameObject panel in weldingPanels)
        {
            panel.SetActive(true);
        }

        weldingButton.gameObject.SetActive(true); 
        backButton.gameObject.SetActive(true);
    }

    void ShowInfoMillingPanel()
    {
        infoPanelForMilling.SetActive(true);
        millingProcessPanel.SetActive(false);
    }

    void ShowMillingProcessPanel()
    {
        infoPanelForMilling.SetActive(false);
        millingProcessPanel.SetActive(true);
    }

    void HideMillingUI()
    {
        infoMillingButton.gameObject.SetActive(false);
        millingProcessButton.gameObject.SetActive(false);
        infoPanelForMilling.SetActive(false);
        millingProcessPanel.SetActive(false);
    }

    void HideWeldingUI()
    {
        HideWeldingPanels();
        weldingButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    void HideWeldingPanels()
    {
        foreach (GameObject panel in weldingPanels)
        {
            panel.SetActive(false);
        }
    }

    void HideAllUI()
    {
        Panel.SetActive(false);
        HideMillingUI();
        HideWeldingUI();
    }

    public void HidePanel()
    {
        HideAllUI();
    }
}
