using UnityEngine;

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

public class Flower : MonoBehaviour
{
    public FlowerType flowerType = FlowerType.NotDefined;
    public RegionType regionType = RegionType.NotDefined;
    public FertilizerType fertilizerType = FertilizerType.NotDefined;
}
