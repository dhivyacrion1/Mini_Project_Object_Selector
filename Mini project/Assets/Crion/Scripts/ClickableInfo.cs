using UnityEngine;
using TMPro;

public class ClickableInfo : MonoBehaviour
{
    public GameObject Cube;
    public GameObject TankPanel;
    public GameObject infoPanelMillingButton;
    public GameObject howItWorksPanelButton;

    
    public TextMeshProUGUI infoPanelText;

    void Start()
    {
        TankPanel.SetActive(false);
        infoPanelMillingButton.SetActive(false);
        howItWorksPanelButton.SetActive(false);
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
                    infoPanelMillingButton.SetActive(true);
                    howItWorksPanelButton.SetActive(true);
                }
                else
                {
                    infoPanelMillingButton.SetActive(false);
                    howItWorksPanelButton.SetActive(false);
                    TankPanel.SetActive(false);
                }
            }
            else
            {
                infoPanelMillingButton.SetActive(false);
                howItWorksPanelButton.SetActive(false);
                TankPanel.SetActive(false);
            }
        }
    }

   
    public void ShowInfoPanel()
    {
        
        TankPanel.SetActive(true);
    }

    
    public void HidePanel()
    {
        TankPanel.SetActive(false);
    }
}
