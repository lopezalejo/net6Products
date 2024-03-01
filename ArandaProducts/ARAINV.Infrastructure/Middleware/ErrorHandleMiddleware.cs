using ARAINV.Core.Exceptions.Api;
using ARAINV.Core.Exceptions.Core.Persistence;
using ARAINV.Core.Exceptions.Core.Validation;
using ARAINV.Infrastructure.Wrappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ARAINV.Infrastructure.Middleware
{
    public class ErrorHandleMiddleware : IMiddleware
    {
        public ErrorHandleMiddleware() { }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<string>() { Succeded = false, Message = ex?.Message };

                switch (ex)
                {
                    case ApiException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case ValidateException e:
                        response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        responseModel.Errors = e.ErrorsDictionary;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case EntityNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;

                }

                await response.WriteAsync(JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings()
                {
                    Culture = System.Globalization.CultureInfo.CurrentCulture,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    FloatParseHandling = FloatParseHandling.Decimal,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }
        }
    }
}
