using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpooler : MonoBehaviour
{
    [SerializeField] GameObject poolprefab;
    [SerializeField] int itemcount;
    public List<GameObject> itempool;
    public static objectpooler instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        itempool = new List<GameObject>();
        for(int i=0;i<itemcount;i++)
        {
            var temp = Instantiate(poolprefab);
            itempool.Add(temp);
            temp.SetActive(false);
        }
    }

    public GameObject spawnfrompool(Vector3 pos)
    {
        for(int i=0;i<itempool.Count;i++)
        {
            if(!itempool[i].activeInHierarchy)
            {
                var temp = itempool[i];
                temp.SetActive(true);
                temp.transform.position = pos;
                return temp;
            }
        }
        return null;
    }
   
}
