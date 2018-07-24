using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCSDataBase.Models.DAO
{
    public class DataBaseDao
    {
        /**
         * Gets all the data from the DB, returns a list of approved links
         */
        public static List<DataBase> getAll()
        {
            string query = "SELECT URL, Description, Category FROM Data WHERE isApproved = 'y';";
            var data = DatabaseConnector.ExecuteReader(query);
            var dataout = new List<DataBase>();
            while (data.Read())
            {
                var dataObj = new DataBase();

                string category = (string)data["category"];
                dataObj.category = category;

                string url = (string)data["url"];
                dataObj.URL = url;

                string description = (string)data["description"];
                dataObj.description = description;


                dataout.Add(dataObj);
            }
            return dataout;
            //List Object of approved links

        }
       /**
        * Will input a new Link to the database for admin approval, no return type
        */
        public static void NewLink(DataBase data)
        { 

            string query = "INSERT INTO Data ( URL, category, Description)"
                           +
                           "VALUES(@URL, @Category, @Description);";
            var parameter = new Dictionary<string, string>();
            parameter.Add("@URL", data.URL);
            parameter.Add("@Category", data.category);
            parameter.Add("@Description", data.description);
            DatabaseConnector.ExecuteNonQuery(query, parameter);
        }
        /*
         * Allows For Admins to Approve Data for the database, no return type
         */
        public static void ApproveLink(DataBase data)
        {
            string query = "UPDATE Data SET isApproved = 'y' WHERE URL = @URL;";
            var parameter = new Dictionary<string, string>();
            parameter.Add("@URL", data.URL);
            DatabaseConnector.ExecuteNonQuery(query, parameter);
        }
        /*
         * Allows Admins to remove unrelated or garbage links
         */
        public static void RemoveLink(DataBase data)
        {
            string query = "REMOVE FROM [dbo].[Data] WHERE id = @ID;";
            var parameter = new Dictionary<string, string>();
            parameter.Add("@ID", data.id.ToString());
            DatabaseConnector.ExecuteNonQuery(query, parameter);
        }
        /*
         * Searches approved data by Category returns a list of data
         */
        public static List<DataBase> SearchByCategory(string category)
        {
            string sql = "SELECT * FROM DATA WHERE CATEGORY = @category";
            var parameter = new Dictionary<string, string>();
            parameter.Add("@category", category);
            var data = DatabaseConnector.ExecuteReader(sql, parameter);

            var dataout = new List<DataBase>();
            while (data.Read())
            {
                int i = 0;
                dataout[i].URL = (string) data["URL"];

                dataout[i].category = (string) data["Category"];

                dataout[i].description = (string) data["desctiption"];

                i++;
            }
            return dataout;

        }
        
        public static List<DataBase> unapproved()
        {
            string sql = "SELECT * FROM DATA WHERE isApproved = 'n';";
            var data = DatabaseConnector.ExecuteReader(sql);

            var dataout = new List<DataBase>();
            while (data.Read())
            {
                var dataObj = new DataBase();

                string category = (string)data["category"];
                dataObj.category = category;

                string url = (string)data["url"];
                dataObj.URL = url;

                string description = (string)data["description"];
                dataObj.description = description;


                dataout.Add(dataObj);
            }
            return dataout;
        }
    }
}