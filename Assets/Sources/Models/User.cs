using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Models
{
    [System.Serializable]
    public class User
    {
        public string Name;
        public int Age;
		public Address Address;
		public List<Trade> Trades;
    }

	[System.Serializable]
	public class Address
	{
		public string Name;
		public string PostCode;
	}

	[System.Serializable]
	public class Trade
	{
		public string Name{ get; set; }
	}

	/// <summary>
	/// 仓储内的响应对象
	/// </summary>
	public class Response<T>
	{
		public bool Success { get { return Error == null; } }
		public string Error { get; private set; }
		public T Item { get; set; }
		public List<T> Items { get; set; }

		public Response(string error)
		{
			Error = error;
		}

		public Response(T item, string error)
		{
			Item = item;
			Error = error;
		}

		public Response(List<T> items, string error)
		{
			Items = items;
			if (Items != null && Items.Count == 1)
			{
				Item = Items[0];
			}
			Error = error;
		}
	}

	public abstract class RestResponse
	{
		public string Error { get; set; }
		public abstract List<T> ToList<T>() where T : class;
		public abstract T ToItem<T>() where T : class;

		public RestResponse()
		{
		}
	}

	public class UserResponse:RestResponse
	{
		public override T ToItem<T> ()
		{
			throw new NotImplementedException ();
		}

		public override List<T> ToList<T> ()
		{
			throw new NotImplementedException ();
		}
	}
}
