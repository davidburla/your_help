﻿using System.Data;
using System.Configuration;
using System;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
  /// <summary>
  /// contine metode generice de interogare, respectiv actualizare a bazei de date
  /// </summary>
  public static class SqlDBHelper
  {
    private const int EROARE_LA_EXECUTIE = 0;

    private static string _connectionString = null;
    public static string ConnectionString
    {
      get
      {
        if (string.IsNullOrEmpty(_connectionString))
        {
          _connectionString = ConfigurationManager.AppSettings.Get("StringConectare_BD_SQLServer");
        }
        return _connectionString;
      }
    }

    /// <summary>
    /// executa o instructiune de tip SELECT
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="cmdType"></param>
    /// <param name="parameters"></param>
    /// <returns>returneaza valorile primite ca un obiect generic de tip 'DataSet'</returns>
    public static DataSet ExecuteDataSet(string sql, CommandType cmdType, params SqlParameter[] parameters)
    {
      using (DataSet ds = new DataSet())
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
          cmd.CommandType = cmdType;
          foreach (var item in parameters)
          {
            cmd.Parameters.Add(item);
          }

          try
          {
            new SqlDataAdapter(cmd).Fill(ds);
          }
          catch (SqlException ex)
          {
            //salveaza exceptii in fisiere log
          }
          return ds;
        }
      }
    }

    /// <summary>
    /// executa instructiuni INSERT/UPDATE/DELETE
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="cmdType"></param>
    /// <param name="parameters"></param>
    /// <returns> returneaza 'true' daca instructiunea a fost executata cu success</returns>
    public static bool ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] parameters)
    {
      int rezult = EROARE_LA_EXECUTIE;
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
          cmd.CommandType = cmdType;
          foreach (var item in parameters)
          {
            cmd.Parameters.Add(item);
          }

          try
          {
            cmd.Connection.Open();
            rezult = cmd.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            //salveaza exceptii in fisiere log
            Console.WriteLine(ex.Message);
          }
        }
      }
      return Convert.ToBoolean(rezult);
    }
  }
}
