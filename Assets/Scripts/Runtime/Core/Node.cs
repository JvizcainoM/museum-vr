using System;
using System.Collections.Generic;

public abstract class Node
{
    protected Node(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
    public string Name { get; set; } = "Node";
    public List<Port> Inputs { get; } = new();
    public List<Port> Outputs { get; } = new();


    public abstract void Execute();
}