using UnityEngine;
using UnityEngine.UI;

public class ClickableInfo : MonoBehaviour
{
    public GameObject Cube;
    public GameObject MillingMachine;
    public GameObject WeldingMachine;

    public GameObject Panel;

    public Button infoMillingButton;
    public Button millingProcessButton;

    public GameObject infoPanelForMilling;
    public GameObject millingProcessPanel;

    public GameObject[] weldingPanels; 

    private bool clickedMilling = false;
    private bool clickedWelding = false;

    void Start()
    {
        Panel.SetActive(false);
        infoPanelForMilling.SetActive(false);
        millingProcessPanel.SetActive(false);

        infoMillingButton.gameObject.SetActive(false);
        millingProcessButton.gameObject.SetActive(false);

        foreach (GameObject panel in weldingPanels)
        {
            panel.SetActive(false);
        }

        infoMillingButton.onClick.AddListener(ShowInfoMillingPanel);
        millingProcessButton.onClick.AddListener(ShowMillingProcessPanel);
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
                    Panel.SetActive(true);
                    clickedMilling = false;
                    clickedWelding = false;
                    HideWeldingPanels();
                    return;
                }

                if (clickedObj == MillingMachine)
                {
                    infoMillingButton.gameObject.SetActive(true);
                    millingProcessButton.gameObject.SetActive(true);
                    clickedMilling = true;
                    clickedWelding = false;
                    HideWeldingPanels();
                    return;
                }

                if (clickedObj == WeldingMachine)
                {
                    foreach (GameObject panel in weldingPanels)
                    {
                        panel.SetActive(true);
                    }
                    clickedMilling = false;
                    clickedWelding = true;
                    HideMillingUI();
                    return;
                }

               
                HideAllUI();
            }
            else
            {
               
                HideAllUI();
            }
        }
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
        if (clickedMilling)
        {
            infoMillingButton.gameObject.SetActive(false);
            millingProcessButton.gameObject.SetActive(false);
            infoPanelForMilling.SetActive(false);
            millingProcessPanel.SetActive(false);
            clickedMilling = false;
        }
    }

    void HideWeldingPanels()
    {
        foreach (GameObject panel in weldingPanels)
        {
            panel.SetActive(false);
        }
        clickedWelding = false;
    }

    void HideAllUI()
    {
        Panel.SetActive(false);
        HideMillingUI();
        HideWeldingPanels();
    }

    public void HidePanel()
    {
        HideAllUI();
    }
}
