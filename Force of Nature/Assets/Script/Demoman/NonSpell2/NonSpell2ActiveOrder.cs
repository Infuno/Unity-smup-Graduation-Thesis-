using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSpell2ActiveOrder : MonoBehaviour
{
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject FlameBulletPoint;

    private void Start()
    {
        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.6f);
        Spawner1.SetActive(true);
        Spawner2.SetActive(true);
        Spawner3.SetActive(true);
        Spawner4.SetActive(true);
        FlameBulletPoint.SetActive(true);
    }
}
