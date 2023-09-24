using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Dictionary<Vector3Int, int> tileStates = new Dictionary<Vector3Int, int>(); // Dictionary to store tile states
    private Dictionary<Vector3Int, Coroutine> growthCoroutines = new Dictionary<Vector3Int, Coroutine>(); // Dictionary to store growth Coroutines for each tile position
    public Inventory inventory;


    public GameObject Collectable;
    private void Awake()
    {
        inventory = new Inventory(21);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            double horizontal = transform.position.x - 0.4;
            double vertical = transform.position.y - 1.1;
            Vector3Int position = new Vector3Int((int)horizontal, (int)vertical, 0);


            int currentState;
            if (!tileStates.TryGetValue(position, out currentState))
            {
                currentState = 0;
            }


            // Handle different states based on tile state
            switch (currentState)
            {
                case 0: // Tile is unploughed and unwatered
                    if (GameManager.instance.tileManager.IsInteractable(position))
                    {
                        Debug.Log("Tile is Ploughed");
                        GameManager.instance.tileManager.SetPloughed(position);
                        tileStates[position] = 1; // Set the state to ploughed
                    }
                    else
                    {
                        Debug.Log("Tile is not interactable.");
                    }
                    break;
                case 1: // Tile is ploughed but unwatered
                    if (GameManager.instance.tileManager.IsPloughed(position))
                    {
                        Debug.Log("Tile is Watered");
                        GameManager.instance.tileManager.SetWatered(position);
                        tileStates[position] = 2; // Set the state to watered
                        Debug.Log(tileStates[position]);
                        StartGrowth(position); // Start growing
                    }
                    else
                    {
                        Debug.Log("Tile needs to be watered first.");
                    }
                    break;
                case 2:
                    if(GameManager.instance.tileManager.IsStage(5, position))
                    {
                        GameManager.instance.tileManager.UpdateGrowthStage(position, 0);
                        HarvestWheat(position);
                        tileStates[position] = 0;
                    }
                    else
                    {
                        Debug.Log("Crop is not fully grown yet.Tile State: "+ tileStates[position]);
                    }
                    break;
                default:
                    Debug.Log("Seed is already Watered, Patience is the Key");
                    break;
            }
        }
    }


    // Coroutine for growing a crop at a specific position
    private void StartGrowth(Vector3Int position)
    {
        if (growthCoroutines.ContainsKey(position))
        {
            return; // If a growth Coroutine is already active for this position, exit
        }


        Coroutine growthCoroutine = StartCoroutine(GrowCrop(position));
        growthCoroutines[position] = growthCoroutine;
    }


    private IEnumerator GrowCrop(Vector3Int position)
    {
        while (!GameManager.instance.tileManager.IsStage(5, position))
        {
            yield return new WaitForSeconds(2f); // Wait for the specified timer duration
            Debug.Log("Stage Check");

            GameManager.instance.tileManager.StartGrowing(position);
        }


        Debug.Log("Harvesting crop at position: " + position);


        tileStates[position] = 2;


        // Remove the Coroutine from the dictionary when the crop is fully grown
        growthCoroutines.Remove(position);
    }


    private void HarvestWheat(Vector3Int position)
    {
        // Check if the tile is ready to harvest
        if (tileStates.ContainsKey(position) && tileStates[position] == 2)
        {
            Debug.Log("Harvesting crop at position: " + position);


            // Reset the tile to be interactable
            GameManager.instance.tileManager.SetInteractable(position);


            // Instantiate wheat as a collectible
            Instantiate(Collectable, position + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);


            // Reset the tile state to unploughed
            tileStates[position] = 0;
        }
        else
        {
            Debug.Log("Crop is not ready to harvest.");
        }
    }


    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;




        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;




        Item dropppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);




        dropppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    
    }
}
