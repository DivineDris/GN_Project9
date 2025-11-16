using UnityEngine;

public class PlantingSite : MonoBehaviour, IInteractable
{
    [SerializeField]
    private RegionType regionType;
    [SerializeField]
    private Transform plantingSpot;
    [SerializeField]
    private Flower flower;
    void Start()
    {
        plantingSpot = transform.Find("PlantingSpot");
    }
    public void Plant(FlowerType flowerType)
    {
        flower.regionType = regionType;
        flower.flowerType = flowerType;
        Instantiate(flower, plantingSpot.position, Quaternion.identity);
    }

    public void OnInteraction(PlayerController interactor)
    {
        if (interactor == null) return;
        if(interactor.heldObject == null) return;
        else if(interactor.heldObject.GetSelectedObjectType() != SelectedObjectType.SeedPack) return;
        else
        {
            Plant(((SeedPack)interactor.heldObject).flowerType);
            Destroy(interactor.heldObject.gameObject);
        }

    }
}
