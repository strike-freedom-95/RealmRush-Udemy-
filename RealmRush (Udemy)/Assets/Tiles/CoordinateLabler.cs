using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

[ExecuteAlways] // This Flag executes the script even if the play mode is not active
public class CoordinateLabler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void UpdateObjectName() // updates the name of each unit cube as per the coordinate
    {
        transform.parent.name = coordinates.ToString();
    }

    void DisplayCoordinates() // Sets the label text as the current coordinate
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 
            UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 
            UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + ", " + coordinates.y;
    }
}
