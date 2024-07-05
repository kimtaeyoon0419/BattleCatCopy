// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DieGhost : MonoBehaviour
{
    [Header("¼Óµµ")]
    [SerializeField] private float speed;

    private void OnEnable()
    {
        StartCoroutine(Co_DestroyObj());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    IEnumerator Co_DestroyObj()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
