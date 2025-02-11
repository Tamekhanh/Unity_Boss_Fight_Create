using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Slash : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullePrefab;
    // Start is called before the first frame update
    void Shoot()
    {
        //shooting slash
        Instantiate(bullePrefab, firePoint.position, firePoint.rotation);
    }


}
