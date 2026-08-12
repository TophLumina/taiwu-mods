using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventActorsItem : ConfigItem<EventActorsItem, short>
{
	/// <summary>
	/// 演员Id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 人物的显示姓名
	/// - 留空的人物显示姓名将自动随机，如果需要处理姓氏则需要单独逻辑处理
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 指定的固定人物立绘
	/// - 一旦指定该字段，后续所有字段都会失效
	/// </summary>
	public readonly string Texture;

	/// <summary>
	/// 固定人物动态立绘
	/// </summary>
	public readonly string SpineName;

	/// <summary>
	/// 固定人物动态立绘皮肤
	/// </summary>
	public readonly string SpineSkinName;

	/// <summary>
	/// 要生成的人物性别
	/// - 女 : 0  男 : 1  随机 : -1
	/// </summary>
	public readonly sbyte Gender;

	/// <summary>
	/// 要生成的人物年龄
	/// - 范围值，上下限相同时，生成固定年龄演员
	/// </summary>
	public readonly byte[] Age;

	/// <summary>
	/// 要生成的人物魅力值
	/// </summary>
	public readonly short[] Attraction;

	/// <summary>
	/// 指定的衣装
	/// </summary>
	public readonly short Clothing;

	/// <summary>
	/// 人物是否出家
	/// - 若TRUE，则发型为没有头发
	/// </summary>
	public readonly bool IsMonk;

	/// <summary>
	/// 预设体型
	/// - 0: 瘦, 1: 普通, 2: 胖, -1: 不限制. 固定角色必须设置有效值.
	/// </summary>
	public readonly sbyte PresetBodyType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">演员Id</param>
	/// <param name="name">人物的显示姓名 - 留空的人物显示姓名将自动随机，如果需要处理姓氏则需要单独逻辑处理</param>
	/// <param name="texture">指定的固定人物立绘 - 一旦指定该字段，后续所有字段都会失效</param>
	/// <param name="spineName">固定人物动态立绘</param>
	/// <param name="spineSkinName">固定人物动态立绘皮肤</param>
	/// <param name="gender">要生成的人物性别 - 女 : 0  男 : 1  随机 : -1</param>
	/// <param name="age">要生成的人物年龄 - 范围值，上下限相同时，生成固定年龄演员</param>
	/// <param name="attraction">要生成的人物魅力值</param>
	/// <param name="clothing">指定的衣装</param>
	/// <param name="isMonk">人物是否出家 - 若TRUE，则发型为没有头发</param>
	/// <param name="presetBodyType">预设体型 - 0: 瘦, 1: 普通, 2: 胖, -1: 不限制. 固定角色必须设置有效值.</param>
	public EventActorsItem(short templateId, string name, string texture, string spineName, string spineSkinName, sbyte gender, byte[] age, short[] attraction, short clothing, bool isMonk, sbyte presetBodyType)
	{
		TemplateId = templateId;
		Name = name;
		Texture = texture;
		SpineName = spineName;
		SpineSkinName = spineSkinName;
		Gender = gender;
		Age = age;
		Attraction = attraction;
		Clothing = clothing;
		IsMonk = isMonk;
		PresetBodyType = presetBodyType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventActorsItem()
	{
		TemplateId = 0;
		Name = null;
		Texture = null;
		SpineName = null;
		SpineSkinName = null;
		Gender = -1;
		Age = new byte[2] { 18, 60 };
		Attraction = new short[2] { 0, 900 };
		Clothing = 0;
		IsMonk = false;
		PresetBodyType = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventActorsItem(short templateId, EventActorsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Texture = other.Texture;
		SpineName = other.SpineName;
		SpineSkinName = other.SpineSkinName;
		Gender = other.Gender;
		Age = other.Age;
		Attraction = other.Attraction;
		Clothing = other.Clothing;
		IsMonk = other.IsMonk;
		PresetBodyType = other.PresetBodyType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventActorsItem Duplicate(int templateId)
	{
		return new EventActorsItem((short)templateId, this);
	}
}
