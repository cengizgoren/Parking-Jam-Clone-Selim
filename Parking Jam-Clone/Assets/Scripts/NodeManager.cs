using System.Collections.Generic;
using UnityEngine;

public class NodeManager : Singleton<NodeManager>
{
    [SerializeField] private List<Transform> nodes;
    public List<Transform> Nodes { get { return nodes; } set { nodes = value; } }
}
