using System.Collections.Generic;

namespace MapGraphConsole
{
	public class Node
	{
		public string Name;
		public int X;
		public int Y;
		public bool Expanded;
		public Node ParentNode;
		public double Distance;
		public double? Price;
		public List<Node> NodesList = new List<Node>();
		public List<Link> LinksList = new List<Link>();

		public Node(string name)
		{
			Name = name;
		}

		public Node(string name, int x, int y)
		{
			Name = name;
			X = x;
			Y = y;
		}

		public void ResetNode()
		{
			Expanded = false;
			ParentNode = null;
			Price = 0.0;
			Distance = 0.0;
		}
	}
}
