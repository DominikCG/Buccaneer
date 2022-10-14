using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeID
{
    Cannon,
    Life,
    Speed,

}
public class Upgrade : MonoBehaviour
{

    [System.Serializable]
    private class UpgradeData
    {
        public UpgradeID ID;
        public GameObject upgradeObj;
        public int lvl;

        [Range(0f, 1f)]
        public float percent;
    }

    public static Upgrade Instance { get; private set; }

    [SerializeField] private List<UpgradeData> upgradeDataList;

    private void Awake()
    {
        Instance = this;

        foreach(UpgradeData data in upgradeDataList)
        {
            data.upgradeObj = gameObject;
        }
    }

}
