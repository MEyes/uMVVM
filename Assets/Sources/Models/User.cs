using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Repository;

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
	    public string Name;
	}

}
