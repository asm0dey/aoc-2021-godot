using Godot;

public class Octo : ColorRect
{
	public void SetColor(int i)
	{
		if (i > 9)
		{
			i = 10;
		}

		switch (i)
		{
			case 0:
				Color = Color.Color8(37, 57, 151);
				break;
			case 1:
				Color = Color.Color8(34, 94, 168);
				break;
			case 2:
				Color = Color.Color8(32, 115, 178);
				break;
			case 3:
				Color = Color.Color8(37, 154, 193);
				break;
			case 4:
				Color = Color.Color8(64, 181, 196);
				break;
			case 5:
				Color = Color.Color8(124, 204, 187);
				break;
			case 6:
				Color = Color.Color8(165, 220, 183);
				break;
			case 7:
				Color = Color.Color8(201, 234, 180);
				break;
			case 8:
				Color = Color.Color8(220, 241, 178);
				break;
			case 9:
				Color = Color.Color8(237, 248, 177);
				break;
			case 10:
				Color = Colors.White;
				break;
		}
	}
}
