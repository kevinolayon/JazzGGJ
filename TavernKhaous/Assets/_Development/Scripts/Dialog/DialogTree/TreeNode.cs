using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TreeNode
{
    public string data;
    public int nodeId;
    public Sprite characterPortrait;
    public bool isLastNode;

    public List<TreeNode> children = new List<TreeNode>();

    public TreeNode AddChild(string value)
    {
        var newChild = new TreeNode();
        newChild.data = value;

        children.Add(newChild);

        return newChild;
    }

    public TreeNode ReturnChild(int id)
    {
        if (children.Count > 0)
        {
            var result = children.Where(node => node.nodeId == id).FirstOrDefault();

            if (result != null)
                return result;
        }

        return null;
    }
}
