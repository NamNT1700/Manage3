﻿using Manage.Model.DTO.User;
using Manage.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public class UserCreateAndUpdate
    {
        public static UserInfoCreate GetUserInfoCreate(TokenDecode tokenDecode)
        {
            UserInfoCreate userInfoCreate = new UserInfoCreate();
            userInfoCreate.ActiveFlg = "A";
            userInfoCreate.CreatedBy = userInfoCreate.LastUpdatedBy = tokenDecode.username;
            userInfoCreate.CreatedTime = userInfoCreate.LastUpdateTime = DateTime.UtcNow;
            return userInfoCreate;
        }
        public static UserInfoCreate GetUserInfoUpdate(TokenDecode tokenDecode)
        {
            UserInfoCreate userInfoCreate = new UserInfoCreate();
            userInfoCreate.LastUpdatedBy = tokenDecode.username;
            userInfoCreate.LastUpdateTime = DateTime.UtcNow;
            return userInfoCreate;
        }
    }
    public class UserInfoCreate
    {
        public string ActiveFlg { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
    public class UserInfoUpdate
    {
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}