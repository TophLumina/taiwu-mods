using System;

namespace GameData.Utilities;

public static class ByteCoordinateHelper
{
	public static sbyte GetDirectionRelatedTo(this ByteCoordinate self, ByteCoordinate other)
	{
		int deltaX = self.X - other.X;
		int deltaY = self.Y - other.Y;
		if (deltaX == 0 && deltaY == 0)
		{
			return 8;
		}
		float result = MathF.Atan2(deltaY, deltaX);
		if (result < 0f)
		{
			result += (float)Math.PI * 2f;
		}
		result += (float)Math.PI / 8f;
		if (result >= (float)Math.PI * 2f)
		{
			result -= (float)Math.PI * 2f;
		}
		sbyte direction = (sbyte)MathF.Floor(result / ((float)Math.PI / 4f));
		Tester.Assert(direction >= 0 && direction < 8);
		direction--;
		if (direction < 0)
		{
			direction += 8;
		}
		return direction;
	}

	public static sbyte GetDirectionIn(this ByteCoordinate self, byte mapSize)
	{
		if (mapSize <= 5)
		{
			return -1;
		}
		int centerUnit = mapSize / 3;
		if (self.X >= centerUnit && self.X < mapSize - centerUnit && self.Y >= centerUnit && self.Y < mapSize - centerUnit)
		{
			return 8;
		}
		byte center = (byte)(mapSize / 2);
		return self.GetDirectionRelatedTo(new ByteCoordinate(center, center));
	}
}
