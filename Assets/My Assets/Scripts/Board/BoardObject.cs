﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardObject : MonoBehaviour, ILaserTarget
{
    public bool placed;
    public int Rotation { get; protected set; }
    public abstract Laser[] OnLaserHit(Laser laser);

    protected Vector2Int getBoardPosition()
    {
        return Level.current.convertCoordinates(transform);
    }

    void Update()
    {
        
        update();
    }

    protected virtual void update() { }
}
