These extensions make the creating DevExpress Reports easier and clear. Instead of using the Report Designer developer can do it directly in C# code:

 ```csharp
  public XtraReport CreateReport(string title)
  {
    var report = new XtraReport();
    
    report.InitializeDataMember(nameof(ReportData.Items));

    report.AddReportHeader(title);

    report.AddCombinedGrid()
      .AddColumn(1D, "Number", nameof(ReportItem.Number))
      .AddColumn(2.5D, "Name", nameof(ReportItem.Name))
      .AddColumn(1.25D, "Manager", nameof(ReportItem.ProjectManager), BorderSide.Right)
      .AddColumnDate(0.75D, "Recieved", nameof(ReportItem.RecievedDate))
      .AddColumnDate(0.75D, "Completed", nameof(ReportItem.CompletedDate))
      .AddColumnMoney(0.75D, "Cost", nameof(myRepoReportItemrtData.Costs), BorderSide.Left)
      .AddColumnMoney(0.75D, "Profit", nameof(ReportItem.Profit));

    report.AddGroupHeader(nameof(ReportItem.Location))
      .AdjustBorderStyleFromDetail();
    
    report.AddGroupHeader(nameof(ReportItem.Type));

    report.AddGroupFooter().AdjustBorderStyleFromDetail()
      .AddColumnCount(7D)
      .AddColumnMoney(0.75D, nameof(ReportItem.Costs), BorderSide.Left)
      .AddColumnMoney(0.75D, nameof(ReportItem.Profit));
     
    report.AddPageNumber();
    
    report.DataSourceDemanded += DataSourceDemanded;
    
    return report;
  }
  
  private void DataSourceDemanded(object sender, EventArgs e)
  {
    ((XtraReport)sender).DataSource = logic.GetReportData();
  }
  
  public partial class ReportData
  {
    public IList<ReportItem> Items { get; set; }
  }

  public class ReportItem
  {
    public int ID { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }

    public string ProjectManager { get; set; }

    public DateTime? RecievedDate { get; set; }
    public DateTime? CompletedDate { get; set; }

    public decimal? Costs { get; set; }
    public decimal? Profit { get; set; }
  }
```
