namespace GameData.Domains.LifeRecord;

/// <summary>
/// 纯记录，为前后端交换数据而设。
/// 不会生成AddDate/AddSeparateLine，仅会生成data
/// 需要前端将数据转换为正确的显示格式
///
/// 需注意，这里的数据应当倒序存储(IntoData会假定数据是倒序存储的)
/// 同时，应注意，此数据暂不支持AutoGenerateSerializableGameData序列化（但可以使用code-generator生成的序列化代码）
/// </summary>
public class TransferablePureData : TransferableRecordDataBase
{
	/// <summary>
	/// 增加真名信息
	/// 由于这一项只可能出现在Header中，因此省略bool increaseExtraCount的相关逻辑
	/// </summary>
	/// <param name="date"></param>
	public override void AddDate(int date, bool increaseExtraCount = true)
	{
	}
}
