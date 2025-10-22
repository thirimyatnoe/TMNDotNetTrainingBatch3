using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreDatabaseFirst.Database.AppDbContextModels;

public partial class TblProductCategory
{
    [Key]
    public int ProductCategoryId { get; set; }

    public string? ProductCategoryCode { get; set; }

    public string? ProductCategoryName { get; set; }

    public bool? DeleteFlag { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }
}
