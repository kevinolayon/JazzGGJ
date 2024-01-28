using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTree : MonoBehaviour
{
    private Tree _tree;
    public SODialog treeDialog;

    public void InitGenericTree()
    {
        _tree = new Tree();
        _tree.BuildTree();

        PrintNodes();
    }

    public void PrintNodes()
    {
        Debug.Log("--iniciou--");

        PrintNodeData(treeDialog.root);

        Debug.Log("--finalizou--");
    }

    private void PrintNodeData(TreeNode node)
    {
        Debug.Log(node.dialogData.data);

        for (int j = 0; j < node.children.Count; j++)
        {
            PrintNodeData(node.children[j]);
        }

        return;
    }
}
