using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Solution
    {
        private readonly Dictionary<(int x, int y), int> _energy;

        public Solution(Dictionary<(int x, int y), int> energy)
        {
            _energy = energy;
        }

        public delegate void PositionColorCallback((int x, int y) position, int color);

        public int Step(PositionColorCallback func)
        {
            foreach (var pos in _energy.Keys.ToList())
            {
                _energy[pos]++;
                func(pos, _energy[pos]);
            }

            return _energy.Keys.ToList().Sum(pos => Flash(_energy, pos, func));
        }

        private int Flash(IDictionary<(int x, int y), int> energy, (int x, int y) pos,
            PositionColorCallback func)
        {
            if (energy[pos] <= 9) return 0;
            energy[pos] = 0;
            func(pos, energy[pos]);

            var count = 1;
            var (x, y) = pos;
            for (var nx = x - 1; nx <= x + 1; nx++)
            for (var ny = y - 1; ny <= y + 1; ny++)
            {
                var next = (nx, ny);
                if (next == pos || !energy.TryGetValue(next, out var value) || value == 0) continue;
                energy[next]++;
                func((next.nx, next.ny), energy[next]);
                count += Flash(energy, next, func);
            }

            return count;
        }
    }
}