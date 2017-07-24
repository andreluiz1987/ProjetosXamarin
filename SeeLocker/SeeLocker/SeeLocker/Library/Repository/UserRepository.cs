using SeeLocker.Library.Repository.Table;
using SeeLocker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLocker.Library.Repository
{
    public class UserRepository : BaseRepository
    {
        public void CreateTable()
        {
            CreateTable<UserTable>();
        }

        public bool ExistsTable()
        {
            return ExistsTable(typeof(UserTable));
        }

        public List<UserModel> GetAll(DateTime InitialDate, DateTime EndDate)
        {
            List<UserModel> lstUser;

            try
            {
                lstUser = new List<UserModel>();

                if (InitialDate.Year <= 1 && EndDate.Year <= 1)
                {
                    lstUser = GetAll();
                }
                else if(!(InitialDate.Year <= 1) && !(EndDate.Year <= 1)){
                    lstUser = GetsAll(InitialDate, EndDate);
                }
                else if (!(InitialDate.Year <= 1) && EndDate.Year <= 1)
                {
                    lstUser = GetAllInitialDate(InitialDate);
                }
                else
                {
                    lstUser = GetAllEndDate(EndDate);
                }
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser;
        }

        public UserModel GetLasted()
        {
            UserModel onUser;
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable ORDER BY ID DESC LIMIT 1";

                lstUser = objSqlConnection.Query<UserModel>(strQuery);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            onUser = (lstUser.Count > 0 ? lstUser[0] : new UserModel());

            return onUser;
        }

        public List<UserModel> GetsAll(DateTime InitialDate, DateTime EndDate)
        {
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable WHERE (LockDate > ? AND LockDate < ?)) ORDER BY LockDate DESC LIMIT 50";

                var parameters = new object[] { InitialDate, EndDate};

                lstUser = objSqlConnection.Query<UserModel>(strQuery, parameters);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser;
        }

        public List<UserModel> GetAllInitialDate(DateTime InitialDate)
        {
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable WHERE LockDate >= ? ORDER BY LockDate DESC LIMIT 50";
                
                lstUser = objSqlConnection.Query<UserModel>(strQuery, InitialDate);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser;
        }

        public List<UserModel> GetAllEndDate(DateTime EndDate)
        {
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable WHERE LockDate < ? ORDER BY LockDate DESC LIMIT 50";
                
                lstUser = objSqlConnection.Query<UserModel>(strQuery, EndDate);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser;
        }

        public int GetCount()
        {
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable";

                lstUser = objSqlConnection.Query<UserModel>(strQuery);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser.Count;
        }

        public List<UserModel> GetAll()
        {
            List<UserModel> lstUser;
            string strQuery = "";

            try
            {
                lstUser = new List<UserModel>();

                strQuery = "SELECT * FROM UserTable ORDER BY LockDate DESC LIMIT 50 ";
  
                lstUser = objSqlConnection.Query<UserModel>(strQuery);
            }
            catch (Exception ex)
            {
                lstUser = null;
            }

            return lstUser;
        }

        public void Delete()
        {
            DeleteAll(typeof(UserTable));
        }

        private UserModel LoadInstanceModel(UserTable onUserTable)
        {
            return new UserModel()
            {
                ID = onUserTable.ID,
                LockDate = onUserTable.LockDate,
                LockDateCurrent = onUserTable.LockDateCurrent,
                FileName = onUserTable.FileName
            };
        }
    }
}

