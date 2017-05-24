using System;
using System.Collections.Generic;

namespace MapGraphConsole
{
	public class Graph
	{
		public Dictionary<string, Node> Map = new Dictionary<string, Node>();

		public void AddNode(Node node)
		{
			Map.Add(node.Name, node);
		}

		public Link OneWayLink(Link link)
		{
			if (Map.ContainsKey(link.StartNode.Name) && Map.ContainsKey(link.EndNode.Name))
			{
				Map[link.StartNode.Name].LinksList.Add(link);
				Map[link.StartNode.Name].NodesList.Add(Map[link.EndNode.Name]);
				return new Link(link.StartNode, link.EndNode, link.LinkType, link.Distance);
			}
			Console.WriteLine("Missing nodes");
			return null;
		}

		public List<Link> TwoWayLink(Link link)
		{
			var linkList = new List<Link>();
			if (Map.ContainsKey(link.StartNode.Name) && Map.ContainsKey(link.EndNode.Name))
			{
				Map[link.StartNode.Name].LinksList.Add(link);
				Map[link.EndNode.Name].LinksList.Add(new Link(link.EndNode, link.StartNode, link.LinkType, link.Distance));
				Map[link.StartNode.Name].NodesList.Add(Map[link.EndNode.Name]);
				Map[link.EndNode.Name].NodesList.Add(Map[link.StartNode.Name]);
				linkList.Add(link);
				linkList.Add(new Link(link.EndNode, link.StartNode, link.LinkType, link.Distance));
				return linkList;
			}
			Console.WriteLine("Missing nodes");
			return null;
		}

		public void ResetAll()
		{
			foreach (var node in Map.Values)
			{
				node.ResetNode();
			}
		}

		public bool ContainsNode(string name)
		{
			return Map.ContainsKey(name);
		}

		public Node GetNode(string name)
		{
			return Map[name];
		}
	}
}
