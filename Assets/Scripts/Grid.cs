using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    private readonly int sizeX = 10;
    private readonly int sizeY = 10; 

    // Start is called before the first frame update
    void Awake()
    {
        CreaterGrid();
    }

    private void CreaterGrid()
    {
        int size = sizeX * sizeY;
        int x = 0;
        int y = 0;
        for (int i = 0; i < size; i++)
        {
            Vector3 pos = new Vector3(x, 0, y);
            GameObject clone = CreateCell(pos);
            x++;
            if (x >= sizeY)
            {
                x = 0;
                y++;
            }
        }
    }

    private GameObject CreateCell(Vector3 pos)
    {
        GameObject clone = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
        clone.name = string.Format("{0}_{1}", pos.x, pos.z);
        return clone;
    }
}
