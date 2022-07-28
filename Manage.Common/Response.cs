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
            var response = new BaseResponse
            {
                success = true,
                message = "success",
                status = "200"
            };

            return response;
        }
        public static BaseResponse SuccessResponse(object item)
        {
            var response = new BaseResponse
            {
                success = true,
                message = "success",
                status = "200",
                item = item
            };
            return response;
        }
        public static BaseResponse DuplicateDataResponse(string message)
        {
            var response = new BaseResponse
            {
                success = false,
                status = "400",
                message = message
            };
            return response;
        }
        public static BaseResponse TokenInvalidResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                status = "401",
                message = "invalid token"
            };
            return response;
        }
        public static BaseResponse TokenExpirationResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                status = "402",
                message = "token expiration"
            };
            return response;
        }
        public static BaseResponse ForbiddenResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                message = "forbidden",
                status = "403"
            };
            return response;
        }
        public static BaseResponse NotFoundResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                status = "404",
                message = "Not found"
            };
            return response;
        }
        public static BaseResponse BadLoginResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                status = "405",
                message = "wrong username or password"
            };
            return response;
        }
        public static BaseResponse DataNullResponse()
        {
            var response = new BaseResponse
            {
                success = false,
                status = "406",
                message = "please fill all empty box"
            };
            return response;
        }
    }
}
