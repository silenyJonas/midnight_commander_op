using System;

namespace MidnightCommander.Components
{
    public class Row
    {
        public Node Prefix { get; set; } = new Node();
        public Node Name { get; set; } = new Node();
        public Node FullPath { get; set; } = new Node();
        public Node Size { get; set; } = new Node();
        public Node LastMod { get; set; } = new Node();
        
    }

    public class Node
    {
        public string? Text { get; set; }
        public int? Length { get; set; }
        public int[]? Color { get; set; }
    }
}
