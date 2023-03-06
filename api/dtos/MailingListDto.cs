using System;
using System.Collections.Generic;

namespace Models;

public partial class MailingListDto
{
    public int Id { get; set; }

    public int? IspId { get; set; }

    public int? ProviderId { get; set; }

    public string ListName { get; set; }

    public bool? Active { get; set; }

    public long? TotalEmails { get; set; }

    public string DataTableName { get; set; }

    public DateTime? AddOn { get; set; }

    public string AddBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public string FileBlob { get; set; }

}
