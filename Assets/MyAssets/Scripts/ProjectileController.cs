using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Transform myTransform;
    
    public float speed;

    private void Update()
    {
        myTransform.position += myTransform.up * (speed * Time.deltaTime);
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
