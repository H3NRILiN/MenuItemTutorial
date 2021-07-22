using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreateItemHolderByPrefab : MonoBehaviour
{
    [MenuItem("Assets/創建ItemHolder", false, 99999)]
    static void CreateItemHolderFromPrefab()
    {
        CreateItemHolderObject(AssetDatabase.GetAssetPath(Selection.activeGameObject));
    }

    [MenuItem("Assets/創建ItemHolder", true, 99999)]
    static bool CreateItemHolderFromPrefabValid()
    {
        return PrefabUtility.IsPartOfPrefabAsset(Selection.activeObject);
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
        GameObject meshPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        GameObject meshPrefabGO = Instantiate(meshPrefab);

        // Object meshPrefab = Resources.Load("Modelss/blasterC");
        // GameObject meshPrefabGO = PrefabUtility.InstantiatePrefab(meshPrefab) as GameObject;

        meshPrefabGO.transform.parent = itemHolderGO.transform;
        meshPrefabGO.transform.localPosition = Vector3.zero;

        //新增自訂腳本
        ItemHolder itemHolder = itemHolderGO.AddComponent<ItemHolder>();
        itemHolder.m_ItemShowcase = meshPrefabGO.transform;

        Undo.RegisterCreatedObjectUndo(itemHolderGO, $"創建{itemHolderGO.name}");
        Selection.activeGameObject = itemHolderGO;
        EditorGUIUtility.PingObject(itemHolderGO);

    }
}
