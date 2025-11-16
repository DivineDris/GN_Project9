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
    private GameObject Body;

    [SerializeField]
    private Slime slimePrefab;



    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Body = transform.Find("PlantBody").gameObject;
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
            Body.transform.localScale = new Vector3(Body.transform.localScale.x, 1.5f, Body.transform.localScale.z);
            Destroy(interactor.heldObject.gameObject);
            SpawnSlime();
            Destroy(Body);
        }
    }
}
