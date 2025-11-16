using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Mesh[] meshes;
    [SerializeField]
    private Material[] materialsPink;
    [SerializeField]
    private Material[] materialsSky;
    [SerializeField]
    private Material[] materialsGreen;


    public (Mesh, Material) GetModel(FlowerType flowerType,RegionType regionType)
    {
        Mesh mesh;
        Material[] materialPool ;
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
}
