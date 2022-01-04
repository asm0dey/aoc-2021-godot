using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Godot;

namespace Day11
{
    public class Main : Node2D
    {
        private readonly Octo[][] _octos = new Octo[10][];
        private Solution _solution;
        [Export] public PackedScene Octo;

        public void FillRects(Dictionary<(int x, int y), int> energy)
        {
            ClearGrid();
            _solution = new Solution(energy);
            foreach (var i in Enumerable.Range(0, 10))
            {
                _octos[i] = new Octo[10];

                foreach (var j in Enumerable.Range(0, 10))
                {
                    var octo = ((Main) GetTree().CurrentScene).Octo.Instance<Octo>();
                    _octos[i][j] = octo;
                    GetTree().CurrentScene.GetNode("Panel/Grid").AddChild(octo);
                    octo.SetColor(energy[(i, j)]);
                }
            }
        }

        private void ClearGrid()
        {
            foreach (var line in _octos)
                if (line != null)
                    foreach (var node in line)
                        if (node != null)
                        {
                            GetTree().CurrentScene.GetNode("Panel/Grid").RemoveChild(node);
                            node.QueueFree();
                        }
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void _Step()
        {
            _solution.Step((position, color) => _octos[position.y][position.x].SetColor(color));
        }
    }
}