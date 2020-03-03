using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Bank.Models
{
    public class ProceduresDbContext
    {   
        // connection template
        //private string <anyName> = "User Id=<user_name>;Password=<Your password>;" + "Data Source=<Host Name>:<Port>/<SID>";

        private string connectionString;

        public ProceduresDbContext(IConfiguration config)
        {
            /// POSSIBLE CONNECTIONS 
            /// Data:LocalBankDB:ConnectionStrings
            /// Data:CentennialExternal:ConnectionStrings
            /// Data:CentennialLocal:ConnectionStrings
            connectionString = /* ----> */ config["Data:LocalBankDB:ConnectionStrings"]; // <---- CHANGE CONNECTION STRING HERE
        }

        //public Customer GetCustomerInfo(int id)
        //{
        //    if (id != 0)
        //    {
        //        Customer customer;
        //        OracleParameter cus_id = new OracleParameter();
        //        OracleParameter cur_customer = new OracleParameter();

        //        cus_id.ParameterName = "customer_id";
        //        cus_id.OracleDbType = OracleDbType.Int32;
        //        cus_id.Direction = ParameterDirection.Input;
        //        cus_id.Value = id;

        //        cur_customer.ParameterName = "cur_customer";
        //        cur_customer.OracleDbType = OracleDbType.RefCursor;
        //        cur_customer.Direction = ParameterDirection.Output;

        //        using (OracleConnection con = new OracleConnection(connectionString))
        //        {
        //            using (OracleCommand cmd = con.CreateCommand())
        //            {
        //                cmd.Parameters.Add(cus_id);
        //                cmd.Parameters.Add(cur_customer);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GET_CUSTOMER_INFO";

        //                try
        //                {
        //                    con.Open();
        //                    using (OracleDataReader reader = cmd.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            customer = new Customer();

        //                            while (reader.Read())
        //                            {
        //                                customer.CustomerID = Convert.ToUInt32(reader.GetInt32(reader.GetOrdinal("CUSTOMERID")));
        //                                customer.Name = reader.GetString(reader.GetOrdinal("NAME"));
        //                                customer.Address = new Address(
        //                                    reader.GetString(reader.GetOrdinal("ADDRESS")),
        //                                    reader.GetString(reader.GetOrdinal("CITY")),
        //                                    reader.GetString(reader.GetOrdinal("PROVINCE")),
        //                                    reader.GetString(reader.GetOrdinal("POSTALCODE"))
        //                                );
        //                                customer.Email = reader.GetString(reader.GetOrdinal("EMAIL"));
        //                                customer.Phone = reader.GetDecimal(reader.GetOrdinal("PHONE")).ToString();
        //                                customer.SinNumber = reader.GetDecimal(reader.GetOrdinal("SINNUMBER")).ToString();
        //                                customer.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            customer = null;
        //                        }
        //                    }
        //                }
        //                catch (Exception)
        //                {
        //                    throw;
        //                }
        //            }
        //        }

        //        return customer == null ? default(Customer) : customer;
        //    }
        //    else
        //        return default(Customer);
        //}
        
        //private void GetRepository()
        //{
        //    string command = "SELECT * FROM BANKCUSTOMER";

        //    using (OracleConnection con = new OracleConnection(connectionString))
        //    {
        //        try
        //        {
        //            using (OracleCommand cmd = con.CreateCommand())
        //            {
        //                con.Open();
        //                cmd.CommandText = command;

        //                using (OracleDataReader reader = cmd.ExecuteReader())
        //                {
        //                    try
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            Customer customer;

        //                            while (reader.Read())
        //                            {
        //                                customer = new Customer();

        //                                customer.CustomerID = Convert.ToUInt32(reader.GetInt32(reader.GetOrdinal("CUSTOMERID")));
        //                                customer.Name = reader.GetString(reader.GetOrdinal("NAME"));
        //                                customer.Address = new Address(
        //                                    reader.GetString(reader.GetOrdinal("ADDRESS")),
        //                                    reader.GetString(reader.GetOrdinal("CITY")),
        //                                    reader.GetString(reader.GetOrdinal("PROVINCE")),
        //                                    reader.GetString(reader.GetOrdinal("POSTALCODE"))
        //                                );
        //                                customer.Email = reader.GetString(reader.GetOrdinal("EMAIL"));
        //                                customer.Phone = reader.GetDecimal(reader.GetOrdinal("PHONE")).ToString();
        //                                customer.SinNumber = reader.GetDecimal(reader.GetOrdinal("SINNUMBER")).ToString();
        //                                customer.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
        //                                Customers.Add(customer);
        //                            }

        //                        }

        //                    }
        //                    catch (Exception)
        //                    {
        //                        throw;
        //                    }
        //                    finally
        //                    {
        //                        reader.Dispose();
        //                        reader.Close();
        //                        con.Close();
        //                    }
        //                }

        //            }
        //        }
        //        catch (TimeoutException e)
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        //public List<Account> GetAccounts(int id, out decimal totalBalance)
        //{
        //    List<Account> accounts = new List<Account>();

        //    OracleParameter cus_id = new OracleParameter();
        //    OracleParameter cur_customer = new OracleParameter();
        //    OracleParameter num_total = new OracleParameter();

        //    cus_id.ParameterName = "customer_id";
        //    cus_id.OracleDbType = OracleDbType.Int32;
        //    cus_id.Direction = ParameterDirection.Input;
        //    cus_id.Value = id;

        //    cur_customer.ParameterName = "cur_customer";
        //    cur_customer.OracleDbType = OracleDbType.RefCursor;
        //    cur_customer.Direction = ParameterDirection.Output;

        //    num_total.ParameterName = "total";
        //    num_total.OracleDbType = OracleDbType.Decimal;
        //    num_total.Direction = ParameterDirection.Output;

        //    using (OracleConnection con = new OracleConnection(connectionString))
        //    {
        //        using (OracleCommand cmd = con.CreateCommand())
        //        {
        //            cmd.Parameters.Add(cus_id);
        //            cmd.Parameters.Add(cur_customer);
        //            cmd.Parameters.Add(num_total);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "GET_ACCOUNTS_SP";

        //            try
        //            {
        //                con.Open();
        //                using (OracleDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        Account account;
        //                        AccountType type;
                                
        //                        totalBalance = decimal.Parse(num_total.Value.ToString());

        //                        while (reader.Read())
        //                        {
        //                            account = new Account();

        //                            account.AccountNumber = reader.GetInt32(reader.GetOrdinal("ACCOUNTNUMBER"));
        //                            account.ManagerId = reader.GetInt32(reader.GetOrdinal("MANAGERID"));
        //                            account.Balance = reader.GetDecimal(reader.GetOrdinal("BALANCE"));
        //                            Enum.TryParse(reader.GetString(reader.GetOrdinal("TYPENAME")), out type);
        //                            account.AccountType = type;

        //                            accounts.Add(account);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        totalBalance = 0;
        //                    }

        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.Message);
        //                throw;
        //            }
        //        }
        //    }

        //    return accounts;
        //}

        public bool AddTransaction(int customerId, int accountNumber, decimal amount)
        {
            OracleParameter cus_id = new OracleParameter();
            OracleParameter acc_num = new OracleParameter();
            OracleParameter amt = new OracleParameter();
            OracleParameter successful = new OracleParameter();

            cus_id.ParameterName = "customerid";
            cus_id.OracleDbType = OracleDbType.Int32;
            cus_id.Direction = ParameterDirection.Input;
            cus_id.Value = customerId;

            acc_num.ParameterName = "accountnumber";
            acc_num.OracleDbType = OracleDbType.Int32;
            acc_num.Direction = ParameterDirection.Input;
            acc_num.Value = accountNumber;

            amt.ParameterName = "amount";
            amt.OracleDbType = OracleDbType.Decimal;
            amt.Direction = ParameterDirection.Input;
            amt.Value = amount;

            successful.ParameterName = "isValid";
            successful.OracleDbType = OracleDbType.Int32;
            successful.Direction = ParameterDirection.Output;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand command = conn.CreateCommand())
                {
                    command.Parameters.Add(cus_id);
                    command.Parameters.Add(acc_num);
                    command.Parameters.Add(amt);
                    command.Parameters.Add(successful);
                    command.CommandText = "INSERT_TRANSACTION_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        return int.Parse(successful.Value.ToString()) == 1;
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Transaction failed");
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public int GetNumOfTransactions(int customerId)
        {
            int numOfTransactions;

            OracleParameter cus_id = new OracleParameter();
            OracleParameter total = new OracleParameter();

            cus_id.ParameterName = "customerid";
            cus_id.OracleDbType = OracleDbType.Int32;
            cus_id.Direction = ParameterDirection.Input;
            cus_id.Value = customerId;

            total.ParameterName = "total";
            total.OracleDbType = OracleDbType.Int32;
            total.Direction = ParameterDirection.Output;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand command = conn.CreateCommand())
                {
                    command.Parameters.Add(cus_id);
                    command.Parameters.Add(total);
                    command.CommandText = "GET_TOTAL_TRST_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        numOfTransactions = int.Parse(total.Value.ToString());

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }

            return numOfTransactions;
        }

        public bool AddAccount(int customerId, int branchId, int managerId, int accountType, decimal initial)
        {
            OracleParameter cus_id = new OracleParameter();
            OracleParameter branch_id = new OracleParameter();
            OracleParameter mng_id = new OracleParameter();
            OracleParameter acc_type = new OracleParameter();
            OracleParameter initial_amt = new OracleParameter();
            OracleParameter successful = new OracleParameter();

            cus_id.ParameterName = "customer_id";
            cus_id.OracleDbType = OracleDbType.Int32;
            cus_id.Direction = ParameterDirection.Input;
            cus_id.Value = customerId;

            branch_id.ParameterName = "branch_id";
            branch_id.OracleDbType = OracleDbType.Int32;
            branch_id.Direction = ParameterDirection.Input;
            branch_id.Value = branchId;

            mng_id.ParameterName = "manager_id";
            mng_id.OracleDbType = OracleDbType.Int32;
            mng_id.Direction = ParameterDirection.Input;
            mng_id.Value = managerId;

            acc_type.ParameterName = "account_type";
            acc_type.OracleDbType = OracleDbType.Int32;
            acc_type.Direction = ParameterDirection.Input;
            acc_type.Value = accountType;

            initial_amt.ParameterName = "initial_balance";
            initial_amt.OracleDbType = OracleDbType.Decimal;
            initial_amt.Direction = ParameterDirection.Input;
            initial_amt.Value = initial;

            successful.ParameterName = "isValid";
            successful.OracleDbType = OracleDbType.Int32;
            successful.Direction = ParameterDirection.Output;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand command = conn.CreateCommand())
                {
                    command.Parameters.Add(cus_id);
                    command.Parameters.Add(branch_id);
                    command.Parameters.Add(mng_id);
                    command.Parameters.Add(acc_type);
                    command.Parameters.Add(initial_amt);
                    command.Parameters.Add(successful);
                    command.CommandText = "NEW_ACCOUNT_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        return int.Parse(successful.Value.ToString()) == 1;
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Transaction failed");
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }
    }
}
