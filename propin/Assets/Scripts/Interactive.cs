using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InteractionEvent : UnityEvent<GameObject>
{
}

public class Interactive : MonoBehaviour
{
    public string Prompt;
    public InteractionEvent Interaction;
    public InteractionEvent OnApproach;
    public InteractionEvent OnLeave;
    public ItemMetaData ItemRequired;
    public void Interact(GameObject sender)
    {
        if (ItemRequired != null)
        {
            if (!sender.GetComponent<Inventory>().Contains(ItemRequired.ID))
            {
                return;
            }
        }
        Interaction?.Invoke(sender);
    }

    public void Approach(GameObject sender)
    {
        OnApproach?.Invoke(sender);
    }

    public void Leave(GameObject sender)
    {
        OnLeave?.Invoke(sender);
    }
}
