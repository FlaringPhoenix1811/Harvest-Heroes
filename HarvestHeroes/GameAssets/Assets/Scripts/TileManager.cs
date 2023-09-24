using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
    private Dictionary<Vector3Int, int> growthStages = new Dictionary<Vector3Int, int>();

    public int countStage = 1;
    [SerializeField] private Tilemap interactableMap;


    [SerializeField] private Tile hiddenInteractableTile;


    [SerializeField] private Tile ploughedTile;


    [SerializeField] private Tile wateredTile;


    [SerializeField] private Tile stage1Tile;


    [SerializeField] private Tile stage2Tile;


    [SerializeField] private Tile stage3Tile;


    [SerializeField] private Tile stage4Tile;


    [SerializeField] private Tile stage5Tile;


    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if(tile != null && tile.name == "Interactable_Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }


    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsPloughed(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Summer_Plowed")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsWatered(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Watered")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsStage1(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Stage1Wheat")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsStage2(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Stage2Wheat")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsStage3(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Stage3Wheat")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsStage4(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Stage4Wheat")
            {
                return true;
            }
        }


        return false;
    }


    public bool IsStage5(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);


        if(tile != null)
        {
            if(tile.name == "Stage5Wheat")
            {
                return true;
            }
        }


        return false;
    }

    public bool IsStage(int stage, Vector3Int position)
    {
        int currentStage;
        if (growthStages.TryGetValue(position, out currentStage))
        {
            return (currentStage == stage);
        }
        return false;
    }
    public void SetInteractable(Vector3Int position)
    {
        interactableMap.SetTile(position, hiddenInteractableTile);
    }
    public void SetPloughed(Vector3Int position)
    {
        interactableMap.SetTile(position, ploughedTile);
    }
    public void SetWatered(Vector3Int position)
    {
        interactableMap.SetTile(position, wateredTile);
    }
    public void StartGrowing(Vector3Int position)
    {
        int currentStage;
        if (growthStages.TryGetValue(position, out currentStage))
        {
            if (currentStage < 5)
            {
                currentStage++;
                growthStages[position] = currentStage;

                TileBase tile = interactableMap.GetTile(position);
                if (tile != null)
                {
                    switch (currentStage)
                    {
                        case 1:
                            interactableMap.SetTile(position, stage1Tile);
                            break;
                        case 2:
                            interactableMap.SetTile(position, stage2Tile);
                            break;
                        case 3:
                            interactableMap.SetTile(position, stage3Tile);
                            break;
                        case 4:
                            interactableMap.SetTile(position, stage4Tile);
                            break;
                        case 5:
                            interactableMap.SetTile(position, stage5Tile);
                            Debug.Log("Wheat has Grown at position: " + position);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else
        {
            growthStages[position] = 1;
            Debug.Log("Wheat has started growing at position: " + position);
        }
    }

    public void UpdateGrowthStage(Vector3Int position, int stage)
    {
        if(growthStages.ContainsKey(position))
        {
            growthStages[position] = stage;
        }
        else
        {
            growthStages.Add(position, stage);
        }
    }
}



