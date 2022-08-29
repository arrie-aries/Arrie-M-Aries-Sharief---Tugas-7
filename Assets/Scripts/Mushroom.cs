using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = .1f;
    
    void Start()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce/2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3 (xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
        StartCoroutine(DisableObjectAfter(3f));
    }
    private void OnEnable()
    {
        StartCoroutine(DisableObjectAfter(3f));
    }
    IEnumerator DisableObjectAfter(float _time)
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
    }
}
