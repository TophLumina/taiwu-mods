using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceCollection : ConfigData<ResourceCollectionItem, short>
{
	public static ResourceCollection Instance = new ResourceCollection();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ItemIdList", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new ResourceCollectionItem(0, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { -1, -1, -1, -1, -1, -1, -1 }, new sbyte[7] { -1, -1, -1, -1, -1, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(1, new List<ShortList>
		{
			new ShortList(56, 63, 70, 77),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { 5, -1, -1, -1, -1, -1, -1 }, new sbyte[7] { 20, -1, -1, -1, -1, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(2, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(0, 7),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { -1, 5, -1, -1, -1, -1, -1 }, new sbyte[7] { -1, 20, -1, -1, -1, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(3, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(14, 21),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { -1, -1, 5, -1, -1, -1, -1 }, new sbyte[7] { -1, -1, 20, -1, -1, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(4, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(28, 35),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { -1, -1, -1, 5, -1, -1, -1 }, new sbyte[7] { -1, -1, -1, 20, -1, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(5, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(42, 49),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[7] { -1, -1, -1, -1, 5, -1, -1 }, new sbyte[7] { -1, -1, -1, -1, 20, -1, -1 }));
		_dataArray.Add(new ResourceCollectionItem(6, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(140, 144, 148, 152, 156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232),
			new ShortList(236, 243, 250, 257, 264, 271)
		}, new sbyte[7] { -1, -1, -1, -1, -1, 2, 5 }, new sbyte[7] { -1, -1, -1, -1, -1, 10, 20 }));
		_dataArray.Add(new ResourceCollectionItem(7, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 30, 10, 10, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(8, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 30, 10, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(9, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 30, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(10, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 30, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(11, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 10, 30, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(12, new List<ShortList>
		{
			new ShortList(63, 70),
			new ShortList(7),
			new ShortList(21),
			new ShortList(35),
			new ShortList(49),
			new ShortList(140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 10, 10, 15, 30 }));
		_dataArray.Add(new ResourceCollectionItem(13, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 30, 10, 10, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(14, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 30, 10, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(15, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 30, 10, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(16, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 30, 10, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(17, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 10, 30, 5, 10 }));
		_dataArray.Add(new ResourceCollectionItem(18, new List<ShortList>
		{
			new ShortList(56, 77),
			new ShortList(default(short)),
			new ShortList(14),
			new ShortList(28),
			new ShortList(42),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228),
			new ShortList(236, 257, 264)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, 10, 10, 10, 15, 30 }));
		_dataArray.Add(new ResourceCollectionItem(19, new List<ShortList>
		{
			new ShortList(63, 70, 56, 77),
			new ShortList(0, 7),
			new ShortList(14, 21),
			new ShortList(28, 35),
			new ShortList(42, 49),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228, 140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(236, 257, 264, 243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { -1, -1, 10, 10, 10, 10, 20 }));
		_dataArray.Add(new ResourceCollectionItem(20, new List<ShortList>
		{
			new ShortList(63, 70, 56, 77),
			new ShortList(0, 7),
			new ShortList(14, 21),
			new ShortList(28, 35),
			new ShortList(42, 49),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228, 140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(236, 257, 264, 243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { -1, 10, 10, 10, -1, 10, 20 }));
		_dataArray.Add(new ResourceCollectionItem(21, new List<ShortList>
		{
			new ShortList(63, 70, 56, 77),
			new ShortList(0, 7),
			new ShortList(14, 21),
			new ShortList(28, 35),
			new ShortList(42, 49),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228, 140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(236, 257, 264, 243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, -1, 10, -1, 10, 20 }));
		_dataArray.Add(new ResourceCollectionItem(22, new List<ShortList>
		{
			new ShortList(63, 70, 56, 77),
			new ShortList(0, 7),
			new ShortList(14, 21),
			new ShortList(28, 35),
			new ShortList(42, 49),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228, 140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(236, 257, 264, 243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, 10, -1, -1, 10, 10, 20 }));
		_dataArray.Add(new ResourceCollectionItem(23, new List<ShortList>
		{
			new ShortList(63, 70, 56, 77),
			new ShortList(0, 7),
			new ShortList(14, 21),
			new ShortList(28, 35),
			new ShortList(42, 49),
			new ShortList(156, 160, 164, 168, 172, 192, 196, 200, 204, 216, 224, 228, 140, 144, 148, 152, 176, 180, 184, 188, 208, 212, 220, 232),
			new ShortList(236, 257, 264, 243, 250, 271)
		}, new sbyte[7] { 5, 5, 5, 5, 5, 2, 5 }, new sbyte[7] { 10, -1, 10, -1, 10, 10, 20 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ResourceCollectionItem>(24);
		CreateItems0();
	}
}
