﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class BoardObjectEditor : EditorWindow
{
    BoardObject Target;
    public static void Open(BoardObject target)
    {
        BoardObjectEditor editor = (BoardObjectEditor)GetWindow(typeof(BoardObjectEditor));
        editor.Target = target;
    }

    private void OnGUI()
    {
        
    }

    public static Texture FindPreview(BoardObject obj)
    {
        if (obj == null)
            return null;
        throw new NotImplementedException();
    }
}
