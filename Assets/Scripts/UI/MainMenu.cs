using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject player;

    public Button inventory;
    public Button skill;
    public Button campaign;
    public Button home;

    public GameObject inventoryPanel;
    public GameObject skillPanel;
    public GameObject campaignPanel;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(0, 1.35f, 0);
        inventory.onClick.AddListener(OpenInventory);
        home.onClick.AddListener(Home);
    }

    public void OpenInventory()
    {
        inventory.gameObject.SetActive(false);
        skill.gameObject.SetActive(false);
        campaign.gameObject.SetActive(false);
        skillPanel.SetActive(false);
        campaignPanel.SetActive(false);
        player.transform.position += new Vector3(1.3f, 0, 0);
        inventoryPanel.SetActive(true);
    }

    public void Home()
    {
        player.transform.position = new Vector3(0, 1.35f, 0);
        inventory.gameObject.SetActive(true);
        skill.gameObject.SetActive(true);
        campaign.gameObject.SetActive(true);
        inventoryPanel.SetActive(false);
        skillPanel.SetActive(false);
        campaignPanel.SetActive(false);
    }
}
