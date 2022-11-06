using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonspell2Spinner : MonoBehaviour
{
    public float SpinSpeed;
    private void Start()
    {
        StartCoroutine(SpeedUp());
    }
    private void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5);
        SpinSpeed += 2;
        StartCoroutine(SpeedUp());
    }

}
