namespace GameData.Domains.Character.Display;

/// <summary>
/// 选人界面数据接口，所有用于选人的数据类型都需要实现此接口
/// 这是最小接口，只包含界面必须的基础功能
/// </summary>
public interface ISelectCharacterData
{
	/// <summary>
	/// 获取角色ID
	/// </summary>
	int CharacterId { get; }

	/// <summary>
	/// 获取通用滚动列表显示数据（基础页签所需）
	/// </summary>
	CharacterDisplayDataForGeneralScrollList GetGeneralScrollListData();
}
