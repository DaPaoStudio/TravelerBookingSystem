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

	//���ӷ������õĲ���
	static string host = "bj-cynosdbmysql-grp-ryddfify.sql.tencentcdb.com";
	static string port = "22131";
	static string username = "root";
	static string pwd = "Az6890mysql";
	static string database = "travelsys";
	static string charSet = "utf8";
	public MySQLManager()
	{
		OpenSql();
	}

	/// <summary>
	/// �������ݿ�
	/// </summary>
	public static void OpenSql()
	{
		try
		{
			string connectionString = string.Format("server = {0};port={1};database = {2};user = {3};password = {4};CharSet = {5};", host, port, database, username, pwd, charSet);
			Debug.Log(connectionString);
			dbConnection = new MySqlConnection(connectionString);
			dbConnection.Open();
            if (SqlScentences != null) { SqlScentences.text = "mysql> " + "�Ѿ���MySQL�������������ӣ�\n"+ connectionString; }
		}
		catch (Exception e)
		{
			if (SqlScentences != null) { SqlScentences.text = "mysql> " + "Error:����������ʧ��"; }
			throw new Exception("����������ʧ�ܣ������¼���Ƿ��MySql����" + e.Message.ToString());
		}
	}

	/// <summary>
	/// �ر����ݿ�����
	/// </summary>
	public void Close()
	{
		if (dbConnection != null)
		{
			dbConnection.Close();
			dbConnection.Dispose();
			dbConnection = null;
			SqlScentences.text = "mysql> " + "�Ѿ���MySQL�������Ͽ�����";
		}
	}

	/// <summary>
	/// ��ѯ
	/// </summary>
	/// <param name="tableName">����</param>
	/// <param name="items"></param>
	/// <param name="col">�ֶ���</param>
	/// <param name="operation">�����</param>
	/// <param name="values">�ֶ�ֵ</param>
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
	/// ִ��sql���
	/// </summary>
	/// <param name="sqlString">sql���</param>
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
