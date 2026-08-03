using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 倒计时数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CountdownData : ISerializableGameData
{
	/// <inheritdoc cref="P:GameData.Domains.Combat.CountdownData.Total" />
	[SerializableGameDataField]
	private int _total;

	/// <inheritdoc cref="P:GameData.Domains.Combat.CountdownData.Left" />
	[SerializableGameDataField]
	private int _left;

	/// <summary>
	/// 无倒计时
	/// </summary>
	public static CountdownData Zero => Create(0);

	/// <summary>
	/// 总时间
	/// </summary>
	public int Total => _total;

	/// <summary>
	/// 剩余时间
	/// </summary>
	public int Left => _left;

	/// <summary>
	/// 已经过时间
	/// </summary>
	public int Delta => Total - Left;

	/// <summary>
	/// 进度值，范围 0~1，仅用于相关表现
	/// </summary>
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

	/// <summary>
	/// 处于倒计时
	/// </summary>
	public bool On => Left != 0;

	/// <summary>
	/// 未处于倒计时
	/// </summary>
	public bool Off => Left == 0;

	/// <summary>
	/// 处于永续倒计时
	/// </summary>
	public bool Infinite => Left < 0;

	/// <summary>
	/// 直接根据参数值创建倒计时数据，用于兼容旧结构
	/// </summary>
	/// <param name="total"></param>
	/// <returns></returns>
	public static CountdownData Create(int total)
	{
		return new CountdownData
		{
			_total = total,
			_left = total
		};
	}

	/// <summary>
	/// 直接根据参数值创建倒计时数据，用于兼容旧结构
	/// </summary>
	/// <param name="total"></param>
	/// <param name="left"></param>
	/// <returns></returns>
	public static CountdownData Create(int total, int left)
	{
		return new CountdownData
		{
			_total = total,
			_left = left
		};
	}

	/// <summary>
	/// 通过新时间进行覆盖
	/// </summary>
	/// <param name="time"></param>
	/// <returns>数据是否发生变化</returns>
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

	/// <summary>
	/// 计时
	/// </summary>
	/// <param name="delta"></param>
	/// <returns>数据是否发生变化</returns>
	public bool Tick(int delta = 1)
	{
		if (Infinite || Off)
		{
			return false;
		}
		_left = MathUtils.Max(_left - delta, 0);
		return true;
	}

	/// <summary>
	/// 结束有限的倒计时
	/// </summary>
	/// <returns></returns>
	public bool TickToZero()
	{
		if (Infinite || Off)
		{
			return false;
		}
		_left = 0;
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
