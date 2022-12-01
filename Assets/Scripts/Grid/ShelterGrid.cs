using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class ShelterGrid : MonoBehaviour
    {
        [SerializeField] private Cell cellPrefab;

        private Cell[,] _cells;

        private readonly int sizeX = 10;
        private readonly int sizeY = 10;

        // Start is called before the first frame update
        void Awake()
        {
            CreaterGrid();
        }

        private void CreaterGrid()
        {
            _cells = new Cell [sizeX, sizeY];
            int size = sizeX * sizeY;
            int x = 0;
            int y = 0;
            for (int i = 0; i < size; i++)
            {
                Vector3 pos = new Vector3(x, 0, y);
                CreateCell(pos,x,y);
                x++;
                if (x >= sizeY)
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void CreateCell(Vector3 pos, int x, int y)
        {
            Cell clone = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
            clone.Init(x,y);            
            _cells[x, y] = clone;
        }
    }
}
