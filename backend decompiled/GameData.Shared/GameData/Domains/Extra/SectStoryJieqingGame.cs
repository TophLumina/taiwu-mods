using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

/// <summary>
/// 界青地区主线 - 七巧板游戏数据
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class SectStoryJieqingGame : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CurrentTurn = 0;

		public const ushort CurrentScore = 1;

		public const ushort RerollMaxCount = 2;

		public const ushort RerollLeftCount = 3;

		public const ushort ReopenLeftCount = 4;

		public const ushort GameResult = 5;

		public const ushort LastPeaceTemplateId = 6;

		public const ushort CurrPeaceTemplateId = 7;

		public const ushort CurrPeaceIsFlipped = 8;

		public const ushort CurrPeaceRotationState = 9;

		public const ushort BroadChessData = 10;

		public const ushort NextPieceTemplateId = 11;

		public const ushort Count = 12;

		public static readonly string[] FieldId2FieldName = new string[12]
		{
			"CurrentTurn", "CurrentScore", "RerollMaxCount", "RerollLeftCount", "ReopenLeftCount", "GameResult", "LastPeaceTemplateId", "CurrPeaceTemplateId", "CurrPeaceIsFlipped", "CurrPeaceRotationState",
			"BroadChessData", "NextPieceTemplateId"
		};
	}

	/// <summary>
	/// 棋盘边长
	/// </summary>
	private const int BoardSize = 7;

	/// <summary>
	/// 预览区大小
	/// </summary>
	private const int PreviewSize = 4;

	/// <summary>
	/// 每章节的回合数
	/// </summary>
	private const int ChapterTurnCount = 4;

	/// <summary>
	/// 当前回合
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int CurrentTurn { get; set; }

	/// <summary>
	/// 当前分数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int CurrentScore { get; set; }

	/// <summary>
	/// 最大随机次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int RerollMaxCount { get; set; }

	/// <summary>
	/// 剩余随机次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public int RerollLeftCount { get; set; }

	/// <summary>
	/// 剩余重开次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public int ReopenLeftCount { get; set; }

	/// <summary>
	/// 游戏结果状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte GameResult { get; set; }

	/// <summary>
	/// 上次预览区的七巧板id
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public short LastPeaceTemplateId { get; set; }

	/// <summary>
	/// 当前预览区的七巧板id
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	public short CurrPeaceTemplateId { get; set; }

	/// <summary>
	/// 当前预览区的七巧板是否镜像翻转
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public bool CurrPeaceIsFlipped { get; set; }

	/// <summary>
	/// 当前预览区的七巧板旋转状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	public sbyte CurrPeaceRotationState { get; set; }

	/// <summary>
	/// 棋盘放置的棋子状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 10)]
	public List<JieqingGameChessData> BroadChessData { get; set; }

	/// <summary>
	/// 下个预览区的七巧板id
	/// </summary>
	[SerializableGameDataField(FieldIndex = 11)]
	public short NextPieceTemplateId { get; set; }

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryJieqingGame()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectStoryJieqingGame(SectStoryJieqingGame other)
	{
		CurrentTurn = other.CurrentTurn;
		CurrentScore = other.CurrentScore;
		RerollMaxCount = other.RerollMaxCount;
		RerollLeftCount = other.RerollLeftCount;
		ReopenLeftCount = other.ReopenLeftCount;
		GameResult = other.GameResult;
		LastPeaceTemplateId = other.LastPeaceTemplateId;
		CurrPeaceTemplateId = other.CurrPeaceTemplateId;
		CurrPeaceIsFlipped = other.CurrPeaceIsFlipped;
		CurrPeaceRotationState = other.CurrPeaceRotationState;
		if (other.BroadChessData != null)
		{
			List<JieqingGameChessData> broadChessData = other.BroadChessData;
			int elementsCount = broadChessData.Count;
			BroadChessData = new List<JieqingGameChessData>(elementsCount);
			foreach (JieqingGameChessData element in broadChessData)
			{
				BroadChessData.Add(new JieqingGameChessData(element));
			}
		}
		else
		{
			BroadChessData = null;
		}
		NextPieceTemplateId = other.NextPieceTemplateId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectStoryJieqingGame other)
	{
		CurrentTurn = other.CurrentTurn;
		CurrentScore = other.CurrentScore;
		RerollMaxCount = other.RerollMaxCount;
		RerollLeftCount = other.RerollLeftCount;
		ReopenLeftCount = other.ReopenLeftCount;
		GameResult = other.GameResult;
		LastPeaceTemplateId = other.LastPeaceTemplateId;
		CurrPeaceTemplateId = other.CurrPeaceTemplateId;
		CurrPeaceIsFlipped = other.CurrPeaceIsFlipped;
		CurrPeaceRotationState = other.CurrPeaceRotationState;
		if (other.BroadChessData != null)
		{
			List<JieqingGameChessData> broadChessData = other.BroadChessData;
			int elementsCount = broadChessData.Count;
			BroadChessData = new List<JieqingGameChessData>(elementsCount);
			foreach (JieqingGameChessData element in broadChessData)
			{
				BroadChessData.Add(new JieqingGameChessData(element));
			}
		}
		else
		{
			BroadChessData = null;
		}
		NextPieceTemplateId = other.NextPieceTemplateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 31;
		if (BroadChessData != null)
		{
			totalSize += 2;
			for (int i = 0; i < BroadChessData.Count; i++)
			{
				totalSize = ((BroadChessData[i] == null) ? (totalSize + 2) : (totalSize + (2 + BroadChessData[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 12;
		pCurrData += 2;
		*(int*)pCurrData = CurrentTurn;
		pCurrData += 4;
		*(int*)pCurrData = CurrentScore;
		pCurrData += 4;
		*(int*)pCurrData = RerollMaxCount;
		pCurrData += 4;
		*(int*)pCurrData = RerollLeftCount;
		pCurrData += 4;
		*(int*)pCurrData = ReopenLeftCount;
		pCurrData += 4;
		*pCurrData = (byte)GameResult;
		pCurrData++;
		*(short*)pCurrData = LastPeaceTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = CurrPeaceTemplateId;
		pCurrData += 2;
		*pCurrData = (CurrPeaceIsFlipped ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)CurrPeaceRotationState;
		pCurrData++;
		if (BroadChessData != null)
		{
			int elementsCount = BroadChessData.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (BroadChessData[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = BroadChessData[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = NextPieceTemplateId;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			CurrentTurn = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			CurrentScore = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			RerollMaxCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			RerollLeftCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			ReopenLeftCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			GameResult = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			LastPeaceTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 7)
		{
			CurrPeaceTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 8)
		{
			CurrPeaceIsFlipped = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 9)
		{
			CurrPeaceRotationState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (BroadChessData == null)
				{
					BroadChessData = new List<JieqingGameChessData>();
				}
				else
				{
					BroadChessData.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					JieqingGameChessData element;
					if (num > 0)
					{
						element = new JieqingGameChessData();
						pCurrData += element.Deserialize(pCurrData);
					}
					else
					{
						element = null;
					}
					BroadChessData.Add(element);
				}
			}
			else
			{
				BroadChessData?.Clear();
			}
		}
		if (fieldCount > 11)
		{
			NextPieceTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
