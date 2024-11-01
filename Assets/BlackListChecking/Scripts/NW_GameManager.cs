using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_GameManager : MonoBehaviour
{
    public List<string> villagerNameList;
    public List<string> blacklist;
    public List<GameObject> villagerList;

    public int villagerCount;
    public int randomValue;
    
    public GameObject villagerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        blacklist.Add("Scott");
        
        villagerNameList.Add("Scott");
        villagerNameList.Add("Robert");
        villagerNameList.Add("Tom");
    }

    // Update is called once per frame
    void Update()
    {
        randomValue = Random.Range(0, villagerNameList.Count);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(villagerPrefab);
        }
    }

    // private IEnumerator listChecker()
    // {
    //     if (villagerCount > 0)
    //     {
    //         
    //     }
    // }
}
