﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Taarafo.Core.Models.PostReports;

namespace Taarafo.Core.Brokers.Storages
{
    public partial interface IStrorageBroker
    {
        IQueryable<PostReport> SelectAllPostReports();
        ValueTask<PostReport> SelectPostReportByIdAsync(Guid postReportId, Guid PostId, Guid ReporterId);
    }
}
