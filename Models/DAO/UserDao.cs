using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace SCSDataBase.Models.DAO
{
    public class UserDao
    {
        public static void SaveUser(User user)
        {
            string sql = "INSERT INTO USER (name, email, password)" +
                         "VALUES (@name, @email, @password);";
            var parameter = new Dictionary<string, string>();
            parameter.Add("@name", user.Name);
            parameter.Add("@email", user.email);
            parameter.Add("@password", user.Password);
            DatabaseConnector.ExecuteNonQuery(sql, parameter);
           

        }

        public static User Login(User user)
        {
            string sql = "SELECT name, password, isAdmin FROM USER WHERE name=@name AND password =@password;";

            var parameter = new Dictionary<string,string>();
            parameter.Add("@name", user.Name);
            parameter.Add("@password", user.Password);
            var data = DatabaseConnector.ExecuteReader(sql, parameter);
            User user2 = new User(); //to check against the user object

            string Name = (string)data["name"];
            user2.Name = Name;

            string Password = (string) data["password"];
            user2.Password = Password;

            user2.isAdmin = (char) data["isAdmin"];
            if (user.Name.Equals(user2.Name) && user.Password.Equals(user2.Password))
            {
                    return user2;
               
            }
            else
            {
                return null;
            }

        }
    }
}