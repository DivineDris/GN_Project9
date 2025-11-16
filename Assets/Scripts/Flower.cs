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
    
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Transform Body;

    [SerializeField]
    private Slime slimePrefab;



    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Body = transform.Find("PlantBody");
    }

    public void SpawnSlime()
    {
        if(gameManager != null)
        {
            Vector3 position = this.transform.position;
            var go = Instantiate(slimePrefab, position, Quaternion.identity);
            var slime = go.GetComponent<Slime>();

            var model = gameManager.GetModel(flowerType,regionType);
            slime.Setup(model.Item1, model.Item2);

        }
    }
    public void OnInteraction(PlayerController interactor)
    {
        if(interactor == null) return;
        if (interactor.heldObject == null) return;
        else if (interactor.heldObject.GetSelectedObjectType() != SelectedObjectType.Fetilaizer) return;
        else
        {
            fertilizerType = ((Fertilizer)interactor.heldObject).fertilizerType;
            Body.localScale = new Vector3(Body.localScale.x, 1.5f, Body.localScale.z);
            Destroy(Body);
            Destroy(interactor.heldObject.gameObject);
            SpawnSlime();
        }
    }
}
