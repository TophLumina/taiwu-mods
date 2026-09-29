using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

public interface IProfessionSkillsData : ISerializableGameData
{
	void Initialize();

	void InheritFrom(IProfessionSkillsData sourceData);
}
