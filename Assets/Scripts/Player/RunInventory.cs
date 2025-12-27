using System.Collections.Generic;
using UnityEngine;

public class RunInventory : MonoBehaviour
{
    [System.Serializable]
    public class AmmoStack
    {
        public AmmoType ammoType;
        public int amount;
    }

    public List<AmmoStack> ammo = new();

    public int healingItems;
    public int runCurrency;

    public void ResetInventory()
    {
        ammo.Clear();
        healingItems = 0;
        runCurrency = 0;
    }

    public void AddAmmo(AmmoType type, int amount)
    {
        var stack = ammo.Find(a => a.ammoType == type);
        if (stack == null)
        {
            ammo.Add(new AmmoStack { ammoType = type, amount = amount });
            //print("Created new ammo stack: " + type + " x" + amount);
        }
        else
        {
            stack.amount += amount;
            //print("Added ammo: " + type + " x" + amount + " (total: " + stack.amount + ")");
        }
    }

    public void ConsumeAmmo(AmmoType type, int amount)
    {
        var stack = ammo.Find(a => a.ammoType == type);
        if (stack != null)
        {
            stack.amount = Mathf.Max(0, stack.amount - amount);
            print("Consumed ammo: " + type + " x" + amount + " (remaining: " + stack.amount + ")");
        }
    }

    public int GetAmmo(AmmoType type)
    {
        var stack = ammo.Find(a => a.ammoType == type);
        return stack != null ? stack.amount : 0;
    }
}

