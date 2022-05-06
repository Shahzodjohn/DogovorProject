using ConnectionProvider;
using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Entity.ResponseMessage;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repository;
using Repository.Interfaces;
using Service.Services.FormToFillService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;


namespace TestProject
{
    public class ApplicationFormControllerTests
    {
        private readonly IFormService _formService;
        private readonly Mock<IFormRepository> _formrepo = new();
        private readonly DbContextOptions<AppDbContext> _context = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        public ApplicationFormControllerTests()
        {_formService = new FormService(_formrepo.Object) { };}

        [Fact]
        public async void DocumentFirstPageTester()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.DocumentNumber = "#77586300";
            dto.cityId = 1;
            dto.DateOfIssue = DateTime.Now;
            await DocumentFirstPage(dto);
        }
        private async Task<Response> DocumentFirstPage(DocumentDTO dto)
        {
            Response? message; 
            using (var context = new AppDbContext(_context))
            {
                FormToFill? formApplication = default;
                try
                {
                    var document = new Document
                    {
                        DocumentNumber = dto.DocumentNumber,
                        cityId = dto.cityId,
                        DateOfIssue = dto.DateOfIssue,
                    };
                    await context.documents.AddAsync(document);
                    await context.SaveChangesAsync();
                    formApplication = new FormToFill
                    {
                        documentId = document.Id
                    };
                    await context.formsToFill.AddAsync(formApplication);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    Assert.Fail("BadRequest!");
                }
                message = new Response { Status = "200", Message = $"OrderId => {formApplication.Id}" };

            }
            if (message.Status == null)
                Assert.Fail(message.Message);

            if (message == null)
                Assert.Fail("Entity was not saved!");
            if (message.Status == "200")
                message = new Response { Status = message.Status, Message = message.Message };
            else
                message = new Response { Status = message.Status, Message = message.Message };
            
            return new Response { Status = message.Status, Message = message.Message };
        }
        //============================================================//
        public async Task<FormToFill> ReturnPrincipal()
        {
            FormToFill formApplication;
            using (var context = new AppDbContext(_context))
            {
                formApplication = new FormToFill
                {
                    documentId = 1
                };
                await context.formsToFill.AddAsync(formApplication);
                await context.SaveChangesAsync();
            }  
            return formApplication;
        }
        [Fact]
        public async void PrincipalSecondPageTester()
        {
            PrincipalInfoDTO dto = new PrincipalInfoDTO();
            dto.PrincipalPlaceId = 1;
            dto.PrincipalNameId = 1;
            dto.PrincipalPositionId = 1;
            dto.OrderId = 1;
            dto.PrincipalReasonId = 1;
            await PrincipalSecondPage(dto);
        }
        private async Task<Response> PrincipalSecondPage(PrincipalInfoDTO dto)
        {
            using (var context = new AppDbContext(_context))
            {
                Response message;
                var findOrder = await ReturnPrincipal();//await context.formsToFill.FirstOrDefaultAsync(x=>x.Id == dto.OrderId);
                if (findOrder == null)
                    Assert.Fail("value null");
                try
                {
                    var principalInfo = new PrincipalInfo
                    {
                        PrincipalPlaceId = dto.PrincipalPlaceId,
                        PrincipalPositionId = dto.PrincipalPositionId,
                        PrincipalNameId = dto.PrincipalNameId,
                        PrincipalReasonId = dto.PrincipalReasonId,
                        ReceiversAmount = dto.ReceiversAmount
                    };
                    await context.principalInfos.AddAsync(principalInfo);
                    await context.SaveChangesAsync();
                    findOrder.principalInfoId = principalInfo.Id;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    message = new Response { Status = "400", Message = "BadRequest!" };
                }

                message = new Response { Status = "200", Message = "Success!" };
                if (message == null)
                    Assert.Fail("Entity was not saved!");
                if (message.Status == "200")
                    message = new Response { Status = message.Status, Message = message.Message };
                else
                    message = new Response { Status = message.Status, Message = message.Message };
                return new Response { Status = message.Status, Message = message.Message };
            } 
        }
        //===============================================================//
        public async Task<FormToFill> ReturnPrincipalInfo()
        {
            FormToFill formApplication;
            using (var context = new AppDbContext(_context))
            {
                formApplication = new FormToFill
                {
                    documentId = 1,
                    principalInfoId = 1
                };
                await context.formsToFill.AddAsync(formApplication);
                await context.SaveChangesAsync();
            }
            return formApplication;
        }
        [Fact]
        public async void ReceiverThirdPageTest()
        {
            ReceiversInfoDTO dto = new ReceiversInfoDTO();
            dto.—itizenshipId = 1;
            dto.ReceiversFullname = "Fotima Rizoyeva";
            dto.PassportPlaceOfIssue = "ÓÏ‚‰ ¯. ƒÛ¯‡Ì·Â";
            dto.PassportDateOfIssue = DateTime.Now;
            dto.PassportNumber = "¿777777777";
            dto.OrderId = 2;
            dto.ReceiversPassportTypeId = 1;
            await ReceiverThirdPage(dto);
        }
        private async Task<bool> ReceiverThirdPage(ReceiversInfoDTO dto)
        {
            Response message;
            using (var context = new AppDbContext(_context))
            {
                var findOrder = await ReturnPrincipalInfo();
                if (findOrder == null)
                    Assert.Fail("Value Null");
                try
                {
                    var receiverInfo = new ReceiverInfo
                    {
                        ReceiversFullname = dto.ReceiversFullname,
                        —itizenshipId = dto.—itizenshipId,
                        ReceiversPassportTypeId = dto.ReceiversPassportTypeId,
                        PassportNumber = dto.PassportNumber,
                        PassportPlaceOfIssue = dto.PassportPlaceOfIssue,
                        PassportDateOfIssue = dto.PassportDateOfIssue,
                    };
                    await context.receiverInfos.AddAsync(receiverInfo);
                    await context.SaveChangesAsync();
                    findOrder.receiversInfoId = receiverInfo.Id;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                   message = new Response { Status = "400", Message = "BadRequest!" };
                }
                message = new Response { Status = "200", Message = "Success!" };
            }
            if (message.Status == null)
                Assert.Fail(message.Status);
            return true;
        }
        //================================================================//
        public async Task<FormToFill> ReturnReceiversInfo()
        {
            FormToFill formApplication;
            using (var context = new AppDbContext(_context))
            {
                formApplication = new FormToFill
                {
                    documentId = 1,
                    principalInfoId = 1,
                    receiversInfoId = 1,
                };
                await context.formsToFill.AddAsync(formApplication);
                await context.SaveChangesAsync();
            }
            return formApplication;
        }
        [Fact]
        public async void PurposePageFourTest()
        {
            PurposeDTO dto = new PurposeDTO();
            dto.OrderId = 1;
            dto.PurposeId = 2;
            await PurposePageFour(dto);
        }

        public async Task<bool> PurposePageFour(PurposeDTO dto)
        {
            Response message;
            using (var context = new AppDbContext(_context))
            {
                var findOrder = await ReturnReceiversInfo();
                if (findOrder == null)
                    Assert.Fail("ValueNull");
                try
                {
                    findOrder.purposeId = dto.PurposeId;
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                   message = new Response { Status = "400", Message = "BadRequest!" };
                }
                message = new Response { Status = "200", Message = "Success!" };
            }
            if (message.Status == null)
                Assert.Fail(message.Status);
            return true;
        }
        //============================// //====================================//
    }
}