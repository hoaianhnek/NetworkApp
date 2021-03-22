using Contract.Dtos;
using Core.Contract;
using Core.Enums;
using Core.Utility;
using NetworkDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.DataProvider
{
    public class UserProvider
    {
        public Response<int> UserRegister(UserDto request)
        {
            var result = new Response<int>();
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                var user = new User() {
                    MobilePhone = request.MobilePhone,
                    Password = request.Password,
                    UserName = request.UserName,
                    StatusCurrent = 1,
                    TimeOnline = DateTime.Now,
                    Avatar = Utils.GetAppSettingBaseURL() + "/" + SharedPreferences.ImageUploadFolder + "/" + Utils.GetDefaultUserAvatar(),
                    CoverImage = Utils.GetAppSettingBaseURL() + "/" + SharedPreferences.ImageUploadFolder + "/" + Utils.GetDefaultUserCoverImage()
                };
                entities.Users.Add(user);
                entities.SaveChanges();
                result.Dto = user.Id;
                result.ResponseCode = NResponseStatus.Ok;
                result.Message = NResponseStatus.Ok.GetDescription();
            }
            return result;
        }
    
        public Response<UserDto> CheckExistedCustomerByMobileNumber(string mobilePhone)
        {
            var result = new Response<UserDto>();
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                var data = entities.Users.Where(u => u.MobilePhone == mobilePhone).OrderByDescending(u => u.Id).FirstOrDefault();
                if(data == null)
                {
                    return new Response<UserDto>
                    {
                        Dto = null,
                        ResponseCode = NResponseStatus.UserNotExisted,
                        Message = NResponseStatus.UserNotExisted.GetDescription()
                    };
                } else
                {
                    return new Response<UserDto>
                    {
                        Dto = null,
                        ResponseCode = NResponseStatus.UserExisted,
                        Message = NResponseStatus.UserExisted.GetDescription()
                    };
                }
            }
        }
    
        public Response<UserDto> UserUpdatePassword(UserUpdatePasswordDto request)
        {
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                var user = entities.Users.Where(u => u.MobilePhone == request.MobilePhone).FirstOrDefault();
                if(user == null)
                {
                    return new Response<UserDto>
                    {
                        ResponseCode = NResponseStatus.NotFoundResourceToProcess,
                        Message = NResponseStatus.NotFoundResourceToProcess.GetDescription()
                    };
                } else
                {
                    user.Password = request.Password;
                    user.StatusCurrent = 1;
                    user.TimeOnline = DateTime.Now;
                    entities.SaveChanges();
                    return new Response<UserDto>
                    {
                        Dto = new UserDto()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            MobilePhone = user.MobilePhone,
                            About = user.About,
                            Avatar = user.Avatar
                        },
                        ResponseCode = NResponseStatus.Ok,
                        Message = NResponseStatus.Ok.GetDescription()
                    };
                }
            }
        }
    
        public Response<UserDto> UserLogin(UserLoginDto request)
        {
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                var userEntity = entities.Users;
                var data = userEntity.Where(u => u.UserName == request.UserName && u.Password == request.Password)
                            .FirstOrDefault();
                if(data == null)
                {
                    return new Response<UserDto>
                    {
                        ResponseCode = NResponseStatus.Unauthorized,
                        Message = NResponseStatus.Unauthorized.GetDescription()
                    };
                } else
                {
                    data.StatusCurrent = 1;
                    data.TimeOnline = DateTime.Now;
                    entities.SaveChanges();
                    return new Response<UserDto>
                    {
                        Dto = new UserDto
                        {
                            Id = data.Id,
                            MobilePhone = data.MobilePhone,
                            UserName = data.UserName,
                            About = data.About,
                            Avatar = data.Avatar,
                            CoverImage = data.CoverImage
                        },
                        ResponseCode = NResponseStatus.Ok,
                        Message = NResponseStatus.Ok.GetDescription()
                    };
                }
            }
        }
    
        public Response<string> UpdateAvatar(AvatarProfileDto request)
        {
            using (DBNetworkEntities entities = new DBNetworkEntities())
            {
                //uploads image
                var imagePath = ImageUploader.UploadImage(Base64ImageUploader.GenerateImageFileName(request.Id.ToString()),
                    request.Avatar, NImageType.Avatar.GetDescription());
                var imageLink = imagePath.OrginalImage;
                var user = entities.Users.Where(u => u.Id == request.Id).FirstOrDefault();
                user.Avatar = imageLink;
                entities.SaveChanges();
                return new Response<string>
                {
                    Dto = imageLink,
                    ResponseCode = NResponseStatus.Ok,
                    Message = NResponseStatus.Ok.GetDescription()
                };
            }
        }

        public Response<string> UpdateCoverImage(CoverImageProfileDto request)
        {
            using (DBNetworkEntities entities = new DBNetworkEntities())
            {
                //uploads image
                var imagePath = ImageUploader.UploadImage(Base64ImageUploader.GenerateImageFileName(request.Id.ToString()),
                    request.CoverImage, NImageType.CoverImage.GetDescription());
                var imageLink = imagePath.OrginalImage;
                var user = entities.Users.Where(u => u.Id == request.Id).FirstOrDefault();
                user.CoverImage = imageLink;
                entities.SaveChanges();
                return new Response<string>
                {
                    Dto = imageLink,
                    ResponseCode = NResponseStatus.Ok,
                    Message = NResponseStatus.Ok.GetDescription()
                };
            }
        }

        public Response<string> UpdateAboutProfile(AboutProfileDto request)
        {
            using (DBNetworkEntities entities = new DBNetworkEntities())
            {
                var user = entities.Users.Where(u => u.Id == request.Id).FirstOrDefault();
                user.About = request.About;
                entities.SaveChanges();
                return new Response<string>
                {
                    Dto = request.About,
                    ResponseCode = NResponseStatus.Ok,
                    Message = NResponseStatus.Ok.GetDescription()
                };
            }
        }
    }
}