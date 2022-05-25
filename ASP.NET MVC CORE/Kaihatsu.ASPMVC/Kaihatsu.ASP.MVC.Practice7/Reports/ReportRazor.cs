using Kaihatsu.ASP.MVC.Practice7.Interfaces;
using RazorEngine.Templating;
using RazorEngine;

namespace Kaihatsu.ASP.MVC.Practice7.Reports;

internal class ReportRazor : IProductsReport
{
    public string CatalogName { get; set; }
    public DateTime CreationDate { get; set; }
    public string Description { get; set; }
    public IEnumerable<(int Id, string Name, string Description, decimal Price)> Products { get; set; }

    private string template = @"@Model.Name";
    public FileInfo Creation(string reportTemplateFile)
    {
        FileInfo report = new FileInfo(reportTemplateFile);

        var rezult = Engine.Razor.RunCompile(template, "Template", null, new
        {
            Name = CatalogName,
            Description = Description

        });

        using (var writer = report.AppendText())
            writer.Write(rezult);

        report.Refresh();
        return report;
    }
}
