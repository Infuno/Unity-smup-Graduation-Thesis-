using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2ActiveOrder : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.6f);
        this.GetComponent<Spell2BulletSpawn>().enabled = true;
    }
}
