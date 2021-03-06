﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TutorialMessage
{
    public string Title;
    [TextArea(3, 10)]
    public string Message;
    public AnimatedSprite image;
}
