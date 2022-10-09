using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SpawnBehavior : MonoBehaviour
{
    public GameObject Fairy1Left;
    public GameObject Fairy1Right;
    public GameObject BigFairyUp;
    public GameObject StageTitle;
    public GameObject Fairy2Left;
    public GameObject Fairy2Right;
    public GameObject Fairy3Right;
    public GameObject Fairy4Up;
    public GameObject BigFairy2Right;
    public GameObject BigFairy2Left;
    public GameObject Fairy5Left;
    public GameObject Fairy5Right;

    public GameObject Boss;
    void Start()
    {
        StartCoroutine(Stage1());
    }

    void Update()
    {
        
    }
    IEnumerator Stage1()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(Seq1());
        yield return new WaitForSeconds(7f);
        StartCoroutine(Seq2());
        yield return new WaitForSeconds(12f);
        Title();
        yield return new WaitForSeconds(5f);
        StartCoroutine(Seq3());
        yield return new WaitForSeconds(12f);
        StartCoroutine(Seq4());
        yield return new WaitForSeconds(5f);
        StartCoroutine (Seq5());
        yield return new WaitForSeconds(10f);
        StartCoroutine(Seq6());
        yield return new WaitForSeconds(25f);
        Boss.SetActive(true);
    }
    IEnumerator Seq1()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Fairy1Left, new Vector3(-4.5f,0,0), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Fairy1Right, new Vector3(4.5f, 0, 0), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator Seq2()
    {
        Instantiate(BigFairyUp, new Vector3(-3f, 6, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(BigFairyUp, new Vector3(3f, 6, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(1f);
        Instantiate(BigFairyUp, new Vector3(-2f, 6.5f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(BigFairyUp, new Vector3(2f, 6.5f, 0), new Quaternion(0, 0, 0, 0));
    }
    private void Title()
    {
        StageTitle.SetActive(true);
    }
    IEnumerator Seq3()
    {
        Instantiate(Fairy2Right, new Vector3(-1.5f, 2, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy2Left, new Vector3(1.5f, 2, 0), new Quaternion(0, 0, 0, 0));

        yield return new WaitForSeconds(2f);
        Instantiate(Fairy2Left, new Vector3(-3.5f, 2.2f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-2.9f, 2.9f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-1.4f, 1.8f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-0.6f, 2.3f, 0), new Quaternion(0, 0, 0, 0));

        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(0.4f, 1.7f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(1.4f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(1.9f, 2, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(2.5f, 2.2f, 0), new Quaternion(0, 0, 0, 0));

        yield return new WaitForSeconds(1f);
        Instantiate(BigFairyUp, new Vector3(-3f, 6, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(BigFairyUp, new Vector3(3f, 6, 0), new Quaternion(0, 0, 0, 0));

        yield return new WaitForSeconds(2f);
        Instantiate(Fairy2Right, new Vector3(2.5f, 2.2f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(1.9f, 2, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(1.4f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Right, new Vector3(0.4f, 1.7f, 0), new Quaternion(0, 0, 0, 0));

        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-3.5f, 2.2f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-2.9f, 2.9f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-1.4f, 1.8f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(Fairy2Left, new Vector3(-0.6f, 2.3f, 0), new Quaternion(0, 0, 0, 0));

    }
    IEnumerator Seq4()
    {
        Instantiate(Fairy3Right, new Vector3(-1.7f, 0, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 0, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.7f, 0.5f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 0.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.7f, 1, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 1, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.7f, 1.5f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 1.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.7f, 2, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 2, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.7f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.7f, 2.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-1.9f, 3f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.5f, 3, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-2.1f, 3.5f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.3f, 3.5f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        Instantiate(Fairy3Right, new Vector3(-2.3f, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy3Right, new Vector3(1.1f, 4, 0), new Quaternion(0, 0, 0, 0));
    }
    IEnumerator Seq5()
    {
        Instantiate(BigFairy2Left, new Vector3(-2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(BigFairy2Right, new Vector3(2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-3f, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(0, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-2.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(0.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-2, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(1, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-1.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(1.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-1, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(2, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Fairy4Up, new Vector3(-0.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(Fairy4Up, new Vector3(2.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(2f);
        Instantiate(BigFairy2Left, new Vector3(-2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(BigFairy2Right, new Vector3(2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
    }
    IEnumerator Seq6()
    {
        float YLocate;
        for (int i = 0; i < 50; i++)
        {
            YLocate = Random.Range(1.1f, 4.1f);
            Instantiate(Fairy5Left, new Vector3(-4.5f, YLocate, 0), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(0.2f);
            YLocate = Random.Range(1.1f, 4.1f);
            Instantiate(Fairy5Right, new Vector3(4.5f, YLocate, 0), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(0.2f);
            if (i == 12)
            {
                Instantiate(BigFairyUp, new Vector3(-2f, 6.5f, 0), new Quaternion(0, 0, 0, 0));
                Instantiate(BigFairyUp, new Vector3(2f, 6.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (i == 30)
            {
                Instantiate(BigFairy2Left, new Vector3(-2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
                Instantiate(BigFairy2Right, new Vector3(2.5f, 5, 0), new Quaternion(0, 0, 0, 0));
            }
        } 
    }
}
