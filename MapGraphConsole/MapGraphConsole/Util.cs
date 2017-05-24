using System;
using System.Collections.Generic;

namespace MapGraphConsole
{
	public static class Util
	{
		public static double? LinkPrice(Link link)
		{
			switch (link.LinkType)
			{
				case 2:
					return 0;
				case 1:
					if (link.Distance <= 5) { return 0; } else
					{
						var linkTypeOneCount = (int)Math.Round((link.Distance - 5) / 10);
						return linkTypeOneCount * 2;
					}
				case 0:
					if (link.Distance <= 10) { return 3; } else
					{
						var linkTypeTwoCount = (int)Math.Round(link.Distance - 10);
						return linkTypeTwoCount * 0.5 + 3;
					}
				default: return null;
			}
		}

		public static void SetParentDistance(Node parentNode, Link link)
		{
			var newDistance = parentNode.Distance + link.Distance;
			var newPrice = parentNode.Price + LinkPrice(link);
			var relatedNode = link.EndNode;
			if (relatedNode.ParentNode != null && relatedNode.Distance < newDistance) return;
			relatedNode.ParentNode = parentNode;
			relatedNode.Distance = newDistance;
			relatedNode.Price = newPrice;
		}

		public static void PrintRoute(Node startNode, Node endNode)
		{
			while (true)
			{
				if (startNode.Name.Equals(endNode.Name))
				{
					Console.WriteLine(endNode.Name); 
					break;
				}
				Console.Write(endNode.Name + "<-");
				endNode = endNode.ParentNode;
			}
		}

		public static void SetParentPrice(Node parentNode, Link link)
		{
			var newDistance = parentNode.Distance + link.Distance;
			var newPrice = parentNode.Price + LinkPrice(link);
			var relatedNode = link.EndNode;
			if (relatedNode.ParentNode != null && relatedNode.Price < newPrice) return;
			{
				relatedNode.ParentNode = parentNode;
				relatedNode.Distance = newDistance;
				relatedNode.Price = newPrice;
			}
		}

		public static double CalcDistance(Node startNode, Node endNode)
		{
			return Math.Sqrt(Math.Pow(startNode.X - endNode.X, 2) + Math.Pow(startNode.Y - endNode.Y, 2));
		}

		public static void SortByDistance(Node startNode, Node endNode, List<Node> list)
		{
			var distance = CalcDistance(startNode, endNode);

			for (var i = 0; i < list.Count; i++)
			{
				if (distance > CalcDistance(endNode, list[i])) continue;
				list.Insert(i, startNode);
				break;
			}

			if (!list.Contains(startNode))
			{
				list.Add(startNode);
			}
		}
	}
}
