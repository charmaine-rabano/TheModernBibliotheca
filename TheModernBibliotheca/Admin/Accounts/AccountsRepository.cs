using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca.Admin.Accounts
{
    public static class AccountsRepository
    {
        public static IEnumerable<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            string query = "SELECT Email, FirstName, LastName, DateCreated, AccountType FROM LibraryUser";
            foreach (DataRow row in DbHelper.ExecuteDataTableQuery(query).Rows)
            {
                accounts.Add(new Account
                {
                    EmailAddress = (string)row["Email"],
                    FirstName = (string)row["FirstName"],
                    LastName = (string)row["LastName"],
                    Password = (string)row["Password"],
                    UserType = (string)row["UserType"],
                    DateCreated = (DateTime)row["DateCreated"]
                });
            }
            return accounts;
        }

        public static Account GetAccount(int id)
        {
            string query = "SELECT Email, FirstName, LastName, DateCreated, AccountType FROM LibraryUser WHERE UserId = @UserId";
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", id)).Rows[0];
            return new Account
            {
                EmailAddress = (string)result["Email"],
                FirstName = (string)result["FirstName"],
                LastName = (string)result["LastName"],
                Password = (string)result["Password"],
                UserType = (string)result["UserType"],
                DateCreated = (DateTime)result["DateCreated"]
            };
        }

        public static void AddAccount(Account account)
        {
            string query = "INSERT INTO LibraryAccount(Email, FirstName, LastName, DateCreated, AccountPassword) VALUES (@Email, @FirstName, @LastName, @DateCreated, @AccountPassword)";
            DbHelper.ExecuteNonQuery(query,
                ("Email", account.EmailAddress),
                ("FirstName", account.FirstName),
                ("LastName", account.LastName),
                ("DateCreated", account.DateCreated),
                ("AccountPassword", account.Password));
        }


        public static void ModifyAccount(int userId, Account account)
        {
            string query = "UPDATE LibraryAccount SET Email = @Email, FirstName = @FirstName, LastName = @LastName, DateCreated = @DateCreated, AccountPassword = AccountPassword WHERE UserId = @UserId";
            DbHelper.ExecuteNonQuery(query,
                ("Email", account.EmailAddress),
                ("FirstName", account.FirstName),
                ("LastName", account.LastName),
                ("DateCreated", account.DateCreated),
                ("AccountPassword", account.Password),
                ("UserId", userId));
        }

        public static void DeleteAccount(int userId)
        {
            string query = "DELETE FROM LibraryAccount WHERE UserId = @UserId";
            DbHelper.ExecuteNonQuery(query, ("UserId", userId));
        }
    }
}