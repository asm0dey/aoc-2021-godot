using System.Diagnostics.CodeAnalysis;
using Godot;

namespace Day11
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class Simulation : Button
    {
        public override void _Ready()
        {
        }

        private void _toggle(bool buttonPressed)
        {
            if (buttonPressed)
                GetNode<Timer>("../Timer").Start();
            else
                GetNode<Timer>("../Timer").Stop();
        }
    }
}