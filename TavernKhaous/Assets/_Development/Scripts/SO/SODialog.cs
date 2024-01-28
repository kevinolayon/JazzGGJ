using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue")]
public class SODialog : ScriptableObject
{
    public string name;
    public TreeNode root;
}
