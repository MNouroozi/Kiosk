using System;
using System.Collections.Generic;

namespace Kiosk.Models;

public partial class EntityHistoryTracking
{
    public int Etc { get; set; }

    public int Fec { get; set; }

    public string? DocSubject { get; set; }

    public string? ExportEntityNumber { get; set; }

    public DateTime? ExportDate { get; set; }
}
