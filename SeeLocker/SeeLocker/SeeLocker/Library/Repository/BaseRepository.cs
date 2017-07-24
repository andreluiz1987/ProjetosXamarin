using SeeLocker.Library.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeeLocker.Library.Repository
{
    public class BaseRepository
    {
        #region Variáveis
        protected SQLiteConnection objSqlConnection;
        #endregion

        #region Métodos
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        public BaseRepository()
        {
            var objConfiguration = DependencyService.Get<IConfiguration>();
            objSqlConnection = new SQLiteConnection(objConfiguration.PlatformDevice, System.IO.Path.Combine(objConfiguration.Directory, "user_locker.db3"));
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="obj">Object.</param>
        public void CreateTable<T>()
        {
            if (objSqlConnection != null)
            {
                objSqlConnection.CreateTable<T>();
            }
        }

        /// <summary>
        /// Existses the table.
        /// </summary>
        /// <returns><c>true</c>, if table was existsed, <c>false</c> otherwise.</returns>
        public bool ExistsTable(Type objType)
        {
            bool blnResult;
            SQLiteCommand objSqlCommmand;

            try
            {
                // Executa a pesquisa
                objSqlCommmand = objSqlConnection.CreateCommand("SELECT name FROM sqlite_master WHERE type='table' AND name=?", objType.Name);

                // Se existe a tabela cadastrada
                blnResult = (objSqlCommmand.ExecuteScalar<string>() != null);
            }
            catch (Exception ex)
            {
                // Define o resultado como falso
                blnResult = false;
            }

            return blnResult;
        }

        /// <summary>
        /// Close this instance.
        /// </summary>
        public void Close()
        {
            if (objSqlConnection != null)
            {
                objSqlConnection.Close();
            }
        }

        /// <summary>
        /// Insert the specified objIntanceTable.
        /// </summary>
        /// <param name="objIntanceTable">Object intance table.</param>
        public void Insert(object objTable)
        {
            if (objSqlConnection != null)
            {
                objSqlConnection.Insert(objTable);
            }
        }

        /// <summary>
        /// Update the specified objIntanceTable.
        /// </summary>
        /// <param name="objIntanceTable">Object intance table.</param>
        public void Update(object objTable)
        {
            if (objSqlConnection != null)
            {
                objSqlConnection.Update(objTable);
            }
        }

        /// <summary>
        /// Delete this instance.
        /// </summary>
        public void Delete(object objTable)
        {
            if (objSqlConnection != null)
            {
                objSqlConnection.Delete(objTable);
            }
        }

        public int DeleteAll(Type objType)
        {
            int value = 0;

            if (objSqlConnection != null)
            {
                value = objSqlConnection.DeleteAll(objType);
            }

            return value;
        }
        #endregion
    }
}