using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    public float switchThreshold = 0.2f; // dead zone
    public InteractionUI interactionUI;

    private readonly List<InteractableItem> nearbyItems = new();
    private InteractableItem currentItem;
    private RunInventory playerInventory;
    private PlayerXP playerXP;
    public Weapon weapon;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        // Pega o inventário no Player (pai)
        playerInventory = GetComponentInParent<RunInventory>();
        playerXP = GetComponentInParent<PlayerXP>();

    }


    private void Update()
    {
        UpdateClosestItem();
    }

    private void UpdateClosestItem()
    {
        if (nearbyItems.Count == 0)
        {
            currentItem = null;
            interactionUI.Hide();
            return;
        }

        InteractableItem closest = currentItem;
        float closestDist = closest ? DistanceTo(closest) : float.MaxValue;

        foreach (var item in nearbyItems)
        {
            float dist = DistanceTo(item);

            if (closest == null || dist < closestDist - switchThreshold)
            {
                closest = item;
                closestDist = dist;
            }
        }

        if (closest != currentItem)
        {
            currentItem = closest;
            string text = LocalizationManager.Instance.Get(currentItem.itemData.promptKey);
            interactionUI.Show(
                currentItem.promptAnchor.position,
                text,
                currentItem.itemData.icon
            );
        }
        else if (currentItem != null)
        {
            interactionUI.UpdatePosition(currentItem.promptAnchor.position);
        }


        //print("Current Interactable Item: " + (currentItem ? currentItem.name : "None"));
    }

    // 🔑 Chamado pelo InputManager
    public void TryInteract()
    {
        if (currentItem == null) return;
        print("Interacting with: " + currentItem.name);
        currentItem.Interact(playerInventory, playerXP, weapon, playerHealth);
        nearbyItems.Remove(currentItem);
        currentItem = null;
        interactionUI.Hide();
    }

    private float DistanceTo(InteractableItem item)
    {
        return Vector3.Distance(transform.position, item.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Entered: " + other.name);

        if (other.GetComponentInParent<InteractableItem>() is InteractableItem item)
        {
           // Debug.Log("Interactable Item Detected");

            if (!nearbyItems.Contains(item))
                nearbyItems.Add(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger Exited: " + other.name);

        if (other.GetComponentInParent<InteractableItem>() is InteractableItem item)
        {
            nearbyItems.Remove(item);
        }
    }
}
