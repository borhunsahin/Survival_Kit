using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildObject", menuName = "Scriptable/BuildObject")]
public class BuildSO : ScriptableObject
{
    [Header("BuildObjectInfo")]
    [SerializeField] protected new string name;
    [SerializeField] protected string description;
    [SerializeField] public GameObject itemPrefab;

    [Header("BuildObject Needed For Item")]

    public int stoneCount;
    public int stickCount;
    public int woodCount;
    public int timberCount;
    public int beamCount;

}
