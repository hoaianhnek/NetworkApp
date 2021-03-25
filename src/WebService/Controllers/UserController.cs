using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Contract.Dtos;
using Core.Contract;
using Core.Enums;
using Core.Utility;
using log4net;
using WebService.DataProvider;
using WebService.DataValidator;
using static Contract.Dtos.SimpleValueDto;

namespace WebService.Controllers
{
    [RoutePrefix("webservice")]
    public class UserController : ApiController
    {
        protected static readonly ILog Logger = log4net.LogManager.GetLogger(typeof(UserController));
        private static readonly ValidatorHelper Validator = new ValidatorHelper();
        private readonly UserProvider _userProvider = new UserProvider();

        [HttpPost]
        [Route("users/register")]
        public IHttpActionResult UserRegister(UserDto request)
        {
            try
            {
                Validator.CheckMissingParamater("MobileNumber", request.MobilePhone);
                Validator.CheckMissingParamater("UserName", request.UserName);
                Validator.CheckMissingParamater("Password", request.Password);

                var result = _userProvider.UserRegister(request);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<UserDto> { 
                    ResponseCode = NResponseStatus.NotWriteData,
                    Message = NResponseStatus.NotWriteData.GetDescription()
                });
            }
        }
        
        [HttpPost]
        [Route("users/checkexisted")]
        public IHttpActionResult CheckCustomerExistedByMobileNumber(StringValueDto request)
        {
            try
            {
                var result = _userProvider.CheckExistedCustomerByMobileNumber(request.Value);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<UserDto>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
        [HttpPost]
        [Route("users/updatepassword")]
        public IHttpActionResult UserUpdatePassword(UserUpdatePasswordDto request)
        {
            try
            {
                var result = _userProvider.UserUpdatePassword(request);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<UserDto>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
        [HttpPost]
        [Route("users/login")]
        public IHttpActionResult UserLogin(UserLoginDto request)
        {
            try
            {
                var result = _userProvider.UserLogin(request);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
        [HttpPut]
        [Route("users/updateavatar")]
        public IHttpActionResult UpdateAvatar(AvatarProfileDto request)
        {
            try
            {
                var result = _userProvider.UpdateAvatar(request);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
        [HttpPut]
        [Route("users/updatecover")]
        public IHttpActionResult UpdateCoverImage(CoverImageProfileDto request)
        {
            try
            {
                var result = _userProvider.UpdateCoverImage(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
        [HttpPut]
        [Route("users/updateabout")]
        public IHttpActionResult UpdateAboutProfile(AboutProfileDto request)
        {
            try
            {
                var result = _userProvider.UpdateAboutProfile(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    
    }
}