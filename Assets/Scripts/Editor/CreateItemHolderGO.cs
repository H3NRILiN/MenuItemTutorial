using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreateItemHolderGO
{
    // [MenuItem("GameObject/創建ItemHolder", false, 1)]
    static void CreateGameObject()
    {
        GameObject itemHolderGO = new GameObject("ItemHolder");

        BoxCollider boxCollider = itemHolderGO.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size = Vector3.one * 0.5f;

        GameObject meshPrefab = Resources.Load("Models/blasterC") as GameObject;
        GameObject meshPrefabGO = GameObject.Instantiate(meshPrefab);

        meshPrefabGO.transform.parent = itemHolderGO.transform;
        meshPrefabGO.transform.localPosition = Vector3.zero;

        ItemHolder itemHolder = itemHolderGO.AddComponent<ItemHolder>();
        itemHolder.m_ItemShowcase = meshPrefabGO.transform;
    }
}
