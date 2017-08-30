﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public Grid[,] grids = new Grid[10, 10];
    
    // Get grids adjacent to a given grid
    public Grid[] GetAdjacent(int x, int y)
    {
        Grid[] adjacents = new Grid[4];

        if (y < 9)
        {
            adjacents[0] = grids[x, y + 1];
        }
        else
        {
            adjacents[0] = null;
        }

        if (x < 9)
        {
            adjacents[1] = grids[x + 1, y];
        }
        else
        {
            adjacents[1] = null;
        }

        if (y > 0)
        {
            adjacents[2] = grids[x, y - 1];
        }
        else
        {
            adjacents[2] = null;
        }

        if (x > 0)
        {
            adjacents[3] = grids[x - 1, y];
        }
        else
        {
            adjacents[3] = null;
        }

        return adjacents;
    }
}
