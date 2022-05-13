using Kaihatsu.ASP.MVC.Practice7.Interfaces;
using TemplateEngine.Docx;

namespace Kaihatsu.ASP.MVC.Practice7.Reports;

public class ReportWord : IProductsReport
{
    private const string _fieldDescription = "CatalogDescription";
    private const string _fieldName = "CatalogName";
    private const string _fieldDate = "CreationDate";

    private readonly FileInfo _templateFile;
    public string CatalogName {get;set;}
    public DateTime CreationDate { get; set; }
    public string Description { get; set; }

    public ReportWord(string templateFilePath)=> _templateFile = new FileInfo(templateFilePath);

    public FileInfo Creation(string reportFilePath)
    {
        if (!_templateFile.Exists)
            throw new FileNotFoundException("Файл шаблона не найде", _templateFile.FullName);

        FileInfo reportFile = new FileInfo(reportFilePath);
        if(reportFile.Exists)
            reportFile.Delete();

        _templateFile.CopyTo(reportFile.FullName);

        var content = new Content(
            new FieldContent(_fieldDescription, Description),
            new FieldContent(_fieldName, CatalogName),
            new FieldContent(_fieldDate, CreationDate.ToString("yyyy-MM-dd HH:mm:ss")) );

        using (TemplateProcessor templateProcessor = new TemplateProcessor(reportFile.FullName))
        {
            templateProcessor.SetRemoveContentControls(true);
            templateProcessor.FillContent(content);
            templateProcessor.SaveChanges();
        }

        reportFile.Refresh();
        return reportFile;
    }
}
