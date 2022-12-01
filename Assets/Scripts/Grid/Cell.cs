using System;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class Cell : MonoBehaviour
    {
        [Serializable]
        public struct CellData
        {
            public int Xindex;
            public int Yindex;

            public CellData(int x, int y)
            {
                Xindex = x;
                Yindex = y;
            }
        }

        public bool HasConstruction => _hasConstruction;
        public Cell.CellData GetCellData => _cellData;

        private CellData _cellData;
        private bool _hasConstruction;
      
        public void Init(int x, int y)
        {
            _cellData = new CellData(x,y);            
            name = string.Format("{0}_{1}", x, y);
        }

        public void SetConstruction(bool value)
        {
            _hasConstruction = value;
        }
    }
}