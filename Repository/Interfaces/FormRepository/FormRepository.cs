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
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoDocument!", Message = ex.InnerException.ToString() };
            }
            return new Response { Status = "200", Message = $"OrderId => {formApplication.Id}" };
        }

        public async Task<Response> InsertIntoPrincipalInfo(PrincipalInfoDTO dto)
        {
            
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
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
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoPrincipalInfo!", Message = ex.InnerException.ToString() };
            }
            return new Response { Status = "200", Message = "Success!" };
            
        }

        public async Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
                var receiverInfo = new ReceiverInfo
                {
                    ReceiversFullname = dto.ReceiversFullname,
                    СitizenshipId = dto.СitizenshipId,
                    ReceiversPassportTypeId = dto.ReceiversPassportTypeId,
                    PassportNumber = dto.PassportNumber,
                    PassportPlaceOfIssue = dto.PassportPlaceOfIssue,
                    PassportDateOfIssue = dto.PassportDateOfIssue,
                };
                await _context.receiverInfos.AddAsync(receiverInfo);
                await _context.SaveChangesAsync();
                findOrder.receiversInfoId = receiverInfo.Id;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertReceiversInfoId!", Message = ex.InnerException.ToString() };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<Response> InsertIntoPurposeId(PurposeDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
                findOrder.purposeId = dto.PurposeId;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoPurposeId!", Message = ex.InnerException.ToString() };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
                findOrder.validFrom = dto.ValidFrom;
                findOrder.validUntill = dto.ValidUntill;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoValidatonDatas!", Message = ex.InnerException.ToString() };
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<FormToFill?> OrderInfo(int orderId)
        {
            var findOrder = await _context.formsToFill.FindAsync(orderId);
            if (findOrder != null)
                return findOrder;
            return null;
        }
    }
}
