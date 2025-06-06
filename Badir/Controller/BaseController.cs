using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
// using Badir.Dto.MatchingReport;
using Microsoft.AspNetCore.Mvc;

// using FileResult = MangaA.Dto.Files.FileResult;

namespace Badir.Controller;

public class BaseController : ControllerBase
{
    protected int Id => int.TryParse(GetClaim("Id"), out var id) ? id : -1;
    protected string UserName => GetClaim(ClaimTypes.Name) ?? "";

    protected string Role => GetClaim("Role");


    protected virtual string GetClaim(string claimName)
    {
        var claims = (User.Identity as ClaimsIdentity)?.Claims;
        var claim = claims?.FirstOrDefault(c =>
            string.Equals(c.Type, claimName, StringComparison.CurrentCultureIgnoreCase) &&
            !string.Equals(c.Type, "null", StringComparison.CurrentCultureIgnoreCase));
        var rr = claim?.Value!.Replace("\"", "");

        return rr ?? "";
    }


    protected ObjectResult OkObject<T>((T? data, string? error) result)
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(result.data);
    }


    protected ObjectResult Ok<T>((List<T>? data, int? totalCount, string? error) result,
        int pageNumber = 0, int pageSize = 10
    )
    {
        return result.error != null 
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(new Response<T>
            {
                Data = result.data,
                PagesCount = (result.totalCount + pageSize - 1) / pageSize,
                CurrentPage = pageNumber,
                TotalCount = result.totalCount ?? 0,
                IsLast = pageNumber >= (result.totalCount + pageSize - 1) / pageSize
            });
    }


    protected ObjectResult Ok<T>((T obj, string? error) result)
    {
        return result.error != null 
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(result.obj);
    }

    protected ObjectResult Ok<T,D>((List<T>? data, D? Details, int? totalCount, string? error) result,
        int pageNumber = 0, int pageSize = 10
    )
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(new ResponseWithDetails<T, D>()
            {
                Data = result.data,
                Details = result.Details,
                PagesCount = (result.totalCount + pageSize - 1) / pageSize,
                CurrentPage = pageNumber,
                TotalCount = result.totalCount ?? 0,
                IsLast = pageNumber >= (result.totalCount + pageSize - 1) / pageSize
            });
    }

}