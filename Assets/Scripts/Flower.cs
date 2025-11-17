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

    public Mesh[] meshes;
    public Material[] materialsPink;
    public Material[] materialsSky;
    public Material[] materialsGreen;

    [SerializeField]
    private GameObject Body;

    [SerializeField]
    private Slime slimePrefab;



    private void Start()
    {
        Body = transform.Find("PlantBody").gameObject;
    }
    public (Mesh, Material) GetModel(FlowerType flowerType, RegionType regionType)
    {
        Mesh mesh;
        Material[] materialPool;
        switch (flowerType)
        {
            case FlowerType.Tulip:
                mesh = meshes[0];
                materialPool = materialsPink;
                break;
            case FlowerType.Echivel:
                mesh = meshes[1];
                materialPool = materialsSky;
                break;
            case FlowerType.LightFlower:
                mesh = meshes[2];
                materialPool = materialsGreen;
                break;
            default:
                mesh = meshes[0];
                materialPool = materialsPink;
                break;
        }

        switch (regionType)
        {
            case RegionType.LushGreenPlain:
                return (mesh, materialPool[0]);
            case RegionType.Іcy:
                return (mesh, materialPool[1]);
            case RegionType.Desert:
                return (mesh, materialPool[2]);
            default:
                return (mesh, materialPool[0]);
        }
    }
    public void SpawnSlime()
    {
            Vector3 position = this.transform.position;
            var go = Instantiate(slimePrefab, position, Quaternion.identity);
            var slime = go.GetComponent<Slime>();

            var model = GetModel(flowerType,regionType);
            slime.Setup(model.Item1, model.Item2);

        Debug.Log("Slime prefab at runtime = " + slimePrefab);
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
