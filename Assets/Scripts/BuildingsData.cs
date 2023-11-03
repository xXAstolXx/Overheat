using System;
using System.Runtime;
using UnityEngine;
using UnityEngine.TextCore.Text;



[CreateAssetMenu(fileName = "BuildingData", menuName = "BuildingObjects/BuildingScriptableObject", order = 1)]
public class BuildingsData : ScriptableObject
{
    private int genTick;

    private int genTickMax;

    [SerializeField]
    private string objectName;

    [SerializeField]
    private Color ressourceBuildingColor;
    [SerializeField]
    private Color monumentBuildingColor;
    [SerializeField]
    private Color warfareBuildingColor;

    [SerializeField]
    private GameObject itemPrefab;
    
    [SerializeField]
    private BUILDINGTYPE buildingType;

    [SerializeField,Range(0,10)]
    private int amount;


    public string ObjectName{get{return objectName;}}
    #region BuildingColors
    public Color RessourceBuildingColor{get{return ressourceBuildingColor;}}
    public Color MonumentBuildingColor{get{return monumentBuildingColor;}}
    public Color WarfareBuildingColor{get{return warfareBuildingColor;}}
    #endregion BuildingColors
    public BUILDINGTYPE BuildingType{get{return buildingType;}}
    public int Amount{get{return amount;}}
    public GameObject ItemPrefab{get{return itemPrefab;}}
    public int GenTick{get{return genTick;} set{genTick = value;}}
    public int GenTickMax{get{return genTickMax;} set {genTickMax = value;}}


}
