﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    Level level;
    Vector2Int selected = new Vector2Int(-1,-1);

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        level = (Level)target;
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        {
            Vector2Int tmpSize = EditorGUILayout.Vector2IntField("Width", new Vector2Int(level.board.Width, level.board.Height));
            tmpSize.x = Mathf.Max(1, tmpSize.x);
            tmpSize.y = Mathf.Max(1, tmpSize.y);
            level.board.SetDimensions(tmpSize.x, tmpSize.y);
        }
        EditorGUILayout.EndHorizontal();

        DrawGridView();

        if (level.board.IsWithinWalls(selected)) {
            LaserLabObject obj = level.board.GetLaserLabObject(selected);

            if (obj != null)
            {
                SerializedObject serialObj = new SerializedObject(obj);
                SerializedProperty script = serialObj.FindProperty("m_Script");
                EditorGUILayout.LabelField(script.objectReferenceValue.name);

                SerializedProperty prop = serialObj.GetIterator();
                prop.Next(true);
                for (int i = 0; i < 10; i++)
                    prop.Next(false);

                do
                {
                    EditorGUILayout.PropertyField(prop, true);
                } while (prop.Next(false));

                serialObj.ApplyModifiedProperties();
            } else
                EditorGUILayout.LabelField("Empty");
        }

        EditorGUILayout.EndVertical();
    }

    private void DrawGridView()
    {
        EditorGUILayout.BeginVertical(gridContainerStyle);

        for (int j = level.board.Tiles.GetLength(1); j >= -1; j--)
        {
            EditorGUILayout.BeginHorizontal(gridRowStyle);
            for (int i = -1; i < level.board.Tiles.GetLength(0) + 1; i++)
            {
                Vector2Int pos = new Vector2Int(i, j);

                if (level.board.IsWithinWalls(pos))
                {
                    Color oldCol = GUI.backgroundColor;
                    if (pos == selected)
                        GUI.backgroundColor = Color.grey;

                    if (GUILayout.Button("", gridObjectStyle))
                    {
                        selected = pos;
                    }
                    GUI.backgroundColor = oldCol;
                }
                else if (pos.x == -1 && pos.y == -1)
                {
                    Color oldCol = GUI.backgroundColor;
                    GUI.backgroundColor = new Color(1,.5f,.5f);
                    if (GUILayout.Button("X", gridObjectStyle))
                    {
                        selected = pos;
                    }
                    GUI.backgroundColor = oldCol;
                }
                else
                {
                    GUILayout.Box("", gridObjectStyleEmpty);
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();

    }

    [MenuItem("Assets/Create/Game/Level")]
    public static void Create()
    {
        Level asset = CreateInstance<Level>();

        if (!System.IO.File.Exists(Application.dataPath.Remove(Application.dataPath.LastIndexOf('/') + 1, 6) + AssetDatabase.GetAssetPath(Selection.activeObject) + "/New Level.asset"))
            AssetDatabase.CreateAsset(asset, AssetDatabase.GetAssetPath(Selection.activeObject) + "/New Level.asset");
        else
            asset = CreateNew(1);

        asset.board.fillDefaultWalls();

        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    private static Level CreateNew(int index)
    {
        Level asset = CreateInstance<Level>();

        if (!System.IO.File.Exists(Application.dataPath.Remove(Application.dataPath.LastIndexOf('/') + 1, 6) + AssetDatabase.GetAssetPath(Selection.activeObject) + "/New Level " + index + ".asset"))
        {
            AssetDatabase.CreateAsset(asset, AssetDatabase.GetAssetPath(Selection.activeObject) + "/New Level " + index + ".asset");
        }
        else return CreateNew(index + 1);

        return asset;
    }

    private void OnEnable()
    {
        gridContainerStyle = new GUIStyle()
        {
            padding = new RectOffset(),
            margin = new RectOffset(20, 20, 20, 20)
        };

        gridRowStyle = new GUIStyle()
        {
            margin = new RectOffset(),
            padding = new RectOffset()
        };

        gridObjectStyle = new GUIStyle(EditorStyles.miniButtonMid)
        {
            fixedWidth = 25,
            fixedHeight = 25,
            padding = new RectOffset(),
            margin = new RectOffset(2, 2, 2, 2)
        };

        gridObjectStyleEmpty = new GUIStyle()
        {
            fixedWidth = 25,
            fixedHeight = 25,
            padding = new RectOffset(),
            margin = new RectOffset(2, 2, 2, 2)
        };
    }

    public static GUIStyle gridContainerStyle;

    public static GUIStyle gridRowStyle;

    public static GUIStyle gridObjectStyle;

    public static GUIStyle gridObjectStyleEmpty;

}
