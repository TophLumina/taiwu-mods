using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct CountdownData : ISerializableGameData
{
	[SerializableGameDataField]
	private int _total;

	[SerializableGameDataField]
	private int _left;

	public static CountdownData Zero => Create(0);

	public int Total => _total;

	public int Left => _left;

	public int Delta => Total - Left;

	public float Progress
	{
		get
		{
			if (!Infinite)
			{
				if (!Off)
				{
					return (float)Left / (float)MathUtils.Max(Total, 1);
				}
				return 0f;
			}
			return 1f;
		}
	}

	public bool On => Left != 0;

	public bool Off => Left == 0;

	public bool Infinite => Left < 0;

	public static CountdownData Create(int total)
	{
		return new CountdownData
		{
			_total = total,
			_left = total
		};
	}

	public static CountdownData Create(int total, int left)
	{
		return new CountdownData
		{
			_total = total,
			_left = left
		};
	}

	public bool Cover(int time)
	{
		if (Infinite)
		{
			return false;
		}
		if (Off || time < 0 || time >= Total)
		{
			_total = (_left = time);
			return true;
		}
		if (time > Left)
		{
			_left = time;
			return true;
		}
		return false;
	}

	public bool Tick(int delta = 1)
	{
		if (Infinite || Off)
		{
			return false;
		}
		_left = MathUtils.Max(_left - delta, 0);
		return true;
	}

	public bool TickToZero()
	{
		if (Infinite || Off)
		{
			return false;
		}
		_left = 0;
		return true;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = _total;
		byte* num = pData + 4;
		*(int*)num = _left;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_total = *(int*)pCurrData;
		pCurrData += 4;
		_left = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
