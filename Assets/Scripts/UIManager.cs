using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Button weaponButton;
    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.I)){
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }
}
