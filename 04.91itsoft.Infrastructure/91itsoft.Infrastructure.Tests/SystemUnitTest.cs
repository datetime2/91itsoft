using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using _91itsoft.Infrastructure.Utility;
using _91itsoft.Entity;
using _91itsoft.Infrastructure.Utility.Helper;
using _91itsoft.Repository.UnitOfWork;
using System.Linq;
using _91itsoft.Domain.Aggregates;

namespace _91itsoft.Infrastructure.Tests
{
    [TestClass]
    public class SystemUnitTest
    {
        [TestMethod]
        public void AddAdmin()
        {
            var sw = new Stopwatch();
            TimeSpan timeCost;

            using (var unitOfWork = new TSoftUnitOfWork())
            {
                sw.Start();

                #region AddOrUpdate

                const string loginName = "admin";
                const string password = "123456";

                var user = unitOfWork.Users.FirstOrDefault(x => x.LoginName.Equals(loginName));

                if (user == null)
                {
                    user = new User()
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name = "管理员",
                        LoginName = loginName,
                        LoginPwd = SecurityHelper.EncryptPassword(password),
                        Created = DateTime.UtcNow,
                        LastLogin = Const.SqlServerNullDateTime
                    };

                    unitOfWork.Users.Add(user);
                }
                else
                {
                    user.Name = "管理员";
                    user.LoginPwd = SecurityHelper.EncryptPassword(password);
                    user.Created = DateTime.UtcNow;
                }

                #endregion

                unitOfWork.DbContext.SaveChanges();

                sw.Stop();
                timeCost = sw.Elapsed;
            }

            Console.WriteLine("Elapsed: " + timeCost.Ticks);
        }
    }
}
