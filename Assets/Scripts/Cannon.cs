using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    GameObject _Bullet;
    [SerializeField]
    Transform _Head;

    private void Start()
    {
        StartCoroutine(Shot());
    }
    IEnumerator Shot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(_Bullet, _Head.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(_Head.forward * 10000f, ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
        }
    }
}
