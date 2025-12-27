using UnityEngine;
using System;

public class PlayerXP : MonoBehaviour
{
    public int currentXP;
    public int xpToNextLevel = 100;

    public event Action<int, int> OnXPChanged;

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }

        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
    }

    private void LevelUp()
    {
        // chama tela de escolha de bônus depois
    }
}
