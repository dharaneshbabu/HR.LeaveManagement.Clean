using HR.LeaveManagement.Api.Models;
using HR.LeaveManagement.Application.Exceptions;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace HR.LeaveManagement.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;

	public ExceptionMiddleware(RequestDelegate requestDelegate)
	{
		this._requestDelegate = requestDelegate;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _requestDelegate(httpContext);
		}
		catch (Exception ex)
		{

			await HandleExceptionAsync(httpContext, ex);
		}
	}

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

		CustomValidationProblemDetails problem = new();

		switch (ex)
		{
			case Application.Exceptions.BadRequestException badRequestException:
				statusCode = HttpStatusCode.BadRequest;
				problem = new CustomValidationProblemDetails
				{
					Title = badRequestException.Message,
					Status = (int)statusCode,
					Detail = badRequestException.InnerException?.Message,
					Type = nameof(SendGrid.Helpers.Errors.Model.BadRequestException),
					Errors = badRequestException.ValidationErrors
				};
				break;
			case Application.Exceptions.NotFoundException NotFound:
                statusCode = HttpStatusCode.NotFound;

                problem = new CustomValidationProblemDetails
				{
                    Title = NotFound.Message,
                    Status = (int)statusCode,
                    Detail = NotFound.InnerException?.Message,
                    Type = nameof(Application.Exceptions.NotFoundException)
                    //Errors = badRequestException.ValidationErrors
                };
                break;

			default:
                problem = new CustomValidationProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Detail = ex.InnerException?.Message,
                    Type = nameof(HttpStatusCode.InternalServerError)
                    //Errors = badRequestException.ValidationErrors
                };
                break;
		}

		httpContext.Response.StatusCode = (int) statusCode;

		await httpContext.Response.WriteAsJsonAsync(problem);
	}
}
