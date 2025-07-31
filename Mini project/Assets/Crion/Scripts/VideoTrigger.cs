using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoTrigger : MonoBehaviour
{
    public GameObject woodPanel;           
    public VideoPlayer woodVideoPlayer;     
    public Button backButton;               
    public string interactTag = "WoodPlanks"; 

    private bool isPanelVisible = false;

    void Start()
    {
        woodPanel.SetActive(false);
        backButton.onClick.AddListener(HidePanel);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                if (hit.collider.CompareTag(interactTag))
                {
                    ShowPanel();
                }
                
                else if (isPanelVisible)
                {
                    HidePanel();
                }
            }
            else if (isPanelVisible)
            {
                HidePanel();
            }
        }
    }

    void ShowPanel()
    {
        woodPanel.SetActive(true);
        woodVideoPlayer.Play();
        isPanelVisible = true;
    }

    void HidePanel()
    {
        woodVideoPlayer.Stop();
        woodPanel.SetActive(false);
        isPanelVisible = false;
    }
}
