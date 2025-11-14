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
        Plant();
    }
    public void OnInteract(GameObject interactor)
    {

    }
    public void Plant()
    {
        flower.regionType = regionType;
        Instantiate(flower, plantingSpot.position, Quaternion.identity);
    }



}
