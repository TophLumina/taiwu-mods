using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Config;
using GameData.ArchiveData;
using GameData.ArchiveData.Tables;
using GameData.Common;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.LifeRecord;

[GameDataDomain(13, CustomArchiveModuleCode = true)]
public class LifeRecordDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValue, false, false, false, false)]
	private int _lifeRecord;

	public const int MaxDepth = 500;

	private readonly StringBuilder _lifeRecordSqlBuilder = new StringBuilder(2048);

	private readonly LifeRecordCollection _currLifeRecords = new LifeRecordCollection();

	private readonly HashSet<JustDeadCharacterData> _justDeadCharacters = new HashSet<JustDeadCharacterData>();

	private readonly HashSet<int> _needRemoveLifeRecordCharIds = new HashSet<int>();

	private readonly HashSet<int> _needRemoveDeadLifeRecordCharIds = new HashSet<int>();

	private readonly List<short> _sourceRecordTemplateIds = new List<short>();

	private readonly Dictionary<short, string> _templateId2Name = new Dictionary<short, string>();

	private Type _lifeRecordCollectionType;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[1][];

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
	}

	private void OnLoadedArchiveData()
	{
	}

	private unsafe static ReadonlyLifeRecords ParseQuery(IEnumerable<LifeRecordTmp> query)
	{
		List<LifeRecordTmp> queryResults = query.ToList();
		ReadonlyLifeRecords records = new ReadonlyLifeRecords
		{
			Count = queryResults.Count
		};
		int size = 0;
		foreach (LifeRecordTmp lr in queryResults)
		{
			size += 7;
			int num = size;
			byte[] param = lr.Param;
			size = num + ((param != null) ? param.Length : 0);
		}
		records.Size = size;
		records.RawData = new byte[size];
		fixed (byte* pRawData = records.RawData)
		{
			int offset = 0;
			foreach (LifeRecordTmp lr2 in queryResults)
			{
				byte* pCurrent = pRawData + offset;
				byte[] param2 = lr2.Param;
				int paramSize = ((param2 != null) ? param2.Length : 0);
				byte itemSize = (*pCurrent = (byte)(7 + paramSize));
				pCurrent++;
				*(int*)pCurrent = lr2.Date;
				pCurrent += 4;
				*(short*)pCurrent = (short)lr2.Type;
				pCurrent += 2;
				if (lr2.Param != null)
				{
					fixed (byte* pParam = lr2.Param)
					{
						Buffer.MemoryCopy(pParam, pCurrent, paramSize, paramSize);
					}
				}
				offset += itemSize;
			}
		}
		return records;
	}

	private unsafe static IEnumerable<LifeRecordTmp> ParseCollection(LifeRecordCollection collection)
	{
		List<LifeRecordTmp> list = new List<LifeRecordTmp>();
		int offset = 0;
		fixed (byte* pRawData = collection.RawData)
		{
			while (offset < collection.Size)
			{
				byte* pCurrData = pRawData + offset;
				int charId = *(int*)pCurrData;
				pCurrData += 4;
				byte subSize = *pCurrData;
				pCurrData++;
				int date = *(int*)pCurrData;
				pCurrData += 4;
				short type = *(short*)pCurrData;
				pCurrData += 2;
				int paramSize = subSize - 1 + 4 + 2;
				byte[] param = new byte[subSize];
				fixed (byte* pParam = param)
				{
					Buffer.MemoryCopy(pCurrData, pParam, subSize, subSize);
				}
				offset += 4 + subSize;
				LifeRecordTmp lifeRecord = new LifeRecordTmp
				{
					Self = charId,
					Date = date,
					Type = type,
					Param = param
				};
				list.Add(lifeRecord);
			}
		}
		return list;
	}

	private IEnumerable<LifeRecordTmp> Query(int charId, int beginIndex, int count)
	{
		return DatabaseBridge.Query((LifeRecordTmp lr) => lr.Self == charId && lr.Id >= beginIndex).Take(count);
	}

	private IEnumerable<LifeRecordTmp> QueryByDate(int charId, int startDate, int monthCount)
	{
		int endDate = startDate + monthCount - 1;
		return DatabaseBridge.Query((LifeRecordTmp lr) => lr.Self == charId && lr.Date >= startDate && lr.Date <= endDate);
	}

	private List<LifeRecordTmp> QueryByJustDeadCharacters()
	{
		List<LifeRecordTmp> result = new List<LifeRecordTmp>();
		int counter = 0;
		bool first = true;
		using (HashSet<JustDeadCharacterData>.Enumerator iter = _justDeadCharacters.GetEnumerator())
		{
			while (iter.MoveNext())
			{
				if (counter == 0)
				{
					_lifeRecordSqlBuilder.Clear();
					_lifeRecordSqlBuilder.Append("SELECT * FROM LifeRecordTmp");
					first = true;
				}
				JustDeadCharacterData data = iter.Current;
				_lifeRecordSqlBuilder.Append(first ? " WHERE " : " OR ");
				first = false;
				_lifeRecordSqlBuilder.Append("(Self = ");
				_lifeRecordSqlBuilder.Append(data.CharacterId);
				_lifeRecordSqlBuilder.Append(" AND Date > ");
				_lifeRecordSqlBuilder.Append(data.CurrDate - 12);
				_lifeRecordSqlBuilder.Append(" AND Date <= ");
				_lifeRecordSqlBuilder.Append(data.CurrDate);
				_lifeRecordSqlBuilder.Append(')');
				counter++;
				if (counter >= 500)
				{
					counter = 0;
					DoQuery();
				}
			}
			if (counter > 0)
			{
				DoQuery();
			}
			return result;
		}
		void DoQuery()
		{
			string cmd = _lifeRecordSqlBuilder.ToString();
			DatabaseBridge.Query(result, cmd);
		}
	}

	private IEnumerable<LifeRecordTmp> QueryLast(int charId, int count)
	{
		return (from lr in DatabaseBridge.Query((LifeRecordTmp lr) => lr.Self == charId)
			orderby lr.Id descending
			select lr).Take(count);
	}

	private IEnumerable<LifeRecordTmp> QueryAll(int charId)
	{
		return DatabaseBridge.Query((LifeRecordTmp lr) => lr.Self == charId);
	}

	private IEnumerable<LifeRecordTmp> QueryDead(int charId)
	{
		return DatabaseBridge.Query((LifeRecordDeadTmp lr) => lr.Self == charId);
	}

	private void DeleteBySelfId(string tableName, IEnumerable<int> charIds)
	{
		int counter = 0;
		bool first = true;
		using (IEnumerator<int> iter = charIds.GetEnumerator())
		{
			while (iter.MoveNext())
			{
				if (counter == 0)
				{
					_lifeRecordSqlBuilder.Clear();
					StringBuilder lifeRecordSqlBuilder = _lifeRecordSqlBuilder;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(27, 1, lifeRecordSqlBuilder);
					handler.AppendLiteral("DELETE FROM ");
					handler.AppendFormatted(tableName);
					handler.AppendLiteral(" WHERE Self in ");
					lifeRecordSqlBuilder.Append(ref handler);
					first = true;
				}
				_lifeRecordSqlBuilder.Append(first ? '(' : ',');
				first = false;
				int charId = iter.Current;
				_lifeRecordSqlBuilder.Append(charId);
				counter++;
				if (counter >= 500)
				{
					counter = 0;
					DoExecute();
				}
			}
			if (counter > 0)
			{
				DoExecute();
			}
		}
		void DoExecute()
		{
			_lifeRecordSqlBuilder.Append(')');
			string cmd = _lifeRecordSqlBuilder.ToString();
			DatabaseBridge.Execute(cmd);
		}
	}

	[DomainMethod(IsPassthrough = true)]
	public void Get(uint operationId, int charId, int beginIndex, int count)
	{
		ReadonlyLifeRecordsWithTotalCount records = new ReadonlyLifeRecordsWithTotalCount();
		records.TotalCount = count;
		records.Records = ParseQuery(Query(charId, beginIndex, count));
		GameData.GameDataBridge.GameDataBridge.TryReturnPassthroughMethod(operationId, records);
	}

	[DomainMethod(IsPassthrough = true)]
	public void GetByDate(uint operationId, int charId, int startDate, int monthCount)
	{
		ReadonlyLifeRecordsWithDate records = new ReadonlyLifeRecordsWithDate();
		records.CharId = charId;
		records.StartDate = startDate;
		records.MonthCount = monthCount;
		records.Records = ParseQuery(QueryByDate(charId, startDate, monthCount));
		GameData.GameDataBridge.GameDataBridge.TryReturnPassthroughMethod(operationId, records);
	}

	[DomainMethod(IsPassthrough = true)]
	public void GetLast(uint operationId, int charId, int count)
	{
		ReadonlyLifeRecords records = ParseQuery(QueryLast(charId, count));
		GameData.GameDataBridge.GameDataBridge.TryReturnPassthroughMethod(operationId, records);
	}

	[DomainMethod(IsPassthrough = true)]
	public void GetRelated(uint operationId, int charId, int date, short recordType, int relatedCharId)
	{
		throw new NotSupportedException("GetRelated is not supported now.");
	}

	public void Remove(int charId)
	{
		_needRemoveLifeRecordCharIds.Add(charId);
	}

	public void GenerateDead(int charId, int currDate)
	{
		_justDeadCharacters.Add(new JustDeadCharacterData(charId, currDate));
	}

	[DomainMethod(IsPassthrough = true)]
	public void GetDead(uint operationId, int charId)
	{
		ReadonlyLifeRecords records = ParseQuery(QueryDead(charId));
		GameData.GameDataBridge.GameDataBridge.TryReturnPassthroughMethod(operationId, records);
	}

	public void RemoveDead(int charId)
	{
		_needRemoveDeadLifeRecordCharIds.Add(charId);
	}

	public LifeRecordCollection GetLifeRecordCollection()
	{
		return _currLifeRecords;
	}

	public void CommitCurrLifeRecords()
	{
		CommitCurrLifeRecords_NewRecords();
		CommitCurrLifeRecords_JustDeadCharacters();
		CommitCurrLifeRecords_RemoveLifeRecord();
		CommitCurrLifeRecords_RemoveDeadLifeRecord();
	}

	private void CommitCurrLifeRecords_NewRecords()
	{
		if (_currLifeRecords.Count > 0)
		{
			Stopwatch sw = Stopwatch.StartNew();
			DatabaseBridge.InsertAll(ParseCollection(_currLifeRecords));
			sw.Stop();
			AdaptableLog.TagInfo("DB", $"Commit {_currLifeRecords.Count} life records cost {sw.ElapsedMilliseconds}ms");
			_currLifeRecords.Clear();
		}
	}

	private void CommitCurrLifeRecords_JustDeadCharacters()
	{
		HashSet<JustDeadCharacterData> justDeadCharacters = _justDeadCharacters;
		if (justDeadCharacters == null || justDeadCharacters.Count <= 0)
		{
			return;
		}
		Stopwatch sw = Stopwatch.StartNew();
		List<LifeRecordTmp> stay = QueryByJustDeadCharacters();
		sw.Stop();
		AdaptableLog.TagInfo("DB", $"Query {_justDeadCharacters.Count} dead cost {sw.ElapsedMilliseconds}ms");
		_justDeadCharacters.Clear();
		if (stay.Count != 0)
		{
			sw.Restart();
			stay.Reverse();
			DatabaseBridge.InsertAll(stay.Select((LifeRecordTmp lr) => new LifeRecordDeadTmp(lr)));
			sw.Stop();
			AdaptableLog.TagInfo("DB", $"Commit {stay.Count} dead life records cost {sw.ElapsedMilliseconds}ms");
		}
	}

	private void CommitCurrLifeRecords_RemoveLifeRecord()
	{
		HashSet<int> needRemoveLifeRecordCharIds = _needRemoveLifeRecordCharIds;
		if (needRemoveLifeRecordCharIds != null && needRemoveLifeRecordCharIds.Count > 0)
		{
			Stopwatch sw = Stopwatch.StartNew();
			DeleteBySelfId("LifeRecordTmp", _needRemoveLifeRecordCharIds);
			sw.Stop();
			int count = _needRemoveLifeRecordCharIds.Count;
			AdaptableLog.TagInfo("DB", $"Remove LR {count} cost {sw.ElapsedMilliseconds}ms");
			_needRemoveLifeRecordCharIds.Clear();
		}
	}

	private void CommitCurrLifeRecords_RemoveDeadLifeRecord()
	{
		HashSet<int> needRemoveDeadLifeRecordCharIds = _needRemoveDeadLifeRecordCharIds;
		if (needRemoveDeadLifeRecordCharIds != null && needRemoveDeadLifeRecordCharIds.Count > 0)
		{
			Stopwatch sw = Stopwatch.StartNew();
			DeleteBySelfId("LifeRecordDeadTmp", _needRemoveDeadLifeRecordCharIds);
			sw.Stop();
			int count = _needRemoveDeadLifeRecordCharIds.Count;
			AdaptableLog.TagInfo("DB", $"Remove LRD {count} cost {sw.ElapsedMilliseconds}ms");
			_needRemoveDeadLifeRecordCharIds.Clear();
		}
	}

	[DomainMethod]
	public ArgumentCollectionRenderArguments GetRecordRenderInfoArguments(DataContext context, string key, RecordArgumentsRequest request, bool isDreamBack = false)
	{
		ArgumentCollectionRenderArguments data = new ArgumentCollectionRenderArguments();
		data.Key = key;
		List<int> characters = request.Characters;
		if (characters != null && characters.Count > 0)
		{
			data.CharNameAndLifeDataList = (isDreamBack ? DomainManager.Extra.GetNameAndLifeRelatedDataListForDreamBack(request.Characters) : DomainManager.Character.GetNameAndLifeRelatedDataList(request.Characters));
		}
		List<Location> locations = request.Locations;
		if (locations != null && locations.Count > 0)
		{
			data.LocationNames = DomainManager.Map.GetLocationNameRelatedDataList(request.Locations);
		}
		List<short> settlements = request.Settlements;
		if (settlements != null && settlements.Count > 0)
		{
			data.SettlementNames = DomainManager.Organization.GetSettlementNameRelatedData(request.Settlements);
		}
		characters = request.JiaoLoongs;
		if (characters != null && characters.Count > 0)
		{
			data.JiaoLoongNames = DomainManager.Extra.GetJiaoLoongNameRelatedDataList(request.JiaoLoongs);
		}
		return data;
	}

	public int GetLastRecordDate(int charId)
	{
		GameData.Domains.Character.Character element;
		TransferableLifeRecordData data = (DomainManager.Character.TryGetElement_Objects(charId, out element) ? ParseQuery(QueryLast(charId, 1)).IntoData() : ParseQuery(QueryDead(charId)).IntoData());
		List<TransferableRecord> record = data.Record;
		return (record != null && record.Count > 0) ? data.EndDate : DomainManager.World.GetCurrDate();
	}

	[DomainMethod]
	public TransferableLifeRecordData GetReversedRecord(DataContext context, int charId, int startCount, int readCount, bool isDreamBack = false)
	{
		return GetReversedRecordImpl(charId, startCount, readCount, isDreamBack);
	}

	public TransferableLifeRecordData GetReversedRecordImpl(int charId, int startCount, int readCount, bool isDreamBack = false)
	{
		TransferableLifeRecordData data;
		if (!isDreamBack)
		{
			data = ((!DomainManager.Character.TryGetElement_Objects(charId, out var _)) ? ParseQuery(QueryDead(charId)).IntoData() : ParseQuery(QueryLast(charId, startCount + readCount).Skip(startCount)).IntoData());
		}
		else
		{
			data = new TransferableLifeRecordData();
			DomainManager.Extra.GetDreamBackLifeRecords().ReadDataWithNormalOrder(data, ReadonlyLifeRecords.GetParametersByTemplateId);
		}
		return ParseReversedRecord(data, charId);
	}

	public TransferableLifeRecordData ParseReversedRecord(TransferableLifeRecordData data, int charId, bool isDreamBack = false)
	{
		data.IsDreamBack = isDreamBack;
		data.CharId = charId;
		data.TaiwuCharId = (isDreamBack ? DomainManager.Extra.GetDreamBackTaiwuCharId() : DomainManager.Taiwu.GetTaiwuCharId());
		data.FavorToTaiwu = (short)((isDreamBack || charId == data.TaiwuCharId) ? 30000 : DomainManager.Character.GetFavorability(charId, data.TaiwuCharId));
		if (data.FavorToTaiwu == short.MinValue)
		{
			data.FavorToTaiwu = 0;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var _))
		{
			data.FavorToTaiwu = 30000;
		}
		(int, bool) obj;
		if (!isDreamBack)
		{
			obj = (DomainManager.Character.TryGetElement_Objects(charId, out var character) ? (character.GetBirthDate(), true) : (DomainManager.Character.TryGetDeadCharacter(charId, out var deadCharacter) ? (deadCharacter.BirthDate, true) : (0, false)));
		}
		else
		{
			(CharacterDisplayDataForRelations, bool) characterDisplayDataForDreamBackRelations = DomainManager.Extra.GetCharacterDisplayDataForDreamBackRelations(charId);
			CharacterDisplayDataForRelations item = characterDisplayDataForDreamBackRelations.Item1;
			obj = (characterDisplayDataForDreamBackRelations.Item2 ? (item.Main.BirthDate, true) : (0, false));
		}
		(int, bool) birthDate = obj;
		List<NameAndLifeRelatedData> list2;
		if (!isDreamBack)
		{
			CharacterDomain character2 = DomainManager.Character;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<int> span = CollectionsMarshal.AsSpan(list);
			int index = 0;
			span[index] = charId;
			list2 = character2.GetNameAndLifeRelatedDataList(list);
		}
		else
		{
			ExtraDomain extra = DomainManager.Extra;
			int index = 1;
			List<int> list3 = new List<int>(index);
			CollectionsMarshal.SetCount(list3, index);
			Span<int> span2 = CollectionsMarshal.AsSpan(list3);
			int num = 0;
			span2[num] = charId;
			list2 = extra.GetNameAndLifeRelatedDataListForDreamBack(list3);
		}
		short charTemplateId = list2[0].NameRelatedData.CharTemplateId;
		ref int item2 = ref birthDate.Item1;
		int num2 = item2;
		bool flag = ((charTemplateId < 968 || charTemplateId > 1011) ? true : false);
		item2 = num2 + ((!flag) ? 192 : 0);
		CharacterItem itemOrDefault = Config.Character.Instance.GetItemOrDefault(charTemplateId);
		if (itemOrDefault != null && itemOrDefault.ConvertToIntelligent)
		{
			birthDate.Item2 = false;
		}
		if (birthDate.Item2)
		{
			if (birthDate.Item1 != data.StartDate)
			{
				data.HeaderCount = 2;
				if (data.Record.Count != 0)
				{
					data.AddDate(data.StartDate, increaseExtraCount: false);
					data.AddSeparateLine(birthDate.Item1, increaseExtraCount: false);
					data.HeaderCount += 2;
				}
				data.AddBirth(birthDate.Item1);
				data.AddDate(Math.Max(0, birthDate.Item1), increaseExtraCount: false);
				data.StartDate = Math.Max(0, birthDate.Item1);
				data.EndDate = Math.Max(data.EndDate, data.StartDate);
			}
			else
			{
				data.AddBirth(birthDate.Item1);
				data.AddDate(birthDate.Item1, increaseExtraCount: false);
				data.HeaderCount = 2;
			}
		}
		else
		{
			data.AddDate(data.StartDate, increaseExtraCount: false);
			data.HeaderCount = 1;
		}
		PostProcess(data);
		return data;
	}

	public static void PostProcess(TransferableRecordDataBase data)
	{
		if (data.CharId != -1)
		{
			data.ArgumentCollection.CharacterSet.Add(data.CharId);
		}
		List<int> keys = data.ArgumentCollection.CharacterSet.ToList();
		data.ArgumentCollection.CharacterSet.Clear();
		List<NameAndLifeRelatedData> values = (data.IsDreamBack ? DomainManager.Extra.GetNameAndLifeRelatedDataListForDreamBack(keys) : DomainManager.Character.GetNameAndLifeRelatedDataList(keys));
		data.CharNames = keys.Zip(values, (int i, NameAndLifeRelatedData relatedData) => (i: i, relatedData: relatedData)).ToDictionary(((int i, NameAndLifeRelatedData relatedData) key) => key.i, ((int i, NameAndLifeRelatedData relatedData) key) => key.relatedData);
		List<Location> keys2 = data.ArgumentCollection.LocationSet.ToList();
		data.ArgumentCollection.LocationSet.Clear();
		List<LocationNameRelatedData> values2 = DomainManager.Map.GetLocationNameRelatedDataList(keys2);
		data.LocationNames = keys2.Zip(values2, (Location i, LocationNameRelatedData relatedData) => (i: i, relatedData: relatedData)).ToDictionary(((Location i, LocationNameRelatedData relatedData) key) => key.i, ((Location i, LocationNameRelatedData relatedData) key) => key.relatedData);
		List<short> keys3 = data.ArgumentCollection.SettlementSet.ToList();
		data.ArgumentCollection.SettlementSet.Clear();
		List<SettlementNameRelatedData> values3 = DomainManager.Organization.GetSettlementNameRelatedData(keys3);
		data.SettlementNames = keys3.Zip(values3, (short i, SettlementNameRelatedData relatedData) => (i: i, relatedData: relatedData)).ToDictionary(((short i, SettlementNameRelatedData relatedData) key) => key.i, ((short i, SettlementNameRelatedData relatedData) key) => key.relatedData);
		if (DomainManager.Organization.ContainsStockadeInStory(keys3, out var stockadeInStoryId))
		{
			data.SettlementNames[stockadeInStoryId] = new SettlementNameRelatedData(-2, -1);
		}
		List<int> keys4 = data.ArgumentCollection.JiaoLoongSet.ToList();
		data.ArgumentCollection.JiaoLoongSet.Clear();
		List<JiaoLoongNameRelatedData> values4 = DomainManager.Extra.GetJiaoLoongNameRelatedDataList(keys4);
		data.JiaoLoongNames = keys4.Zip(values4, (int i, JiaoLoongNameRelatedData relatedData) => (i: i, relatedData: relatedData)).ToDictionary(((int i, JiaoLoongNameRelatedData relatedData) key) => key.i, ((int i, JiaoLoongNameRelatedData relatedData) key) => key.relatedData);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		int charId = DomainManager.Taiwu.GetTaiwuCharId();
		crossArchiveGameData.LifeRecords = ParseQuery(QueryAll(charId));
	}

	public void InitializeTestRelatedData()
	{
		_sourceRecordTemplateIds.Clear();
		foreach (LifeRecordItem item in (IEnumerable<LifeRecordItem>)Config.LifeRecord.Instance)
		{
			if (item.IsSourceRecord)
			{
				_sourceRecordTemplateIds.Add(item.TemplateId);
			}
		}
		_templateId2Name.Clear();
		Type defKeysType = Type.GetType("Config.LifeRecord+DefKey");
		Tester.Assert(defKeysType != null);
		FieldInfo[] defKeysFieldInfos = defKeysType.GetFields(BindingFlags.Static | BindingFlags.Public);
		FieldInfo[] array = defKeysFieldInfos;
		foreach (FieldInfo info in array)
		{
			string name = info.Name;
			short templateId = (short)info.GetValue(null);
			_templateId2Name.Add(templateId, name);
		}
		_lifeRecordCollectionType = Type.GetType("GameData.Domains.LifeRecord.LifeRecordCollection");
	}

	public void AddRandomLifeRecord(DataContext context, LifeRecordCollection lifeRecords, GameData.Domains.Character.Character character, MapBlockData mapBlockData)
	{
		for (int i = 0; i < 3; i++)
		{
			if (AddRandomLifeRecordInternal(context, lifeRecords, character, mapBlockData))
			{
				break;
			}
		}
	}

	public void ShowLifeRecords(int charId, int beginIndex, int desiredCount, ReadonlyLifeRecordsWithTotalCount lifeRecords)
	{
		if (_lifeRecordCollectionType == null)
		{
			InitializeTestRelatedData();
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		var (surname, givenName) = CharacterDomain.GetRealName(character);
		Logger.Info($"{surname}{givenName}: {lifeRecords.Records.Count}/{lifeRecords.TotalCount}");
		List<LifeRecordRenderInfo> renderInfos = new List<LifeRecordRenderInfo>();
		ArgumentCollection argumentCollection = new ArgumentCollection();
		lifeRecords.Records.GetRenderInfos(renderInfos, argumentCollection);
		foreach (LifeRecordRenderInfo info in renderInfos)
		{
			int year = info.Date / 12;
			int month = info.Date % 12;
			Logger.Info($"  {year + 1}年{month + 1}月: {info.Text}");
		}
	}

	public void ShowLifeRecords(int charId, int desiredCount, ReadonlyLifeRecords lifeRecords)
	{
		if (_lifeRecordCollectionType == null)
		{
			InitializeTestRelatedData();
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		var (surname, givenName) = CharacterDomain.GetRealName(character);
		Logger.Info($"{surname}{givenName}: {lifeRecords.Count}/{desiredCount}");
		List<LifeRecordRenderInfo> renderInfos = new List<LifeRecordRenderInfo>();
		ArgumentCollection argumentCollection = new ArgumentCollection();
		lifeRecords.GetRenderInfos(renderInfos, argumentCollection);
		foreach (LifeRecordRenderInfo info in renderInfos)
		{
			int year = info.Date / 12;
			int month = info.Date % 12;
			Logger.Info($"  {year + 1}年{month + 1}月: {info.Text}");
		}
	}

	private bool AddRandomLifeRecordInternal(DataContext context, LifeRecordCollection lifeRecords, GameData.Domains.Character.Character character, MapBlockData mapBlockData)
	{
		int randomIndex = context.Random.Next(_sourceRecordTemplateIds.Count);
		short recordTemplateId = _sourceRecordTemplateIds[randomIndex];
		LifeRecordItem config = Config.LifeRecord.Instance[recordTemplateId];
		string name = _templateId2Name[config.TemplateId];
		MethodInfo methodInfo = _lifeRecordCollectionType.GetMethod("Add" + name);
		Tester.Assert(methodInfo != null);
		List<object> arguments = new List<object>
		{
			character.GetId(),
			DomainManager.World.GetCurrDate()
		};
		int i = 0;
		for (int count = config.Parameters.Length; i < count; i++)
		{
			string paramName = config.Parameters[i];
			if (string.IsNullOrEmpty(paramName))
			{
				break;
			}
			sbyte paramType = ParameterType.Parse(paramName);
			if (!AddArguments(context.Random, arguments, paramType, character, mapBlockData))
			{
				return false;
			}
		}
		if (config.RelatedIds.Count > 1)
		{
			randomIndex = context.Random.Next(config.RelatedIds.Count);
			short relatedId = config.RelatedIds[randomIndex];
			arguments.Add(relatedId);
		}
		methodInfo.Invoke(lifeRecords, arguments.ToArray());
		return true;
	}

	private static bool AddArguments(IRandomSource random, List<object> arguments, sbyte paramType, GameData.Domains.Character.Character character, MapBlockData mapBlockData)
	{
		switch (paramType)
		{
		case 0:
		{
			int otherCharId2 = GetOtherCharacter(mapBlockData.CharacterSet, character.GetId());
			if (otherCharId2 < 0)
			{
				return false;
			}
			arguments.Add(otherCharId2);
			return true;
		}
		case 1:
		{
			Location location = character.GetLocation();
			if (!location.IsValid())
			{
				location = character.GetValidLocation();
			}
			arguments.Add(location);
			return true;
		}
		case 2:
			var (itemType, itemTemplateId) = GetItem(character);
			if (itemType < 0)
			{
				return false;
			}
			arguments.Add(itemType);
			arguments.Add(itemTemplateId);
			return true;
		case 3:
		{
			short combatSkillId = (short)random.Next(0, Config.CombatSkill.Instance.Count);
			arguments.Add(combatSkillId);
			return true;
		}
		case 4:
		{
			sbyte resourceType = (sbyte)random.Next(0, 8);
			arguments.Add(resourceType);
			return true;
		}
		case 5:
		{
			short settlementId = character.GetOrganizationInfo().SettlementId;
			if (settlementId < 0)
			{
				return false;
			}
			arguments.Add(settlementId);
			return true;
		}
		case 6:
		{
			OrganizationInfo orgInfo = character.GetOrganizationInfo();
			arguments.Add(orgInfo.OrgTemplateId);
			arguments.Add(orgInfo.Grade);
			arguments.Add(orgInfo.Principal);
			arguments.Add(character.GetGender());
			return true;
		}
		case 20:
		{
			if (mapBlockData.TemplateEnemyList == null || mapBlockData.TemplateEnemyList.Count == 0)
			{
				return false;
			}
			short randomEnemyId = mapBlockData.TemplateEnemyList[0].TemplateId;
			arguments.Add(randomEnemyId);
			return true;
		}
		case 21:
		{
			short templateId2 = (short)random.Next(CharacterFeature.Instance.Count);
			arguments.Add(templateId2);
			return true;
		}
		case 22:
		{
			int val = random.Next(100);
			arguments.Add(val);
			return true;
		}
		case 23:
		{
			short lifeSkillTemplateId = (short)random.Next(LifeSkill.Instance.Count);
			arguments.Add(lifeSkillTemplateId);
			return true;
		}
		case 24:
		{
			sbyte merchantType = (sbyte)random.Next(7);
			arguments.Add(merchantType);
			return true;
		}
		case 26:
		{
			sbyte combatType = (sbyte)random.Next(4);
			arguments.Add(combatType);
			return true;
		}
		case 27:
		{
			sbyte lifeSkillType = (sbyte)random.Next(16);
			arguments.Add(lifeSkillType);
			return true;
		}
		case 28:
		{
			sbyte combatSkillType = (sbyte)random.Next(14);
			arguments.Add(combatSkillType);
			return true;
		}
		case 29:
		{
			short infoTemplateId = (short)random.Next(Config.Information.Instance.Count);
			arguments.Add(infoTemplateId);
			return true;
		}
		case 30:
		{
			short secretInfoTemplateId = (short)random.Next(SecretInformation.Instance.Count);
			arguments.Add(secretInfoTemplateId);
			return true;
		}
		case 31:
		{
			short punishmentType = (short)random.Next(PunishmentType.Instance.Count);
			arguments.Add(punishmentType);
			return true;
		}
		case 32:
		{
			short characterTitle = (short)random.Next(CharacterTitle.Instance.Count);
			arguments.Add(characterTitle);
			return true;
		}
		case 33:
		{
			float floatValue = random.NextFloat();
			arguments.Add(floatValue);
			return true;
		}
		case 34:
		{
			int otherCharId = GetOtherCharacter(mapBlockData.CharacterSet, character.GetId());
			if (otherCharId < 0)
			{
				return false;
			}
			arguments.Add(otherCharId);
			return true;
		}
		case 35:
		{
			sbyte month = (sbyte)random.Next(Month.Instance.Count);
			arguments.Add(month);
			return true;
		}
		case 36:
		{
			int profession = random.Next(Profession.Instance.Count);
			arguments.Add(profession);
			return true;
		}
		case 37:
		{
			int professionSkill = random.Next(ProfessionSkill.Instance.Count);
			arguments.Add(professionSkill);
			return true;
		}
		case 38:
		{
			sbyte itemGrade = (sbyte)random.Next(9);
			arguments.Add(itemGrade);
			return true;
		}
		case 39:
			return false;
		case 40:
		{
			short music = (short)random.Next(Music.Instance.Count);
			arguments.Add(music);
			return true;
		}
		case 41:
		{
			sbyte state = (sbyte)random.Next(MapState.Instance.Count);
			arguments.Add(state);
			return true;
		}
		case 42:
			return false;
		case 43:
		{
			short jiaoProperty = (short)random.Next(Config.JiaoProperty.Instance.Count);
			arguments.Add(jiaoProperty);
			return false;
		}
		case 44:
		{
			sbyte destinyType = (sbyte)random.Next(DestinyType.Instance.Count);
			arguments.Add(destinyType);
			return true;
		}
		case 45:
		{
			short templateId = (short)random.Next(SecretInformation.Instance.Count);
			arguments.Add((templateId, -1));
			return true;
		}
		default:
			return false;
		}
	}

	private static int GetOtherCharacter(HashSet<int> charIds, int selfCharId)
	{
		if (charIds == null)
		{
			return -1;
		}
		foreach (int charId in charIds)
		{
			if (charId != selfCharId)
			{
				return charId;
			}
		}
		return -1;
	}

	private static (sbyte itemType, short itemTemplateId) GetItem(GameData.Domains.Character.Character character)
	{
		Inventory inventory = character.GetInventory();
		if (inventory.Items.Count > 0)
		{
			using (Dictionary<ItemKey, int>.Enumerator enumerator = inventory.Items.GetEnumerator())
			{
				enumerator.MoveNext();
				ItemKey itemKey = enumerator.Current.Key;
				return (itemType: itemKey.ItemType, itemTemplateId: itemKey.TemplateId);
			}
		}
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey2 = equipment[i];
			if (itemKey2.IsValid())
			{
				return (itemType: itemKey2.ItemType, itemTemplateId: itemKey2.TemplateId);
			}
		}
		return (itemType: -1, itemTemplateId: -1);
	}

	public LifeRecordDomain()
		: base(1)
	{
		_lifeRecord = 0;
		OnInitializedDomainData();
	}

	private int GetLifeRecord()
	{
		return _lifeRecord;
	}

	private void SetLifeRecord(int value, DataContext context)
	{
		_lifeRecord = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)0);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		int domainDataIndex = 0;
		if (domainDataIndex < savedFieldCount)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			ushort dataId = domainDataMeta.DataId;
			ushort num = dataId;
			throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(13);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		if (dataId == 0)
		{
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (dataId == 0)
		{
			throw new Exception($"Not allow to set value of dataId {dataId}");
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 3)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				int beginIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref beginIndex);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				uint operationId2 = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				Get(operationId2, charId4, beginIndex, count);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 3)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				int startDate = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startDate);
				int monthCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref monthCount);
				uint operationId5 = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				GetByDate(operationId5, charId7, startDate, monthCount);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				int count2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count2);
				uint operationId3 = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				GetLast(operationId3, charId5, count2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 4)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				int date = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref date);
				short recordType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref recordType);
				int relatedCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref relatedCharId);
				uint operationId4 = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				GetRelated(operationId4, charId6, date, recordType, relatedCharId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				uint operationId = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				GetDead(operationId, charId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				string key2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key2);
				RecordArgumentsRequest request2 = default(RecordArgumentsRequest);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref request2);
				ArgumentCollectionRenderArguments returnValue4 = GetRecordRenderInfoArguments(context, key2, request2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			case 3:
			{
				string key = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key);
				RecordArgumentsRequest request = default(RecordArgumentsRequest);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref request);
				bool isDreamBack2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isDreamBack2);
				ArgumentCollectionRenderArguments returnValue3 = GetRecordRenderInfoArguments(context, key, request, isDreamBack2);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 6:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				int startCount2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startCount2);
				int readCount2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref readCount2);
				TransferableLifeRecordData returnValue2 = GetReversedRecord(context, charId2, startCount2, readCount2);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			case 4:
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				int startCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startCount);
				int readCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref readCount);
				bool isDreamBack = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isDreamBack);
				TransferableLifeRecordData returnValue = GetReversedRecord(context, charId, startCount, readCount, isDreamBack);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		if (dataId == 0)
		{
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		if (dataId == 0)
		{
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		if (dataId == 0)
		{
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		if (dataId == 0)
		{
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		if (influence.TargetIndicator.DataId != 0)
		{
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		}
		throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
