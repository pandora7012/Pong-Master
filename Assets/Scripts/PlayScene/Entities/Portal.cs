using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            linkedPortal.DisableCol();
            collision.transform.position = linkedPortal.gameObject.transform.position;
        }
    }

    public void DisableCol()
    {
        collider.enabled = false;
        StartCoroutine("disTime");
    }

    private IEnumerator disTime()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true; 
    }
}
