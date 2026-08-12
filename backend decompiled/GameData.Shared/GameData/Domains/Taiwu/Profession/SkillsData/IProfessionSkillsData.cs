using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 职业(志向)技能 相关额外数据
/// </summary>
public interface IProfessionSkillsData : ISerializableGameData
{
	/// <summary>
	/// 用于无需每次都在构造方法中执行的初始化数据
	/// </summary>
	void Initialize();

	/// <summary>
	/// 用于就存档升级
	/// </summary>
	/// <param name="sourceData"></param>
	void InheritFrom(IProfessionSkillsData sourceData);
}
