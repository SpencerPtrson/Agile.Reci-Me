using Microsoft.EntityFrameworkCore.Storage;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public static class UserManager
    {
        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        if ((user.Email == "john.yang9556@fvtc.edu" || user.Email == "byron.baker5104@fvtc.edu" ||
                            user.Email == "spencer.peterson0728@fvtc.edu" || user.Email == "maxwell.wilke3555@fvtc.edu" ||
                            user.Email == "abigail.proudlock0180@fvtc.edu") && user.Password == "Agile")
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("User Name could not be found.");
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
