using System;
using _Scripts.Cards;
using _Scripts.Players; 
using _Scripts.Utilities;
using TMPro;
using UnityEngine;
namespace _Scripts.UI
{
    public class GameplayPresenter : UIBaseView
    {
        [SerializeField] PlayerController player;
        [SerializeField] PlayerController opponent;
        
        [SerializeField] private OpponentPresenter opponentPresenter;
        [SerializeField] private PlayerPresenter playerPresenter;

        private void OnEnable()
        {
            
        }
    }
}