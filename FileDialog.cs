using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Day11;
using Godot;
using File = System.IO.File;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class FileDialog : Godot.FileDialog
{
	private void _on_Button_pressed()
	{
		Popup_();
	}


	private void _on_FileDialog_file_selected(string path)
	{
		((Main) GetTree().CurrentScene).FillRects(ParseData(path));
		GetTree().CurrentScene.GetNode<Button>("Panel/Simulate Step").Visible = true;
		GetTree().CurrentScene.GetNode<Button>("Panel/Simulation StartStop").Visible = true;
	}

	private static Dictionary<(int x, int y), int> ParseData(string path)
	{
		var lines = File.ReadAllLines(path);
		var energy = lines
			.SelectMany((line, y) => line.Select((v, x) => (pos: (x, y), v)))
			.ToDictionary(t => t.pos, t => t.v - '0');
		return energy;
	}
}
