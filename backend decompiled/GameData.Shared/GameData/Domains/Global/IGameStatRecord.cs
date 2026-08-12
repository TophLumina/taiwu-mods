using GameData.Serializer;

namespace GameData.Domains.Global;

/// <summary>
/// 用于存储成就统计的数据类型基类
/// 无论本地存档将要存储的值是什么类型，成就统计需要Int类型， 因此需要实现自定义的类型转换
/// </summary>
public interface IGameStatRecord : ISerializableGameData
{
	/// <summary>
	/// 将统计的存储值转换为成就统计实际所需要的int值
	/// </summary>
	/// <returns></returns>
	int GetStat();

	/// <summary>
	/// 修改一个统计的存储值
	/// </summary>
	/// <param name="value"></param>
	/// <param name="setType"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	bool SetStat<T>(T value, EStatInfoSetType setType);

	/// <summary>
	/// 查询统计的存储是否存在一个特定的值
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	bool Contains(int value);

	/// <summary>
	/// 查询两个统计的存储是否共有一个特定的值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	bool Overlaps<T>(T other);
}
