using System.Collections.Generic;

namespace GameData.Utilities;

public class TempDictionaryContainer<TKey, TValue> : TempCollectionContainer<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
{
}
