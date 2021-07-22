using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateItemHolder : MonoBehaviour
{
    [MenuItem("GameObject/創建ItemHolder/blasterC", false, -1)]
    static void CreateItemHolderMenuC()
    {
        CreateItemHolderObject("Models/blasterC");
    }

    [MenuItem("GameObject/創建ItemHolder/blasterB", false, -1)]
    static void CreateItemHolderMenuB()
    {
        CreateItemHolderObject("Models/blasterB");
    }

    [MenuItem("GameObject/創建ItemHolder/blasterD", false, -1)]
    static void CreateItemHolderMenuD()
    {
        CreateItemHolderObject("Models/blasterD");
    }

    [MenuItem("GameObject/創建ItemHolder/blasterA", false, -1)]
    static void CreateItemHolderMenuA()
    {
        CreateItemHolderObject("Models/blasterA");
    }

    static void CreateItemHolderObject(string path)
    {
        //創造GameObject
        string name = GameObjectUtility.GetUniqueNameForSibling(null, "ItemHolder");
        GameObject itemHolderGO = new GameObject(name);

        //增加BoxColider
        BoxCollider boxCollider = itemHolderGO.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size = Vector3.one * 0.5f;

        //增加模型
        GameObject meshPrefab = Resources.Load(path) as GameObject;
        GameObject meshPrefabGO = Instantiate(meshPrefab);

        // Object meshPrefab = Resources.Load("Modelss/blasterC");
        // GameObject meshPrefabGO = PrefabUtility.InstantiatePrefab(meshPrefab) as GameObject;

        meshPrefabGO.transform.parent = itemHolderGO.transform;
        meshPrefabGO.transform.localPosition = Vector3.zero;

        //新增自訂腳本
        ItemHolder itemHolder = itemHolderGO.AddComponent<ItemHolder>();
        itemHolder.m_ItemShowcase = meshPrefabGO.transform;

        //  Undo.RegisterCreatedObjectUndo(itemHolderGO, $"創建{itemHolderGO.name}");
        Selection.activeGameObject = itemHolderGO;
        EditorGUIUtility.PingObject(itemHolderGO);

    }
}
