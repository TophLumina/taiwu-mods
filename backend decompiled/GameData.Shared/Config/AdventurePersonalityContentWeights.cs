using System;

namespace Config;

[Serializable]
public class AdventurePersonalityContentWeights
{
	/// <summary>
	/// 空格权重
	/// </summary>
	public short EmptyBlockWeight;

	/// <summary>
	/// (事件Id, 权重)
	/// </summary>
	public (string eventGuid, short weight)[] EventWeights;

	/// <summary>
	/// (资源类型Id, 获得数量, 权重)
	/// </summary>
	public (byte resId, short amount, short weight)[] NormalResWeights;

	/// <summary>
	/// (物品类型, 物品TemplateId, 物品数量, 物品权重)
	/// </summary>
	public (byte itemType, short templateId, short amount, short weight)[] SpecialResWeights;

	/// <summary>
	/// (增益类型，增益量，权重)
	/// </summary>
	public (string, short)[] BonusWeights;

	public readonly short[] ContentTypeWeights = new short[5];

	public AdventurePersonalityContentWeights(short emptyBlockWeight, (string, short)[] eventWeights, (byte, short, short)[] resWeights, (byte, short, short, short)[] itemsWeights, (string, short)[] bonusWeights)
	{
		EmptyBlockWeight = emptyBlockWeight;
		EventWeights = eventWeights;
		NormalResWeights = resWeights;
		SpecialResWeights = itemsWeights;
		BonusWeights = bonusWeights;
		ContentTypeWeights[0] = EmptyBlockWeight;
		(string, short)[] eventWeights2 = EventWeights;
		for (int i = 0; i < eventWeights2.Length; i++)
		{
			(string, short) weight = eventWeights2[i];
			ContentTypeWeights[1] += weight.Item2;
		}
		(byte, short, short)[] normalResWeights = NormalResWeights;
		for (int i = 0; i < normalResWeights.Length; i++)
		{
			(byte, short, short) weight2 = normalResWeights[i];
			ContentTypeWeights[2] += weight2.Item3;
		}
		(byte, short, short, short)[] specialResWeights = SpecialResWeights;
		for (int i = 0; i < specialResWeights.Length; i++)
		{
			(byte, short, short, short) weight3 = specialResWeights[i];
			ContentTypeWeights[3] += weight3.Item4;
		}
		(string, short)[] bonusWeights2 = BonusWeights;
		for (int i = 0; i < bonusWeights2.Length; i++)
		{
			(string, short) weight4 = bonusWeights2[i];
			ContentTypeWeights[4] += weight4.Item2;
		}
	}
}
