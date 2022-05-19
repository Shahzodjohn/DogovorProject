using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            EntityEntry<Document> document = null;
            EntityEntry<FormToFill> formApplication;
            try
            {
                document = await _context.documents.AddAsync(new Document
                {
                    DocumentNumber = dto.DocumentNumber,
                    cityId = dto.cityId,
                    DateOfIssue = dto.DateOfIssue,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoDocument!", Message = ex.InnerException.ToString() };
            }
            finally
            {
                formApplication = await _context.formsToFill.AddAsync(new FormToFill
                {
                    documentId = document.Entity.Id
                });
                await _context.SaveChangesAsync();
            }
            return new Response { Status = "200", Message = $"OrderId => {formApplication.Entity.Id}" };
        }

        public async Task<Response> InsertIntoPrincipalInfo(PrincipalInfoDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            EntityEntry<PrincipalInfo> principalInfo = null;
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
                principalInfo = await _context.principalInfos.AddAsync(new PrincipalInfo
                {
                    PrincipalPlaceId = dto.PrincipalPlaceId,
                    PrincipalPositionId = dto.PrincipalPositionId,
                    PrincipalNameId = dto.PrincipalNameId,
                    PrincipalReasonId = dto.PrincipalReasonId,
                    ReceiversAmount = dto.ReceiversAmount
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertIntoPrincipalInfo!", Message = ex.InnerException.ToString() };
            }
            finally
            {
                findOrder.principalInfoId = principalInfo.Entity.Id;
                await _context.SaveChangesAsync();
            }
            return new Response { Status = "200", Message = "Success!" };
        }

        public async Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var findOrder = await _context.formsToFill.FindAsync(dto.OrderId);
            EntityEntry<ReceiverInfo> receiverInfo = null;
            try
            {
                if (findOrder == null)
                    return new Response { Status = "400", Message = $"order => {dto.OrderId} wasn't found!" };
                receiverInfo = await _context.receiverInfos.AddAsync(new ReceiverInfo
                {
                    ReceiversFullname = dto.ReceiversFullname,
                    СitizenshipId = dto.СitizenshipId,
                    ReceiversPassportTypeId = dto.ReceiversPassportTypeId,
                    PassportNumber = dto.PassportNumber,
                    PassportPlaceOfIssue = dto.PassportPlaceOfIssue,
                    PassportDateOfIssue = dto.PassportDateOfIssue,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while adding into rote InsertReceiversInfoId!", Message = ex.InnerException.ToString() };
            }
            finally
            {
                findOrder.receiversInfoId = receiverInfo.Entity.Id;
                await _context.SaveChangesAsync();
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
        public async Task<FormToFill> OrderInfo(int orderId)
        {
            var findOrder = await _context.formsToFill.FindAsync(orderId);
            if (findOrder != null)
                return findOrder;
            return null;
        }
    }
}
