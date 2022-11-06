using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell3BulletSpawner : MonoBehaviour
{
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    public float GapRate;
    public GameObject BulletPrefab;

    public int a = 11;
    public void SpawnLeftSide()
    {
        for (float i = MinY; i < MaxY; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(MinX, i,0), Quaternion.Euler(0,0,270));
        }
    }
    public void SpawnRightSide()
    {
        for (float i = MinY; i < MaxY; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(MaxX, i, 0), Quaternion.Euler(0, 0, 90));
        }
    }
    public void SpawnUp()
    {
        for (float i = MinX; i < MaxX; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(i, MaxY, 0), Quaternion.Euler(0, 0, 180));
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            SpawnLeftSide();
            SpawnRightSide();
            SpawnUp();
        }
    }
}
