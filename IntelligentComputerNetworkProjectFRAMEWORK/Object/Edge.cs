namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class Edge
    {
        public Edge(int id, int sourceVertex, int targetVertex)
        {
            Id = id;
            SourceVertex = sourceVertex;
            TargetVertex = targetVertex;
        }
        public int Id { get; }
        public int SourceVertex { get; }
        public int TargetVertex { get; }
        public string PrintEdgeInOriginalForm => $"\r\n<{Id}><{SourceVertex}><{TargetVertex}>";
    }
}
