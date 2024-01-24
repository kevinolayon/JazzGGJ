using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Tree _tree;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        _tree = new Tree();
        _tree.BuildTree();

        _tree.PrintTree();
    }
}
