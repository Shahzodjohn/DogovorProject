using ConnectionProvider;
using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _context;

        public FormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> InsertIntoDocument(DocumentDTO dto)
        {
            FormToFill formApplication;
            try
            {
                var document = new Document
                {
                    DocumentNumber = dto.DocumentNumber,
                    cityId = dto.cityId,
                    DateOfIssue = dto.DateOfIssue,
                };
                await _context.documents.AddAsync(document);
                await _context.SaveChangesAsync();
                formApplication = new FormToFill
                {
                    documentId = document.Id
                };
                await _context.formsToFill.AddAsync(formApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Response { Status = "400", Message = "BadRequest!" };
            }
            return new Response { Status = "200", Message = $"OrderId => {formApplication.Id}" };
        }

        public async Task<Response> InsertIntoPrincipalInfo(PrincipalInfoDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
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
                await _context.principalInfos.AddAsync(principalInfo);
                await _context.SaveChangesAsync();
                findOrder.principalInfoId = principalInfo.Id;
                //var formApplication = new FormToFill
                //{
                //    principalInfoId = principalInfo.Id
                //};
                //await _context.formsToFill.AddAsync(formApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Response { Status = "400", Message = "BadRequest!" };
            }
            return new Response { Status = "200", Message = "Success!" };
            
        }

        public async Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            try
            {
                var receiverInfo = new ReceiversInfo
                {
                      ReceiversFullname = dto.ReceiversFullname,
                       СitizenshipId = dto.СitizenshipId,
                        ReceiversPassportTypeId = dto.ReceiversPassportTypeId,
                         PassportNumber = dto.PassportNumber,
                          PassportPlaceOfIssue = dto.PassportPlaceOfIssue,
                           PassportDateOfIssue = dto.PassportDateOfIssue,
                };
                await _context.receiversInfos.AddAsync(receiverInfo);
                await _context.SaveChangesAsync();
                findOrder.principalInfoId = receiverInfo.Id;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Response { Status = "400", Message = "BadRequest!" };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<Response> InsertIntoPurposeId(PurposeDTO dto)
        {
            
            try
            {
                var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
                findOrder.purposeId = dto.PurposeId;
                //var formApplication = new FormToFill
                //{
                //    purposeId = dto.PurposeId
                //};
                //await _context.formsToFill.AddAsync(formApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Response { Status = "400", Message = "BadRequest!" };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto)
        {
            try
            {
                var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
                findOrder.validFrom = dto.ValidFrom;
                findOrder.validUntill = dto.ValidUntill;
                //var formApplication = new FormToFill
                //{
                //    validFrom = dto.ValidFrom,
                //     validUntill = dto.ValidUntill,
                //};
                //await _context.formsToFill.AddAsync(formApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Response { Status = "400", Message = "BadRequest!" };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        
    }
}
