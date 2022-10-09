using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy3Behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPrefab;
    public Transform BulletPoint;
    public float RateOfFire;
    public Transform ParentPoint;

    private GameObject Player;
    private Transform PlayerTranform;
    private float BulletCooldown = 10;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTranform = Player.transform;
    }
    private void Update()
    {

        transform.position = ParentPoint.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        BulletCooldown += Time.deltaTime;
        Shoot();
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation);
            BulletCooldown = 0;
        }
    }
}
