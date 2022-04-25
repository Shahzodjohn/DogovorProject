using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Entity.ResponseMessage;
using Microsoft.Office.Interop.Word;
using Repository;

namespace Service.Services.FormToFillService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _fRepository;

        public FormService(IFormRepository fRepository)
        {
            _fRepository = fRepository;
        }

        public async Task<Response> InsertIntoDocument(DocumentDTO dto)
        {
              var message =  await _fRepository.InsertIntoDocument(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message};
            else
                return new Response { Status = message.Status, Message = message.Message };

        }

        public async Task<Response> InsertIntoPrincopalInfo(PrincipalInfoDTO dto)
        {
            var message = await _fRepository.InsertIntoPrincipalInfo(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }
        public async Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var message = await _fRepository.InsertReceiversInfoId(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        public async Task<Response> InsertIntoPurposeId(PurposeDTO dto)
        {
            var message = await _fRepository.InsertIntoPurposeId(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        public async Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto)
        {
            var message = await _fRepository.InsertIntoValidatonDatas(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        public async Task<Response> OrderInfo(int orderId)
        {

           var orderinfo = await _fRepository.OrderInfo(orderId);
            var ValueLists = new Dictionary<string, object>();
            var LastCity = "г. Душанбе";var newCity = orderinfo.Document.City.CityName;
            ValueLists.Add(LastCity, newCity);
            var lastDocumentNumber = "7000000000000000"; var newDocumentNum = orderinfo.Document.DocumentNumber;
            ValueLists.Add(lastDocumentNumber, newDocumentNum); 
            var lastDocumentDate = "documentDate"; var newDocumentDate = orderinfo.Document.DateOfIssue.ToString("D");
                                                            newDocumentDate = newDocumentDate.Contains('я') ?
                                                            newDocumentDate.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.Document.DateOfIssue.Year}", "") + "соли " + orderinfo.Document.DateOfIssue.Year :
                                                            newDocumentDate.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.Document.DateOfIssue.Year}", "") + "соли " + orderinfo.Document.DateOfIssue.Year;
            ValueLists.Add(lastDocumentDate, newDocumentDate);
            var lastPassportType = "шиносномаи"; var newPassportType = orderinfo.ReceiversInfo.ReceiversPassportType.Type;
            ValueLists.Add(lastPassportType, newPassportType);
            var lastPrincipalPlace = "Ҷамъияти саҳомии кушодаи «Алиф Бонк»"; var newPrincipalPlace = orderinfo.PrincipalInfo.PrincipalPlace.PrincipalPlaceName;
            ValueLists.Add(lastPrincipalPlace, newPrincipalPlace);
            var lastPrincipalPosition = "раис"; var newPrincipalPosition = orderinfo.PrincipalInfo.PrincipalPosition.PositionName;
            ValueLists.Add(lastPrincipalPosition, newPrincipalPosition);
            var lastPrincipalName = "Курбонов А.У."; var newPrincipalName = orderinfo.PrincipalInfo.PrincipalName.PrincipalFullName;
            ValueLists.Add(lastPrincipalName, newPrincipalName);
            var lastReceiverName = "ReceiverName"; var newReceiverName = orderinfo.ReceiversInfo.ReceiversFullname;
            ValueLists.Add(lastReceiverName, newReceiverName);
            var lastReceiverCitizenship = "шаҳрванди Ҷумҳурии Тоҷикистон"; var newReceiverCitizenship = orderinfo.ReceiversInfo.Citizenship.CitizenOf;
            ValueLists.Add(lastReceiverCitizenship, newReceiverCitizenship);
            var lastDocumentNumberReceiver = "DocumentNumberReceiver"; var newDocumentNumberReceiver = orderinfo.ReceiversInfo.PassportNumber;
            ValueLists.Add(lastDocumentNumberReceiver, newDocumentNumberReceiver);
            var lastPassportPlaceOfIssueReceiver = "PlaceOfIssueReceiver"; var newPassportPlaceOfIssueReceiver = orderinfo.ReceiversInfo.PassportPlaceOfIssue;
            ValueLists.Add(lastPassportPlaceOfIssueReceiver, newPassportPlaceOfIssueReceiver);
            var lastPassportDateofIssue = "PassportDateOfIssue";  var newPassportDateofIssue = orderinfo.ReceiversInfo.PassportDateOfIssue.ToString("D");
                                                                newPassportDateofIssue = newPassportDateofIssue.Contains('я') ? 
                                                                newPassportDateofIssue.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.ReceiversInfo.PassportDateOfIssue.Year}", "") + "соли " + orderinfo.ReceiversInfo.PassportDateOfIssue.Year :
                                                                newPassportDateofIssue.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.ReceiversInfo.PassportDateOfIssue.Year}", "") + "соли " + orderinfo.ReceiversInfo.PassportDateOfIssue.Year;
            ValueLists.Add(lastPassportDateofIssue, newPassportDateofIssue);
            var lastValidFrom = "FromDateOfIssue"; var newValidFrom = orderinfo.validFrom.Value.ToString("D");
                                                        newValidFrom = newValidFrom.Contains('я') ?
                                                        newValidFrom.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validFrom.Value.Year}", "") + "соли " + orderinfo.validFrom.Value.Year :
                                                        newValidFrom.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validFrom.Value.Year}", "") + "соли " + orderinfo.validFrom.Value.Year;
            ValueLists.Add(lastValidFrom, newValidFrom);
            var lastValidUntill = "UntilDateOfIssue";  var newValidUntill = orderinfo.validUntill.Value.ToString("D");
                                                        newValidUntill = newValidUntill.Contains('я') ?
                                                        newValidUntill.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validUntill.Value.Year}", "") + "соли " + orderinfo.validUntill.Value.Year :
                                                        newValidUntill.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validUntill.Value.Year}", "") + "соли " + orderinfo.validUntill.Value.Year;
            ValueLists.Add(lastValidUntill, newValidUntill);
            await GenerateFileAsync(ValueLists);
           
           return new Response { Status = "200", Message = "Okay" };
        }
        private async Task<string> GenerateFileAsync(Dictionary<string, object> dictionary)
        {
            const string TemplateFileName = @"C:\Users\shahz\Music\NewDocument\letter.docx";
            const string ResultFileName   = @"C:\Users\shahz\Music\NewDocument\letter2.docx";

            var wordApp = new Application();
            var doc = wordApp.Documents.Open(TemplateFileName, false, true);
            foreach (var di in dictionary)
            {
                var status = doc.Content.Find.Execute(FindText: di.Key,
                                        MatchCase: false,
                                        MatchWholeWord: false,
                                        MatchWildcards: false,
                                        MatchSoundsLike: false,
                                        MatchAllWordForms: false,
                                        Forward: true, //this may be the one
                                        Wrap: false,
                                        Format: false,
                                        ReplaceWith: di.Value,
                                        Replace: WdReplace.wdReplaceAll);
                doc.SaveAs(ResultFileName);
            }
            doc.Close();
            return "okay";
        }
    }
}
