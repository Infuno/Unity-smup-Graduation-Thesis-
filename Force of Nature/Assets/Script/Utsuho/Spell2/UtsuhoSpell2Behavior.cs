using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2Behavior : MonoBehaviour
{
    public GameObject Lazer1;
    public GameObject Lazer2;
    public GameObject BulletSpawner;

    private void Start()
    {
        StartCoroutine(StartLazer());
    }
    IEnumerator StartLazer()
    {
        Lazer1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Lazer2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BulletSpawner.SetActive(true);
    }
}
