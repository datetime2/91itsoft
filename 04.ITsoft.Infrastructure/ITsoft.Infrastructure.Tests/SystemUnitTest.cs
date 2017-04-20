using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ITsoft.Infrastructure.Utility;
using ITsoft.Entity;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Repository.UnitOfWork;
using System.Linq;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Infrastructure.Tests
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
