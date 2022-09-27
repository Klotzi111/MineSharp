﻿using MineSharp.Core.Types;
using Priority_Queue;

namespace MineSharp.Pathfinding.Algorithm
{
    public class Node : FastPriorityQueueNode
    {
        public Vector3 Position { get; set; }
        public bool Walkable { get; set; }

        public double gCost { get; set; }
        public double hCost { get; set; }
        public double fCost => gCost + hCost;


        public Node? Parent;

        public Node(Vector3 position, bool walkable, int gCost, int hCost)
        {
            Position = position;
            Walkable = walkable;
            this.gCost = gCost;
            this.hCost = hCost;
        }

        public override string ToString()
        {
            return $"Node (Pos={Position} Walkable={Walkable} gCost={gCost} hCost={hCost} fCost={fCost})";
        }
    }
}