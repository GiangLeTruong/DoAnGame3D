using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampEnemies : MonoBehaviour
{
    // Random Enemi:
    [SerializeField] private GameObject[] objTypes;
    [SerializeField] private Transform[] swampPoints;
    // Nums Enemi:
    private int numsObj = 0;

    private void Start()
    {
        numsObj = swampPoints.Length;
        if (swampPoints != null)
        {
            for (int i = 0; i < numsObj; i++)
            {
                enemiSwamp(swampPoints[i]);
            }
        }
    }

    private void enemiSwamp(Transform Point)
    {
        GameObject prefab = objTypes[Random.Range(0, objTypes.Length)];
        Instantiate(prefab, new Vector3(Point.position.x, 0, Point.position.z), Quaternion.identity, transform);
    }
}
