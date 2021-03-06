﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ITsoft.Infrastructure.Utility;
using ITsoft.Entity;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Repository.UnitOfWork;
using System.Linq;
using ITsoft.Domain.Aggregates;
using System.Collections.Generic;

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
                string salt = Guid.NewGuid().ToString();
                if (user == null)
                {
                    user = new User()
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name = "管理员",
                        LoginName = loginName,
                        LoginPwd = SecurityHelper.Md5(SecurityHelper.Md5(password) + salt),
                        Created = DateTime.UtcNow,
                        LastLogin = Const.SqlServerNullDateTime,
                        PwdSalt = salt
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



        [TestMethod]
        public void AddMenu()
        {
            try
            {
                using (var unitOfWork = new TSoftUnitOfWork())
                {

                    var baseList = new List<Menu> {
                    new Menu
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name="产品管理",
                         Created=DateTime.Now,Code="0001"
                    },
                     new Menu
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name="订单管理",
                         Created=DateTime.Now,Code="0002"
                    },
                      new Menu
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name="会员管理",
                         Created=DateTime.Now,Code="0003"
                    },
                       new Menu
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name="系统管理",
                         Created=DateTime.Now,Code="0004"
                    }
                };
                    var childList = new List<Menu>();
                    baseList.ForEach(s=>
                    {
                        switch (s.Name)
                        {
                            case "产品管理":
                                childList.AddRange(new List<Menu> {
                                  new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        ParentId=s.Id,
                                        Name="产品列表",
                                         Created=DateTime.Now,Code=s.Code+"01"
                                    },
                                       new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        Name="产品分类",
                                        ParentId=s.Id,
                                         Created=DateTime.Now,Code=s.Code+"02"
                                    }
                                });
                                break;
                            case "订单管理":
                                childList.AddRange(new List<Menu> {
                                  new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        ParentId=s.Id,
                                        Name="订单列表",
                                         Created=DateTime.Now,Code=s.Code+"01"
                                    },
                                       new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        Name="支付方式",
                                        ParentId=s.Id,
                                         Created=DateTime.Now,Code=s.Code+"02"
                                    }
                                });
                                break;
                            case "会员管理":
                                childList.AddRange(new List<Menu> {
                                  new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        ParentId=s.Id,
                                        Name="会员列表",
                                         Created=DateTime.Now,Code=s.Code+"01"
                                    },
                                       new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        Name="会员等级",
                                        ParentId=s.Id,
                                         Created=DateTime.Now,Code=s.Code+"02"
                                    }
                                });
                                break;
                            case "系统管理":
                                childList.AddRange(new List<Menu> {
                                  new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        ParentId=s.Id,
                                        Name="系统配置",
                                         Created=DateTime.Now,Code=s.Code+"01"
                                    },
                                       new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        Name="系统角色",
                                        ParentId=s.Id,
                                         Created=DateTime.Now,Code=s.Code+"02"
                                    },
                                        new Menu
                                    {
                                        Id = IdentityGenerator.NewSequentialGuid(),
                                        Name="系统菜单",
                                        ParentId=s.Id,
                                         Created=DateTime.Now,Code=s.Code+"03"
                                    }
                                });
                                break;
                        }
                    });
                    unitOfWork.Menus.AddRange(baseList.Concat(childList));
                    unitOfWork.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void AddRole()
        {
            var sw = new Stopwatch();
            TimeSpan timeCost;

            using (var unitOfWork = new TSoftUnitOfWork())
            {
                sw.Start();

                #region AddOrUpdate

                const string roleName = "超级管理员";

                var role = unitOfWork.Roles.FirstOrDefault(x => x.Name.Equals(roleName));
                string salt = Guid.NewGuid().ToString();
                if (role == null)
                {
                    role = new Role()
                    {
                        Id = IdentityGenerator.NewSequentialGuid(),
                        Name = roleName,
                        Created = DateTime.UtcNow,
                        IsEnable=true
                    };
                    unitOfWork.Roles.Add(role);
                }
                else
                {
                    role.Name = "超级管理员";
                    role.Created = DateTime.UtcNow;
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
