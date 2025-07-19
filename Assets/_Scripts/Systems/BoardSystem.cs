using System.Collections.Generic;
using _Scripts.Cards;

namespace _Scripts
{
    public class BoardSystem
    {
        private List<UnitCardSo> _fieldUnits = new();

        public void Summon(UnitCardSo unit)
        {
            if (_fieldUnits.Count >= 6) return;
            _fieldUnits.Add(unit);
            //Summon unit
        }

        public void Remove(UnitCardSo unit)
        {
            _fieldUnits.Remove(unit);
            //Death trigger on unit
        }
    }
}