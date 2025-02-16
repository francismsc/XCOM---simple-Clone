using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScripting : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToEnable1;
    [SerializeField] private List<GameObject> objectsToDisable1;
    [SerializeField] private List<GameObject> objectsToEnableDoor;
    [SerializeField] private List<GameObject> objectsToDisableDoor;
    [SerializeField] private List<GameObject> objectsToEnableDoor2;
    [SerializeField] private List<GameObject> objectsToDisableDoor2;
    [SerializeField] private List<GameObject> objectsToEnableDoor3;
    [SerializeField] private List<GameObject> objectsToDisableDoor3;
    [SerializeField] private Door door1;
    [SerializeField] private Door door2;
    [SerializeField] private Door door3;


    private void Start()
    {
        LevelGrid.Instance.OnAnyUnitMovedGridPosition += LevelGrid_CheckPointHideObject;
    }

    private void Update()
    {
        
    }

    private void LevelGrid_CheckPointHideObject(object sender, LevelGrid.OnAnyUnitMovedGridPositionEventArgs e)
    {
        if(e.toGridPosition.z == 5)
        {
            DisableGameObjects(objectsToDisable1);
            EnableGameObjects(objectsToEnable1);
        }

        door1.OnDoorOpened += (object sender, EventArgs e) =>
        {
            EnableGameObjects(objectsToEnableDoor);
            DisableGameObjects(objectsToDisableDoor);
        };

        door2.OnDoorOpened += (object sender, EventArgs e) =>
        {
            EnableGameObjects(objectsToEnableDoor2);
            DisableGameObjects(objectsToDisableDoor2);
        };

        door3.OnDoorOpened += (object sender, EventArgs e) =>
        {
            EnableGameObjects(objectsToEnableDoor3);
            DisableGameObjects(objectsToDisableDoor3);
        };
    }

    private void EnableGameObjects(List<GameObject> gameObjectList)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(true);
            }
        }
    }

    private void DisableGameObjects(List<GameObject> gameObjectList)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
