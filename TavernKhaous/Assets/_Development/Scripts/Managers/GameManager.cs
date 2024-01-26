using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Tree _tree;
    public SODialog treeDialog;

    [SerializeField]
    private DialogManager _dialogManager;
    public DialogManager DialogManager { get { return _dialogManager; } }

    [SerializeField]
    private UIController _uiController;
    public UIController UIController { get { return _uiController; } }

    public void Start()
    {
        //InitGenericTree();
        Init();

        //PrintTree();
    }

    private void Init()
    {
        DialogManager.Init();
    }

    public void InitGenericTree()
    {
        _tree = new Tree();
        _tree.BuildTree();

        //_tree.PrintTree();
    }

    public void PrintTree()
    {
        Debug.Log("--iniciou--");

        PrintNodeData(treeDialog.root);

        Debug.Log("--finalizou--");
    }

    private void PrintNodeData(TreeNode node)
    {
        Debug.Log(node.data);

        for (int j = 0; j < node.children.Count; j++)
        {
            PrintNodeData(node.children[j]);
        }

        return;
    }
}
