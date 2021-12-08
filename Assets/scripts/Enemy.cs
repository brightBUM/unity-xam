using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Transform target;
    [SerializeField] float health;
    [SerializeField] float damage = 5f;
    [SerializeField] AudioSource deathsound;
    [SerializeField] TextMeshProUGUI healthtext;

    // Start is called before the first frame update
    private void Awake()
    {
        shooting.shotenemy.AddListener(takedamage);
    }

    void Start()
    {
        
    }
    public void takedamage()
    {
        Debug.Log("damage called");
        health -= damage;
        
    }

    // Update is called once per frame
    void Update()
    {
        healthtext.text = health.ToString();
        navAgent.destination = target.position;
        if(health<=0)
        {
            deathsound.Play();
            Destroy(this.gameObject, 0.5f);

        }
    }
}
