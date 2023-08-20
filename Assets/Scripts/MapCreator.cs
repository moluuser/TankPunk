using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject[] item;
    // 0. Base
    // 1. Wall
    // 2. Barrier
    // 3. River
    // 4. Grass

    private List<Vector3> itemPositionList = new List<Vector3>();

    private void Awake()
    {
        CreateItem(item[0], new Vector3(0, (float)-10.5, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -9, 0), Quaternion.identity);

        CreateItem(item[1], new Vector3((float)-1.5, (float)-10.5, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3((float)-1.5, -9, 0), Quaternion.identity);

        CreateItem(item[1], new Vector3((float)1.5, (float)-10.5, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3((float)1.5, -9, 0), Quaternion.identity);

        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[3], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
    }

    private void CreateItem(GameObject createItem, Vector3 createPosition, Quaternion createRotation)
    {
        Instantiate(createItem, createPosition, createRotation);
        itemPositionList.Add(createPosition);
    }

    private Vector3 CreateRandomPosition()
    {
        while (true)
        {
            float x = Random.Range(-7, 7) * 1.5f;
            float y = Random.Range(-7, 7) * 1.5f;
            Vector3 createPosition = new Vector3(x, y, 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
    }

    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }
}
