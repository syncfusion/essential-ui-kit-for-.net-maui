using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class DocumentsViewModel
    {
        public ObservableCollection<Document> DocumentsList { get; set; }

        public DocumentsViewModel()
        {
            DocumentsList = new ObservableCollection<Document>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""documentsPageList"": [
                { ""documentName"": ""Sample Browser Notes.docx"", ""time"": ""26 Aug"", ""documentSize"": ""100KB"", ""documentType"":""word.png"" },
                { ""documentName"": ""Attendance Sheet.xlsx"", ""time"": ""22 Aug"", ""documentSize"": ""86KB"", ""documentType"":""excel.png"" },
                { ""documentName"": ""Button Requirement.docx"", ""time"": ""20 Aug"", ""documentSize"": ""117KB"", ""documentType"":""word.png"" },
                { ""documentName"": ""Invoice October.pdf"", ""time"": ""19 Aug"", ""documentSize"": ""600KB"", ""documentType"":""pdf.png"" },
                { ""documentName"": ""UG Documentation.docx"", ""time"": ""01 Aug"", ""documentSize"": ""98KB"", ""documentType"":""word.png"" },
                { ""documentName"": ""Pay Slip October.pdf"", ""time"": ""26 Jul"", ""documentSize"": ""749KB"", ""documentType"":""pdf.png"" },
                { ""documentName"": ""UI Template Requirement.docx"", ""time"": ""12 Jul"", ""documentSize"": ""48KB"", ""documentType"":""word.png"" },
                { ""documentName"": ""Avatar UG Documentation.docx"", ""time"": ""18 Jul"", ""documentSize"": ""45KB"", ""documentType"":""word.png"" },
                { ""documentName"": ""Button UX Document.docx"", ""time"": ""09 Jul"", ""documentSize"": ""38KB"", ""documentType"":""word.png"" }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<DocumentData>(jsonData, options);

            if (data?.DocumentsPageList == null)
            {
                return;
            }

            foreach (var document in data.DocumentsPageList)
            {
                DocumentsList.Add(document);
            }
        }
    }

    public class DocumentData
    {
        public List<Document>? DocumentsPageList { get; set; }
    }

    public class Document
    {
        public string? DocumentName { get; set; }
        public string? Time { get; set; }
        public string? DocumentSize { get; set; }
        public string? DocumentType { get; set; }
    }
}
