using System;

namespace MapGraphConsole
{
	public class Run
	{
		public static void Main(string[] args)
		{
			var graph = new Graph();
			graph.AddNode(new Node("A", -6, 4));
			graph.AddNode(new Node("B", -3, 3));
			graph.AddNode(new Node("C", -4, -2));
			graph.AddNode(new Node("D", 3, 3));

			graph.OneWayLink(new Link(graph.GetNode("A"), graph.GetNode("B"), 0, 20));

			graph.TwoWayLink(new Link(graph.GetNode("B"), graph.GetNode("C"), 1, 25));
			graph.OneWayLink(new Link(graph.GetNode("B"), graph.GetNode("D"), 1, 35));

			graph.OneWayLink(new Link(graph.GetNode("C"), graph.GetNode("A"), 2, 30));
			graph.OneWayLink(new Link(graph.GetNode("C"), graph.GetNode("D"), 2, 50));

			const string start = "A";
			const string end = "D";
			SearchCheapestRoute.FindRoute(graph, start, end);
			Console.WriteLine();
			SearchShortestRoute.FindRoute(graph, start, end);
			Console.WriteLine();
			SearchByCoordinates.FindRoute(graph, start, end);
			Console.ReadLine();
		}
	}
}
