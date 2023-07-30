using GiacomCDR_Api.Controllers;
using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GiacomCDR_Api.Tests.Controllers
{
    public class CallDetailRecordControllerTests
    {
        private Mock<IMediator> _mediatrMock;
        private CallDetailRecordController _sut;

        public CallDetailRecordControllerTests()
        {
            _mediatrMock = new Mock<IMediator>();
            _sut = new CallDetailRecordController(_mediatrMock.Object);
        }

        [Fact]
        public void GetCallRecordsTest()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetCallRecordsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse<CallDetailRecord>
                {
                    Result = new List<CallDetailRecord>()
                    {
                        new CallDetailRecord()
                        {
                            Id = new Guid("6DCCECC1-A7DA-4A8E-9777-CF519415BDD5"),
                            CallerId = "01214477497",
                            Recipient = "07496934546",
                            CallDate = DateTime.Now,
                            EndTime = "14:21",
                            Duration = 34,
                            Cost = 0.34m,
                            Reference = "12355"
                        },
                        new CallDetailRecord()
                        {
                            Id = new Guid("9D2185F8-8608-406A-B4DB-9079039B1B27"),
                            CallerId = "01214477497",
                            Recipient = "07496934546",
                            CallDate = DateTime.Now,
                            EndTime = "14:21",
                            Duration = 67,
                            Cost = 0.54m,
                            Reference = "12356"
                        }
                    }
                });

            var result = _sut.GetCallRecords(string.Empty, string.Empty);
            var okResult = result.Result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.NotNull(result);
            _mediatrMock.Verify();
        }

        [Fact]
        public void GetCallRecordsException()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetCallRecordsCommand>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _sut.GetCallRecords(string.Empty, string.Empty));
            _mediatrMock.Verify();
        }

        [Fact]
        public void GetTotalCostTest()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetCallerTotalsCommand>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new CommandResponse_Dec
            //    {
            //        Result = 3.34m
            //    });

            //var result = _sut.GetTotalCost();
            //var okResult = result.Result as OkObjectResult;

            //Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            //Assert.NotNull(result);
            //_mediatrMock.Verify();
        }

        [Fact]
        public void GetTotalCostException()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetCallerTotalsCommand>(), It.IsAny<CancellationToken>()))
            //    .Throws(new Exception());

            //Assert.ThrowsAsync<Exception>(() => _sut.GetTotalCost());
            //_mediatrMock.Verify();
        }

        [Fact]
        public void GetAverageCostTest()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetAverageCostCommand>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new CommandResponse_Dec
            //    {
            //        Result = 0.71m
            //    });

            //var result = _sut.GetAverageCost();
            //var okResult = result.Result as OkObjectResult;

            //Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            //Assert.NotNull(result);
            //_mediatrMock.Verify();
        }

        [Fact]
        public void GetAverageCostException()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetAverageCostCommand>(), It.IsAny<CancellationToken>()))
            //    .Throws(new Exception());

            //Assert.ThrowsAsync<Exception>(() => _sut.GetAverageCost());
            //_mediatrMock.Verify();
        }

        [Fact]
        public void GetAverageDurationTest()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetCallRecordsByCallerIdCommand>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new CommandResponse_Dbl
            //    {
            //        Result = 64
            //    });

            //var result = _sut.GetAverageDuration();
            //var okResult = result.Result as OkObjectResult;

            //Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            //Assert.NotNull(result);
            //_mediatrMock.Verify();
        }

        [Fact]
        public void GetAverageDurationException()
        {
            //_mediatrMock
            //    .Setup(m => m.Send(It.IsAny<GetCallRecordsByCallerIdCommand>(), It.IsAny<CancellationToken>()))
            //    .Throws(new Exception());

            //Assert.ThrowsAsync<Exception>(() => _sut.GetAverageDuration());
            //_mediatrMock.Verify();
        }
    }
}
