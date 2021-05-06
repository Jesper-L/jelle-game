using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("wall"))
        {
            GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explo, .333f);
            Destroy(gameObject);
        }
        if (obj.CompareTag("enemy"))
        {
            Destroy(obj.gameObject);
            GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explo, .333f);
            Destroy(gameObject);
        }

    }
}
