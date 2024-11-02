using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NW_GameManager : MonoBehaviour
{
    public List<string> villagerNameList;
    public List<string> randomNameList;
    public List<string> blacklist;
    public List<GameObject> villagerList;

    public string namePlaceholder;
    public string randomName;
    public int counter;
    public int score = 0;
    public bool inConversation;
    public bool gameOver;
    
    public GameObject villagerPrefab;
    public NW_Villager villager;
    
    void Start()
    {
        counter = 0;
        
        blacklist.Add("Scott");
        blacklist.Add("Tom");
        
        villagerNameList.Add("Scott");
        villagerNameList.Add("Robert");
        villagerNameList.Add("Tom");
        villagerNameList.Add("Lucy");
        villagerNameList.Add("Misty");

        while (villagerNameList.Count != 0)
        {
            randomName = villagerNameList[Random.Range(0, villagerNameList.Count)];
            randomNameList.Add(randomName);
            villagerNameList.Remove(randomName);
        }
        
        foreach (var a in randomNameList)
        {
            namePlaceholder = randomNameList[counter];
            Instantiate(villagerPrefab);
            counter += 1;
        }
    }

    void Update()
    {
        if (villagerList.Count > 0 && !inConversation)
        {
            inConversation = true;

            StartCoroutine(listChecker());
        }
        
        if (!gameOver && villagerList.Count <= 0)
        {
            Debug.Log("No more villagers remain in the waiting line.");
            Debug.Log($"Your score is {score}.");
            gameOver = true;
        }
    }

    private IEnumerator listChecker()
    {
        villager = FindObjectOfType<NW_Villager>();
        Debug.Log("This villager's name is " + villager.villagerName);
        
        yield return new WaitForSeconds(0.5f);
        
        Debug.Log("Do you wish to let them pass?");
        
        yield return WaitForInput(KeyCode.Space);
        
        inConversation = false;
        
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator WaitForInput(KeyCode key)
    {
        bool decisionMade = false;
        while(!decisionMade)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Letting villager in.");
                
                yield return new WaitForSeconds(1f);
                
                if (villager.isBanned)
                {
                    Debug.Log("This villager is banned. Wrong choice.");
                }
                else
                {
                    Debug.Log("This villager passed the security check.");
                    score += 1;
                }
                
                Destroy(villager.gameObject);
                
                yield return new WaitForSeconds(1f);
                
                decisionMade = true;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("Chasing villager away.");

                yield return new WaitForSeconds(1f);
                
                if (!villager.isBanned)
                {
                    Debug.Log("This villager is innocent. You chased away a potential customer.");
                }
                else
                {
                    Debug.Log("You chased away a potential criminal.");
                    score += 1;
                }
                
                Destroy(villager.gameObject);
                
                yield return new WaitForSeconds(1f);
                
                decisionMade = true;
            }
            
            yield return null; 
        }
    }
}
