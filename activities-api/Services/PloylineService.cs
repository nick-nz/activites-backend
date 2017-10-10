using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace activities_api.Services
{
  public class PolylineService
  {
    private SqlConnection connection;

    public PolylineService()
    {
      this.connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Activities"].ConnectionString);
    }

    public IEnumerable<String> GetPolylines(string type)
    {
      var polylines = this.connection.Query<String>(
        @"SELECT TOP 100 Polyline FROM dbo.Activities WHERE Type = @type ORDER BY StartDateLocal DESC",
        new { type = type });
      var escaped = polylines.Select(p => p.Replace(@"\", "\\"));
      return escaped;
    }
  }
}
