using System;
using System.Collections.Generic;

namespace Kiosk.Models;

public partial class EntityHistoryTrackingView
{
    public string? ReceiverName { get; set; }
    public int EntityTypeCode { get; set; }
    public int EntityCode { get; set; }
    public DateTime? ReceiveDate { get; set; }
}