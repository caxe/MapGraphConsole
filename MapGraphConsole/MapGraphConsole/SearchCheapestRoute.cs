using System;
using System.Collections.Generic;
using System.Linq;

namespace MapGraphConsole
{
	public static class SearchCheapestRoute
	{
		public static void FindRoute(Graph graph, string start, string end)
		{
			Console.WriteLine("Cheapest route from:" + start + " to:" + end);
			if (!graph.ContainsNode(start) || !graph.ContainsNode(end))
			{
				Console.WriteLine("Missing nodes");
				return;
			}

			graph.ResetAll();

			var queueNodes = new List<Node> {graph.GetNode(start)};

			while (queueNodes.Any())
			{
				var tempNode = queueNodes[0];
				queueNodes.RemoveAt(0);

				if (start.Equals(end))
				{
					Console.WriteLine("Start is end");
					return;
				}

				if (tempNode.Expanded) continue;
				tempNode.Expanded = true;

				foreach (var linkedNodes in tempNode.LinksList)
				{
					var relatedNode = linkedNodes.EndNode;
					Util.SetParentPrice(tempNode, linkedNodes);
					Console.WriteLine("From:" + tempNode.Name + " To:" + relatedNode.Name + " Distance:" + tempNode.LinksList.Find(link => link.EndNode.Equals(relatedNode)).Distance + "km" + " Cost:" + Util.LinkPrice(tempNode.LinksList.Find(link => link.EndNode.Equals(relatedNode))) + "$");
					queueNodes.Insert(0, relatedNode);
				}
			}

			if (graph.GetNode(end).ParentNode != null)
			{
				Console.WriteLine("Total distance:" + graph.GetNode(end).Distance + "km Total cost:" + graph.GetNode(end).Price + "$");
				var startNode = graph.GetNode(start);
				var endNode = graph.GetNode(end);
				Util.PrintRoute(startNode, endNode);
			} else { Console.WriteLine("Missing nodes"); }
		}
	}
}
