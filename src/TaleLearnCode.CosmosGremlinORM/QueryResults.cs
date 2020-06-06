using Gremlin.Net.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace TaleLearnCode.CosmosGremlinORM
{

	public class QueryResults
	{

		public List<dynamic> Results { get; } = new List<dynamic>();

		public int StatusCode { get; set; }

		public decimal RequestCharge { get; set; }

		public decimal ServerTime { get; set; }

		public QueryResults(ResultSet<dynamic> resultSet)
		{

			if (resultSet is null) throw new ArgumentNullException(nameof(resultSet));

			if (resultSet.Count > 0)
				foreach (var result in resultSet)
					Results.Add(JsonConvert.SerializeObject(result));

			StatusCode = Convert.ToInt32(GremlinQuery.GetValueAsString(resultSet.StatusAttributes, "x-ms-status-code"), NumberFormatInfo.InvariantInfo);
			RequestCharge = Convert.ToDecimal(GremlinQuery.GetValueAsString(resultSet.StatusAttributes, "x-ms-total-request-charge"), NumberFormatInfo.InvariantInfo);
			ServerTime = Convert.ToDecimal(GremlinQuery.GetValueAsString(resultSet.StatusAttributes, "x-ms-total-server-time-ms"), NumberFormatInfo.InvariantInfo);

		}


	}

}