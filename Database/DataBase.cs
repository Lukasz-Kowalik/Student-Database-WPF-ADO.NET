using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using static Database.ShowGrades;

namespace Database
{
    internal static class DataBase
    {
        private static string DBConectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=P:\dev\Visual Studio programs\Database\Database\DataBase.mdf;Integrated Security=True";
        public static List<Student> SqlStudentSelect()
        {
            var students = new List<Student>();
            using (var connection = new SqlConnection(DBConectionString))
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = $"Select [StudentNo],[FirstName],[SurName],[Faculty] FROM [dbo].[Students]";

                cmd.CommandType = CommandType.Text;

                connection.Open();

                var res = cmd.ExecuteReader();

                while (res.Read())
                {
                    students.Add(new Student(res.GetString(2), res.GetString(1), res.GetInt32(0), res.GetString(3)));
                }
            }
            return students;
        }
        public static void SqlStudentInsert(Student student)
        {
            using (var connection = new SqlConnection(DBConectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"insert into [dbo].[Students] (StudentNo,Firstname,Surname,Faculty) values ('{student.StudentNo}','{student.FirstName}','{student.SurName}','{student.Faculty}');";
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public static List<T> SqlSelect<T>() where T : new()
        {
            var list = new List<T>();
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null) return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBCollAttribute>() != null).ToList();
            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBCollAttribute>().Name ?? p.Name}]").ToList();

            using (var db = new SqlConnection(DBConectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"Select {string.Join(",", names)}From [dbo].[{t.Name}s]";
                cmd.CommandType = CommandType.Text;
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var ob = new T();
                    int i = 0;
                    prop.ForEach(p => p.SetValue(ob, res[i++]));
                    list.Add(ob);
                }
            }
            return list;
        }

        public static List<T> SqlSelectByID<T>(object s) where T : new() 
        {
            //search id
            var objectType = s.GetType();
            var objectId = objectType.GetProperties().FirstOrDefault(x=>x.PropertyType==typeof(int));
            var valueId=objectId?.GetValue(s);
           
            var list = new List<T>();
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null) return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBCollAttribute>() != null).ToList();
            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBCollAttribute>().Name ?? p.Name}]").ToList();
         
            using (var db = new SqlConnection(DBConectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"Select {string.Join(",", names)}From [dbo].[{t.Name}s] Where {names[0]}={valueId}";
                cmd.CommandType = CommandType.Text;
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var ob = new T();
                    int i = 0;
                    prop.ForEach(p => p.SetValue(ob, res[i++]));
                    list.Add(ob);
                }
            }
            return list;
        }
    }

}