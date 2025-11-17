using UnityEngine;
using UnityEngine.XR;

public enum FlowerType
{
    NotDefined,
    Echivel,
    LightFlower,
    Tulip
}
public enum RegionType
{
    NotDefined,
    Іcy,
    Desert,
    LushGreenPlain
}
public enum FertilizerType
{
    NotDefined,
    FertilizerA,
    FertilizerB,
    FertilizerC
}

public class Flower : MonoBehaviour, IInteractable
{
    public FlowerType flowerType = FlowerType.NotDefined;
    public RegionType regionType = RegionType.NotDefined;
    public FertilizerType fertilizerType = FertilizerType.NotDefined;

    public Slime[] pinkSlimes;
    public Slime[] skySlimes;
    public Slime[] greenSlimes;

    [SerializeField]
    private GameObject Body;




    private void Start()
    {
        Body = transform.Find("PlantBody").gameObject;
    }
    public Slime GetModel(FlowerType flowerType, RegionType regionType)
    {
        Slime[] slimePool;
        switch (flowerType)
        {
            case FlowerType.Tulip:
                slimePool = pinkSlimes;
                break;
            case FlowerType.Echivel:
                slimePool = skySlimes;
                break;
            case FlowerType.LightFlower:
                slimePool = greenSlimes;
                break;
            default:
                slimePool = pinkSlimes;
                break;
        }

        switch (regionType)
        {
            case RegionType.LushGreenPlain:
                return slimePool[0];
            case RegionType.Іcy:
                return slimePool[1];
            case RegionType.Desert:
                return slimePool[2];
            default:
                return slimePool[0];
        }
    }
    public void SpawnSlime()
    {
            Vector3 position = this.transform.position;
            var go = Instantiate(GetModel(flowerType, regionType), position, Quaternion.identity);

    }
    public void OnInteraction(PlayerController interactor)
    {
        if(interactor == null) return;
        if (interactor.heldObject == null) return;
        else if (interactor.heldObject.GetSelectedObjectType() != SelectedObjectType.Fetilaizer) return;
        else
        {
            fertilizerType = ((Fertilizer)interactor.heldObject).fertilizerType;
            Body.transform.localScale = new Vector3(Body.transform.localScale.x, 1.5f, Body.transform.localScale.z);
            Destroy(interactor.heldObject.gameObject);
            SpawnSlime();
            Destroy(Body);
        }
    }
}
