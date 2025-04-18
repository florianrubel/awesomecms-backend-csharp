﻿namespace LibDb.Models.Api
{
    public interface IPagedList
    {
        int Page { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; set; }
        int TotalCount { get; set; }
    }
}
