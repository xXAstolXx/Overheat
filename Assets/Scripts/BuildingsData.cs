using Sirenix.OdinInspector;
using System;
using UnityEngine;



[CreateAssetMenu(fileName = "BuildingData", menuName = "BuildingObjects/BuildingScriptableObject", order = 1)]
public class BuildingsData : ScriptableObject
{
    private int genTick;

    private int genTickMax;

    [TabGroup("tab2","Color", TextColor = "lightRed")]
    [SerializeField]
    private Color triangleBuildingColor;
    [TabGroup("tab2","Color")]
    [SerializeField]
    private Color squareBuildingColor;
    [TabGroup("tab2","Color")]
    [SerializeField]
    private Color diamondBuildingColor;

    [TabGroup("tab2","Settings", SdfIconType.GearFill, TextColor = "Orange", TabLayouting = TabLayouting.MultiRow)]
    [SerializeField]
    private ResourceType buildingType;
    [TabGroup("tab2", "Settings")]
    [SerializeField]
    private GameObject itemPrefab;
    [TabGroup("tab2", "Settings")]
    [SerializeField, Range(0, 10)]
    private int amountToGenerate;
    [TabGroup("tab2", "Settings")]
    [SerializeField]
    private float overHeatingPerTick;
    [TabGroup("tab2", "Settings")]
    [SerializeField]
    private int ticks;

    #region BuildingColors
    public Color TriangleBuildingColor{get{return triangleBuildingColor;}}
    public Color SquareBuildingColor{get{return squareBuildingColor;}}
    public Color DiamondBuildingColor{get{return diamondBuildingColor;}}
    #endregion BuildingColors
    public ResourceType BuildingType{ get => buildingType; }
    public int AmountToGenerate{ get => amountToGenerate; }
    public GameObject ItemPrefab{get => itemPrefab;}
    public int Ticks { get => ticks; }
    public int GenTick{get{return genTick;} set{genTick = value;}}
    public int GenTickMax{ get => genTickMax; set { genTickMax = value; } }
    public float OverHeatingPerTick { get => overHeatingPerTick; }


}
