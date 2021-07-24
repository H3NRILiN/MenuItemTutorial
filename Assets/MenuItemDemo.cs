using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItemDemo
{

    [MenuItem("GameObject/我的Hierarchy選項", false, 0)]
    static void MenuItemInHeirarchy()
    {

    }


    [MenuItem("CONTEXT/Rigidbody/我在RigidBody的選項")]
    static void MenuItemInRigidbody()
    {

    }


    [MenuItem("CONTEXT/BoxCollider/我在BoxColider的選項")]
    static void MenuItemInBoxColider()
    {

    }


    [MenuItem("Assets/我在Project視窗的選項")]
    static void MenuItemInAssets()
    {

    }


    [MenuItem("我的Menu/我的工具列選項")]
    static void MenuItemInToolbar()
    {

    }
}
