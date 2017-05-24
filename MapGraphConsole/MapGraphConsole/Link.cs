namespace MapGraphConsole
{
	public class Link
	{
		public Node StartNode;
		public Node EndNode;
		public int LinkType;
		public double Distance;

		public Link(Node startNode, Node endNode, int linkType)
		{
			StartNode = startNode;
			EndNode = endNode;
			LinkType = linkType;
			
		}

		public Link(Node startNode, Node endNode, int linkType, double distance)
		{
			StartNode = startNode;
			EndNode = endNode;
			LinkType = linkType;
			Distance = distance;
		}
	}
}
