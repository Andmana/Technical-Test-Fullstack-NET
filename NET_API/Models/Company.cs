using System;
using System.Collections.Generic;

namespace NET_API.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Npwp { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string PicName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? NpwpSrc { get; set; }

    public string? PowerOfAttoreySrc { get; set; }

    public bool? InvitationAccess { get; set; }

    public DateTime? CreatedAt { get; set; }
}
