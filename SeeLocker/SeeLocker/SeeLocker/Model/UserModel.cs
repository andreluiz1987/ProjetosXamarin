using SeeLocker.Library.Repository;
using SeeLocker.Library.Repository.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLocker.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string LockDateCurrent { get; set; }
        public DateTime LockDate { get; set; }
        public string FileName { get; set; }
        public string LockDateString
        {
            get { return string.Format("Desbloqueado em: " + LockDateCurrent); }
        }
        public enum SaveType
        {
            Insert,
            Update
        }

        public override string ToString()
        {
            return string.Format("Desbloqueado em: " + LockDate);
        }

        public bool Save(SaveType objSaveType)
        {
            int numValue;
            bool blnResult = false;
            UserTable objUserTable;
            UserRepository objUserRepository;

            objUserRepository = new UserRepository();

            try
            {
                objUserTable = LoadInstanceTableObject();

                numValue = ControlModel.RefDate.Subtract(objUserTable.LockDate).Seconds;

                if (numValue > 0)
                {
                    if (objSaveType == SaveType.Insert)
                    {
                        objUserRepository.Insert(objUserTable);
                    }
                    else
                    {
                        objUserRepository.Update(objUserTable);
                    }

                    ControlModel.RefDate = Convert.ToDateTime(objUserTable.LockDate);
                }
                else {
                    ControlModel.RefDate = DateTime.MaxValue;
                }

                blnResult = true;

            }
            catch (Exception ex)
            {
                objUserRepository.Close();
            }

            return blnResult;
        }

        public static List<UserModel> GetAllUser(DateTime InitialDate, DateTime EndDate)
        {
            List<UserModel> lstUser;
            UserRepository objUserRepository;

            lstUser = new List<UserModel>();

            objUserRepository = new UserRepository();

            try
            {
                lstUser = objUserRepository.GetAll(InitialDate, EndDate);
            }
            catch (Exception ex)
            {
                objUserRepository.Close();
            }

            return lstUser;
        }

        public static int DeleteAll()
        {
            int numReturn = 0;

            UserRepository objRepo = new UserRepository();
            try
            {
                numReturn = objRepo.DeleteAll(typeof(UserTable));
            }
            catch (Exception)
            {
            }
            return numReturn;
        }

        private UserTable LoadInstanceTableObject()
        {
            return new UserTable()
            {
                ID = ID,
                LockDate = LockDate,
                FileName = FileName,
                LockDateCurrent = LockDateCurrent
            };
        }
    }
}
