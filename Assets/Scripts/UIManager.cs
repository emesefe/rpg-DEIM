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
        if (inventoryPanel.activeInHierarchy){
            ClearInventory();
            FillInventory();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
    public void FillInventory(){
        WeaponManager weaponManager = FindObjectOfType<WeaponManager>();
        List<GameObject> weapons = weaponManager.GetAllWeapons();
        foreach(GameObject w in weapons){
            Button button = Instantiate(weaponButton, inventoryPanel.transform);
            button.onClick.AddListener(() => weaponManager.ChangeWeapon(
                w.GetComponent<WeaponDamage>().index));
            button.image.sprite = w.GetComponent<SpriteRenderer>().sprite;
        }
    }
    
    public void ClearInventory(){
        foreach(Transform item in inventoryPanel.transform){
            Destroy(item.gameObject);
        }
    }
}
