using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTreeNode<T>
{
    public T data;
    public List<GenericTreeNode<T>> children;

    public GenericTreeNode(T value)
    {
        this.data = value;
        this.children = new List<GenericTreeNode<T>>();
    }
        
    public GenericTreeNode<T> AddChild(T value)
    {
        var newChild = new GenericTreeNode<T>(value);
        children.Add(newChild);

        return newChild;
    }
}
