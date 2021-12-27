using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;

public class MySQLManager : MonoBehaviour
{
	public static MySqlConnection dbConnection;
	public static MySQLManager Instance;
	public static Text SqlScentences;

	//连接服务器用的参数
	static string host = "bj-cynosdbmysql-grp-ryddfify.sql.tencentcdb.com";
	static string port = "22131";
	static string username = "root";
	static string pwd = "********";
	static string database = "travelsys";
	static string charSet = "utf8";
	public MySQLManager()
	{
		OpenSql();
	}

	/// <summary>
	/// 连接数据库
	/// </summary>
	public static void OpenSql()
	{
		try
		{
			string connectionString = string.Format("server = {0};port={1};database = {2};user = {3};password = {4};CharSet = {5};", host, port, database, username, pwd, charSet);
			Debug.Log(connectionString);
			dbConnection = new MySqlConnection(connectionString);
			dbConnection.Open();
            if (SqlScentences != null) { SqlScentences.text = "mysql> " + "已经与MySQL服务器建立连接：\n"+ connectionString; }
		}
		catch (Exception e)
		{
			if (SqlScentences != null) { SqlScentences.text = "mysql> " + "Error:服务器连接失败"; }
			throw new Exception("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());
		}
	}

	/// <summary>
	/// 关闭数据库连接
	/// </summary>
	public void Close()
	{
		if (dbConnection != null)
		{
			dbConnection.Close();
			dbConnection.Dispose();
			dbConnection = null;
			SqlScentences.text = "mysql> " + "已经与MySQL服务器断开连接";
		}
	}

	/// <summary>
	/// 查询
	/// </summary>
	/// <param name="tableName">表名</param>
	/// <param name="items"></param>
	/// <param name="col">字段名</param>
	/// <param name="operation">运算符</param>
	/// <param name="values">字段值</param>
	/// <returns>DataSet</returns>
	public static DataSet SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)
	{

		if (col.Length != operation.Length || operation.Length != values.Length)
			throw new Exception("col.Length != operation.Length != values.Length");

		StringBuilder query = new StringBuilder();
		query.Append("SELECT ");
		query.Append(items[0]);

		for (int i = 1; i < items.Length; ++i)
		{
			query.Append(", ");
			query.Append(items[i]);
		}

		query.Append(" FROM ");
		query.Append(tableName);
		query.Append(" WHERE 1=1");

		for (int i = 0; i < col.Length; ++i)
		{
			query.Append(" AND ");
			query.Append(col[i]);
			query.Append(operation[i]);
			query.Append("'");
			query.Append(values[i]);
			query.Append("' ");
		}
		SqlScentences.text = "mysql> " + query.ToString();
		Debug.Log(query.ToString());
		return ExecuteQuery(query.ToString());
	}

	/// <summary>
	/// 执行sql语句
	/// </summary>
	/// <param name="sqlString">sql语句</param>
	/// <returns></returns>
	public static DataSet ExecuteQuery(string sqlString)
	{
		SqlScentences.text = "mysql> " + sqlString;
		if (dbConnection.State == ConnectionState.Open)
		{
			DataSet ds = new DataSet();
			try
			{
				MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
				da.Fill(ds);
			}
			catch (Exception ee)
			{
				SqlScentences.text = "mysql> " + "<color=red>Error:" + ee.Message.ToString() + "</color>";
				StaticData.isError = true;
				throw new Exception("SQL:" + sqlString + "/n" + ee.Message.ToString());
			}
			finally
			{
			}
			return ds;
		}
		return null;
	}

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
			Destroy(this);
        }
		SqlScentences = transform.Find("Canvas/SqlScentences").GetComponent<Text>();
		OpenSql();
	}

	public void OnBtnBack()
    {
		SceneManager.LoadScene(0);
    }
}
