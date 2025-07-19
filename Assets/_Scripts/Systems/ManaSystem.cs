using System;
using UnityEngine;

namespace _Scripts
{
    public class ManaSystem
    {
        public int CurrentMana { get; private set; }
        public int MaxMana { get; private set; }

        public ManaSystem()
        {
            CurrentMana = 4;
        }

        public void StartTurn(int turn)
        {
            MaxMana = Mathf.Min(10, turn);
            CurrentMana = MaxMana;
        }

        public bool HasEnough(int cost) => CurrentMana >= cost;

        public void Spend(int cost)
        {
            if (!HasEnough(cost)) throw new Exception("Không đủ ");
            CurrentMana -= cost;
        }
    }
}