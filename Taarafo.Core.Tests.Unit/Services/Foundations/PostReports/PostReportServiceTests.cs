﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Linq;
using Moq;
using Taarafo.Core.Brokers.DateTimes;
using Taarafo.Core.Brokers.Loggings;
using Taarafo.Core.Brokers.Storages;
using Taarafo.Core.Models.PostReports;
using Taarafo.Core.Services.Foundations.PostReports;
using Tynamix.ObjectFiller;

namespace Taarafo.Core.Tests.Unit.Services.Foundations.PostReports
{
    public partial class PostReportServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokermock;
        private readonly IPostReportService postReportService;

        public PostReportServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokermock = new Mock<ILoggingBroker>();

            this.postReportService = new PostReportService(
                storageBroker: this.storageBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokermock.Object);
        }

        private static IQueryable<PostReport> CreateRandomPostReports()
        {
            return CreateRandomFiller(dates: GetRandomDateTimeOffset())
                .Create(count: GetRandomNumber()).AsQueryable();
        }

        private static int GetRandomNumber() =>
           new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static Filler<PostReport> CreateRandomFiller(DateTimeOffset dates)
        {
            var filler = new Filler<PostReport>();

            filler.Setup().OnType<DateTimeOffset>().Use(dates);

            return filler;
        }
    }
}