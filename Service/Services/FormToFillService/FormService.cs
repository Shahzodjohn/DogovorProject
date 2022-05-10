using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Entity.ResponseMessage;
//using Microsoft.Office.Interop.Word;
using Repository;
using System.Text.RegularExpressions;

namespace Service.Services.FormToFillService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _fRepository;

        public FormService(IFormRepository fRepository)
        {
            _fRepository = fRepository;
        }
        Response response = new Response();
        public async Task<string> InsertIntoDocument(DocumentDTO dto)
        {

              var message =  await _fRepository.InsertIntoDocument(dto);
            if (message == null)
                return response.ToLog("400", "Entity was not saved!");
            if (message.Status == "200")
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<string> InsertIntoPrincopalInfo(PrincipalInfoDTO dto)
        {
            var message = await _fRepository.InsertIntoPrincipalInfo(dto);
            if (message == null)
                return response.ToLog("400", "Entity was not saved!");
            if (message.Status == "200")
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
        public async Task<string> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var message = await _fRepository.InsertReceiversInfoId(dto);
            if (message == null)
                return response.ToLog("400", "Entity was not saved!");
            if (message.Status == "200")
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<string> InsertIntoPurposeId(PurposeDTO dto)
        {
            var message = await _fRepository.InsertIntoPurposeId(dto);
            if (message == null)
                return response.ToLog("400", "Entity was not saved!");
            if (message.Status == "200")
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<string> InsertIntoValidatonDatas(ValidationDataDTO dto)
        {
            var message = await _fRepository.InsertIntoValidatonDatas(dto);
            if (message == null)
                return response.ToLog("400", "Entity was not saved!");
            if (message.Status == "200")
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<string> OrderInfo(int orderId, string Path)
        {
            string FinalPath = string.Empty;
            try
            {
                var orderinfo = await _fRepository.OrderInfo(orderId);
                if (orderinfo == null)
                    return response.ToLog("400", "OrderId does not exists!");
                var ValueLists = new Dictionary<string, object>();
                var LastCity = "г. Душанбе"; var newCity = orderinfo.Document.City.CityName;
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
                var lastPassportDateofIssue = "PassportDateOfIssue"; var newPassportDateofIssue = orderinfo.ReceiversInfo.PassportDateOfIssue.ToString("D");
                newPassportDateofIssue = newPassportDateofIssue.Contains('я') ?
                newPassportDateofIssue.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.ReceiversInfo.PassportDateOfIssue.Year}", "") + "соли " + orderinfo.ReceiversInfo.PassportDateOfIssue.Year :
                newPassportDateofIssue.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.ReceiversInfo.PassportDateOfIssue.Year}", "") + "соли " + orderinfo.ReceiversInfo.PassportDateOfIssue.Year;
                ValueLists.Add(lastPassportDateofIssue, newPassportDateofIssue);
                var lastValidFrom = "FromDateOfIssue"; var newValidFrom = orderinfo.validFrom.Value.ToString("D");
                newValidFrom = newValidFrom.Contains('я') ?
                newValidFrom.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validFrom.Value.Year}", "") + "соли " + orderinfo.validFrom.Value.Year :
                newValidFrom.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validFrom.Value.Year}", "") + "соли " + orderinfo.validFrom.Value.Year;
                ValueLists.Add(lastValidFrom, newValidFrom);
                var lastValidUntill = "UntilDateOfIssue"; var newValidUntill = orderinfo.validUntill.Value.ToString("D");
                newValidUntill = newValidUntill.Contains('я') ?
                newValidUntill.Replace("я", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validUntill.Value.Year}", "") + "соли " + orderinfo.validUntill.Value.Year :
                newValidUntill.Replace("а", "и").Replace("г.", "").Trim().Replace($"{orderinfo.validUntill.Value.Year}", "") + "соли " + orderinfo.validUntill.Value.Year;
                ValueLists.Add(lastValidUntill, newValidUntill);
                FinalPath = GenerateFile(ValueLists, newDocumentNumberReceiver, Path, newDocumentNum);
            }
            catch (Exception ex)
            {
                return response.ToLog(null, ex.Message.ToString());
            }
           
           return FinalPath;
        }
        private string GenerateFile(Dictionary<string, object> dictionary, string passportNumber, string path, string documentNumber)
        {
            //System.IO.DirectoryInfo directorybyId;
            //if (!Directory.Exists(path + @"\User " + passportNumber))
            //{
            //    directorybyId = Directory.CreateDirectory(path + @"\User " + passportNumber);
            //}
            //directorybyId = new DirectoryInfo(path + @"\User " + passportNumber);
            //DirectoryInfo dirInfo = new DirectoryInfo(path + "\\Files");
            //FileInfo[] wordFiles = dirInfo.GetFiles("*.docx");
            //FileInfo wordFile = wordFiles[0];
            //Object filename = (Object)wordFile.FullName;
            //var wordApp = new Application();
            //var doc = wordApp.Documents.Open(filename, false, true);
            //foreach (var di in dictionary)
            //{
            //    var status = doc.Content.Find.Execute(FindText: di.Key,
            //                            MatchCase: false,
            //                            MatchWholeWord: false,
            //                            MatchWildcards: false,
            //                            MatchSoundsLike: false,
            //                            MatchAllWordForms: false,
            //                            Forward: true, //this may be the one
            //                            Wrap: false,
            //                            Format: false,
            //                            ReplaceWith: di.Value,
            //                            Replace: WdReplace.wdReplaceAll);
            //    doc.SaveAs(directorybyId + @"\" + $" Ваколатнома {documentNumber}.docx");
            //}
            //doc.Close();
            return ""; // directorybyId + @"\" + $" Ваколатнома {documentNumber}.docx";
        }
    }
}
