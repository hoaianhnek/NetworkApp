﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string Avatar { get; set; }
        public string CoverImage { get; set; }
    }
    public class UserUpdatePasswordDto
    {
        public string MobilePhone { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AvatarProfileDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
    }
    public class CoverImageProfileDto
    {
        public int Id { get; set; }
        public string CoverImage { get; set; }
    }
    public class AboutProfileDto
    {
        public int Id { get; set; }
        public string About { get; set; }
    }
}
