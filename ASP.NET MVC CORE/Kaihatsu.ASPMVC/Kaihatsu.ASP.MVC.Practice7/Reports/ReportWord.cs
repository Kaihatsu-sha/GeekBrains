using Kaihatsu.ASP.MVC.Practice7.Interfaces;
using TemplateEngine.Docx;

namespace Kaihatsu.ASP.MVC.Practice7.Reports;

public class ReportWord : IProductsReport
{
    private const string _fieldDescription = "CatalogDescription";
    private const string _fieldName = "CatalogName";
    private const string _fieldDate = "CreationDate";
    private const string _fieldProductRow = "Product";
    private const string _fieldProductId = "ProductId";
    private const string _fieldProductName = "ProductName";
    private const string _fieldProductDescription = "ProductDescription";
    private const string _fieldProductPrice = "ProductPrice";
    private const string _fieldProductTotalPrice = "ProductTotalPrice";

    private readonly FileInfo _templateFile;
    public string CatalogName {get;set;}
    public DateTime CreationDate { get; set; }
    public string Description { get; set; }
    public IEnumerable<(int Id, string Name, string Description, decimal Price)> Products { get; set; }

    public ReportWord(string templateFilePath)=> _templateFile = new FileInfo(templateFilePath);

    public FileInfo Creation(string reportFilePath)
    {
        if (!_templateFile.Exists)
            throw new FileNotFoundException("Файл шаблона не найде", _templateFile.FullName);

        FileInfo reportFile = new FileInfo(reportFilePath);
        if(reportFile.Exists)
            reportFile.Delete();

        _templateFile.CopyTo(reportFile.FullName);

        var rows = Products.Select(item => new TableRowContent(new List<FieldContent> {
            new FieldContent(_fieldProductId, item.Id.ToString()),
            new FieldContent(_fieldProductName, item.Name),
            new FieldContent(_fieldProductDescription, item.Description),
            new FieldContent(_fieldProductPrice, item.Price.ToString("c"))
        }));

        decimal totalPrice = Products.Sum(item => item.Price);

        var content = new Content(
            new FieldContent(_fieldDescription, Description),
            new FieldContent(_fieldName, CatalogName),
            new FieldContent(_fieldDate, CreationDate.ToString("yyyy-MM-dd HH:mm:ss")),
            new FieldContent(_fieldProductTotalPrice, totalPrice.ToString("c")),
            new TableContent(_fieldProductRow, rows) );

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
