using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemSlotContainer;
    public GameObject itemSlotPrefab;

    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemSlotContainer);
            Image icon = slot.GetComponentInChildren<Image>();
            icon.sprite = item.itemIcon;
        }
    }

}
