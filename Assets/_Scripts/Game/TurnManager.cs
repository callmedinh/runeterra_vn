using _Scripts.Players;
using _Scripts.Utilities;
using UnityEngine.Serialization;

namespace _Scripts.Cores
{
    public class TurnManager : Singleton<TurnManager>
    {
        public PlayerController owner;
        public PlayerController opponent;
        private bool _isPlayerTurn;

        public void StartTurn(bool player)
        {
            _isPlayerTurn = player;
            var current = _isPlayerTurn ? this.owner : opponent;
            current.StartTurn(1);
        }

        public void EndTurn()
        {
            StartTurn(!_isPlayerTurn);
        }
    }
}