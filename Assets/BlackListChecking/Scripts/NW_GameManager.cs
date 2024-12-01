using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NW_GameManager : MonoBehaviour
{
    public List<string> villagerNameList;
    public List<string> randomNameList;
    public List<string> blacklist;
    public List<GameObject> villagerList;
    private List<Vector2> positions = new List<Vector2>();

    public string namePlaceholder;
    public string randomName;
    public int counter;
    public int score = 0;
    public bool inConversation;
    public bool gameOver;
    
    public float timeR = 30f;
    public TextMeshProUGUI timerUI;
    public bool timerEnd;
    
    public GameObject villagerPrefab;
    public GameObject villagerPrefab2;
    public NW_Villager firstInLine;
    public NW_Villager villager;

    public TextMeshProUGUI gameText;
    public TextMeshProUGUI listedName1;
    public TextMeshProUGUI listedName2;
    
    public AudioSource blacklistAudioSource;
    public AudioClip correctChoice;
    public AudioClip wrongChoice;
    
    void Start()
    {
        counter = 0;
        
        blacklist.Add("Scott");
        blacklist.Add("Tom");
        
        listedName1.text = "- Scott";
        listedName2.text = "- Tom";
        
        villagerNameList.Add("Scott");
        villagerNameList.Add("Robert");
        villagerNameList.Add("Tom");
        villagerNameList.Add("Lucy");
        villagerNameList.Add("Misty");
        
        positions.Add(new Vector2(-6, -0.4f));
        positions.Add(new Vector2(-4.5f, -0.4f));
        positions.Add(new Vector2(-3, -0.4f));
        positions.Add(new Vector2(-1.5f, -0.4f));
        positions.Add(new Vector2(0, -0.4f));

        // Randomize the list of names in villagerNameList by storing them in a different order in a new list.
        while (villagerNameList.Count != 0)
        {
            randomName = villagerNameList[Random.Range(0, villagerNameList.Count)];
            randomNameList.Add(randomName);
            villagerNameList.Remove(randomName);
        }
        
        // Spawns a villager for each name on the list and assign them that name. 
        for (int i = 0; i < randomNameList.Count; i++)
        {
            namePlaceholder = randomNameList[counter];
            if (namePlaceholder == "Scott" || namePlaceholder == "Tom" || namePlaceholder == "Robert")
            {
                Instantiate(villagerPrefab, positions[i], Quaternion.identity);
            }
            else
            {
                Instantiate(villagerPrefab2, positions[i], Quaternion.identity);
            }
            
            counter += 1;
        }

        counter = 0;
    }

    void Update()
    {
        timerUI.text = "" + (int)timeR;

        if (timeR > 0)
        {
            timeR -= Time.deltaTime;

        }

        if (timeR <= 0 )
        {
            timerEnd = true;
        }
        else
        {
            timerEnd = false;
        }

        if (!timerEnd)
        {
            if (villagerList.Count > 0 && !inConversation)
            {
                inConversation = true;

                // Runs coroutine to allow player to accept or reject the villager.
                StartCoroutine(listChecker());
            }
        }
        
        // If there are no more villagers left in line or the timer has run out while the game isn't over.
        if (!gameOver && (villagerList.Count <= 0 || timerEnd))
        {
            StartCoroutine(gameEnder());
        } 
    }

    private IEnumerator listChecker()
    {
        villager = FindObjectOfType<NW_Villager>();
        firstInLine = villager;
        Debug.Log("This villager's name is " + villager.villagerName);
        gameText.text = "This villager's name is " + villager.villagerName + ".";
        
        yield return new WaitForSeconds(0.5f);
        
        Debug.Log("Do you wish to let them pass? Press Y for yes or N for no.");
        gameText.text = "This villager's name is " + villager.villagerName + ".\nDo you wish to let them pass? Press Y for yes or N for no.";
        
        yield return WaitForInput(KeyCode.Space);
        
        inConversation = false;
        
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator WaitForInput(KeyCode key)
    {
        bool decisionMade = false;
        while(!decisionMade)
        {
            // The "Yes" option.
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Letting villager in...");
                gameText.text = "Letting villager in.";
                
                yield return new WaitForSeconds(.5f);
                
                gameText.text = "Letting villager in..";
                
                yield return new WaitForSeconds(.5f);
                
                gameText.text = "Letting villager in...";
                
                yield return new WaitForSeconds(1f);
                
                if (villager.isBanned)
                {
                    Debug.Log("This villager is banned. Wrong choice.");
                    gameText.text = "This villager is banned. Wrong choice.";
                    
                    if (villager.villagerName == "Scott")
                    {
                        listedName1.text = "- <color=#BA3838>Scott</color>";
                    }

                    if (villager.villagerName == "Tom")
                    {
                        listedName2.text = "- <color=#BA3838>Tom</color>";
                    }

                    blacklistAudioSource.clip = wrongChoice;
                    blacklistAudioSource.Play();
                }
                else
                {
                    Debug.Log("This villager passed the security check.");
                    gameText.text = "This villager passed the security check.";
                    
                    blacklistAudioSource.clip = correctChoice;
                    blacklistAudioSource.Play();
                    
                    score += 1;
                }
                
                Destroy(villager.gameObject);
                
                yield return new WaitForSeconds(0.5f);
                
                foreach (GameObject villager in villagerList)
                {
                    // yield return new WaitForSeconds(0.2f);
                    villager.transform.position = new Vector2(villager.transform.position.x + 1.5f, villager.transform.position.y);
                }
                
                yield return new WaitForSeconds(2f);
                
                decisionMade = true;
            }

            // The "No" option.
            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("Chasing villager away.");
                gameText.text = "Chasing villager away.";
                
                SpriteRenderer sprite = villager.gameObject.GetComponent<SpriteRenderer>();
                sprite.sprite = villager.angrySprite;
                
                yield return new WaitForSeconds(.5f);
                
                gameText.text = "Chasing villager away..";
                
                yield return new WaitForSeconds(.5f);
                
                gameText.text = "Chasing villager away...";
                
                yield return new WaitForSeconds(1f);

                yield return new WaitForSeconds(1f);
                
                if (!villager.isBanned)
                {
                    Debug.Log("This villager is innocent. You chased away a potential customer.");
                    gameText.text = "This villager is innocent. You chased away a potential customer.";
                    
                    blacklistAudioSource.clip = wrongChoice;
                    blacklistAudioSource.Play();
                }
                else
                {
                    Debug.Log("You chased away a potential criminal.");
                    gameText.text = "You chased away a potential criminal.";
                    
                    blacklistAudioSource.clip = correctChoice;
                    blacklistAudioSource.Play();
                    
                    score += 1;
                    
                    if (villager.villagerName == "Scott")
                    {
                        listedName1.text = "- <color=#B1B1B1><s>Scott</s></color>";
                    }

                    if (villager.villagerName == "Tom")
                    {
                        listedName2.text = "- <color=#B1B1B1><s>Tom</s></color>";
                    }
                }
                
                Destroy(villager.gameObject);
                
                yield return new WaitForSeconds(0.5f);
                
                foreach (GameObject villager in villagerList)
                {
                    // yield return new WaitForSeconds(0.2f);
                    villager.transform.position = new Vector2(villager.transform.position.x + 1.5f, villager.transform.position.y);
                }
                
                yield return new WaitForSeconds(2f);
                
                decisionMade = true;
            }
            
            yield return null; 
        }
    }
    
    // gets the index number of a villager's position.
    private int GetNextPosition(int iteration)
    {
        int current = GetVillagerIndex() + iteration;

        if (current >= randomNameList.Count)
        {
            current = 0;
        }
        else if (current < 0)
        {
            current = randomNameList.Count - 1;
        }

        return current;

    }
    
    // gets the index number of a villager.
    private int GetVillagerIndex()
    {
        for (int i = 0; i < randomNameList.Count; i++)
        {
            if (firstInLine.villagerName == randomNameList[i])
            {
                return i;
            }
        }
        // we couldnt find the name in the list
        Debug.Log("Name not found, returning 0");
        return 0;
    }

    private IEnumerator gameEnder()
    {
        if (villagerList.Count > 0)
        {
            Debug.Log("The villagers in line got impatient and left...");
            gameText.text = "The villagers in line got impatient and left...";
            
            yield return new WaitForSeconds(2f);
        }
        Debug.Log("No more villagers remain in the waiting line.");
        gameText.text = "No more villagers remain in the waiting line.";
        
        yield return new WaitForSeconds(.5f);
        
        Debug.Log($"Your score is {score}.");
        gameText.text = "No more villagers remain in the waiting line.\nYour score is " + score + ".";
        gameOver = true;

        // Shuts down timer if game ends early.
        if (!timerEnd)
        {
            timeR = 0f;
        }
    }
}
