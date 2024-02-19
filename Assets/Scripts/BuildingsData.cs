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

    [SerializeField]
    private float overHeatingPerTick;

    #region BuildingColors
    public Color RessourceBuildingColor{get{return ressourceBuildingColor;}}
    public Color MonumentBuildingColor{get{return monumentBuildingColor;}}
    public Color WarfareBuildingColor{get{return warfareBuildingColor;}}
    #endregion BuildingColors
    public BUILDINGTYPE BuildingType{ get => buildingType; }
    public int Amount{ get => amount; }
    public GameObject ItemPrefab{get => itemPrefab;}
    public int GenTick{get{return genTick;} set{genTick = value;}}
    public int GenTickMax{ get => genTickMax; set { genTickMax = value; } }
    public float OverHeatingPerTick { get => overHeatingPerTick; }


}
