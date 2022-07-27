using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public static class Response
    {
        public static BaseResponse SuccessResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = true;
            response.message = "success";
            response.status = "200";
            return response;
        }
        public static BaseResponse SuccessResponse(object item)
        {
            BaseResponse response = new BaseResponse();
            response.success = true;
            response.message = "success";
            response.status = "200";
            return response;
        }
        public static BaseResponse DuplicateDataResponse(string message)
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.status = "400";
            response.message = message;
            return response;
        }
        public static BaseResponse TokenInvalidResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.status = "401";
            response.message = "invalid token";
            return response;
        }
        public static BaseResponse TokenExpirationResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.status = "402";
            response.message = "token expiration";
            return response;
        }
        public static BaseResponse ForbiddenResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.message = "forbidden";
            response.status = "403";
            return response;
        }
        public static BaseResponse NotFoundResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.status = "404";
            response.message = "Not found";
            return response;
        }
        public static BaseResponse BadLoginResponse()
        {
            BaseResponse response = new BaseResponse();
            response.success = false;
            response.status = "405";
            response.message = "wrong username or password";
            return response;
        }
        




    }
}
