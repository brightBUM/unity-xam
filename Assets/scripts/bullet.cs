using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    Vector3 direction;
    [SerializeField]float bulletspeed = 5f;
    [SerializeField] float destroytime = 2f;

    private void OnEnable()
    {
        StartCoroutine(dieaftersometime(destroytime));
        rb.velocity = Vector3.zero;
        
    }
    IEnumerator dieaftersometime(float destroytime)
    {
        yield return new WaitForSeconds(destroytime);
        this.gameObject.SetActive(false);
    }
    public void setdirection(Vector3 dir)
    {
        this.direction = dir;
    }
    private void Update()
    {

        rb.velocity += direction * bulletspeed * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 6 || other.gameObject.layer == 7)
        {
            if(other.gameObject.GetComponent<Enemy>())
            {
                other.gameObject.GetComponent<Enemy>().takedamage();
            }
            this.gameObject.SetActive(false);
        }
    }
}
