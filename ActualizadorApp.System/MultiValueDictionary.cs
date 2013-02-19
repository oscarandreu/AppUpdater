using System;
using System.Collections.Generic;
using System.Text;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	public class MultiValueDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
	{

		public void Add(TKey key, TValue value)
		{
			if (!ContainsKey(key))
				Add(key, new List<TValue>());
			this[key].Add(value);
		}

		public List<TValue> GetValues(TKey key)
		{
			bool gotIt = false;
			foreach (TKey k in Keys)
			{
				if (k.Equals(key))
				{
					gotIt = true;
					break;
				}

			}
			if (gotIt)
				return this[key];

			return null;
		}

		public List<TValue> GetAllValues()
		{
			List<TValue> list = new List<TValue>();

			foreach (TKey key in this.Keys)
			{
				List<TValue> values = this.GetValues(key);
				list.AddRange(values);
			}

			return list;
		}

		public bool Contains(TKey key, TValue value)
		{
			List<TValue> vals = GetValues(key);
			if (vals != null && vals.Contains(value))
				return true;

			return false;
		}
	}

}

