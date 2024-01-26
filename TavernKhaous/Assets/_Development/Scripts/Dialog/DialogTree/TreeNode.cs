using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T>
{
    public T data;
    public List<TreeNode<T>> _children;

    public TreeNode(T value)
    {
        this.data = value;
        this._children = new List<TreeNode<T>>();
    }
        
    public TreeNode<T> AddChild(T value)
    {
        var newChild = new TreeNode<T>(value);
        _children.Add(newChild);

        return newChild;
    }
}
