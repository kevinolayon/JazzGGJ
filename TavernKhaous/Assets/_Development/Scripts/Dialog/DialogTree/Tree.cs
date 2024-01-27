using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    private GenericTreeNode<string> _treeRoot;

    public void BuildTree()
    {
        _treeRoot = new GenericTreeNode<string>("Bem-vindo ao Reino Mágico!");
        {
            GenericTreeNode<string> Option1 = _treeRoot.AddChild(" [Opção 1] Como posso chegar à Cidade dos Magos?");
            {
                GenericTreeNode<string> Option11 = Option1.AddChild("Answer: Você pode chegar à Cidade dos Magos atravessando a Floresta Encantada.");
                {
                    GenericTreeNode<string> Option111 = Option11.AddChild("[Opcao 1.1.1] Pode me dar um mapa?");
                    GenericTreeNode<string> Option112 = Option11.AddChild("[Opcao 1.1.2] Como está a segurança na floresta?");
                }
            }
            GenericTreeNode<string> Option2 = _treeRoot.AddChild("[Opção 2] O que você vende aqui?");
        }
    }

    public void PrintTree()
    {
        Debug.Log("--iniciou--");
    
        PrintNodeData(_treeRoot);
       
        Debug.Log("--finalizou--");
    }

    private void PrintNodeData <T> (GenericTreeNode<T> node)
    {
        Debug.Log(node.data);

        for (int j = 0; j < node.children.Count; j++)
        {
            PrintNodeData(node.children[j]);
        }

        return;
    }
}
