using System;
using System.Collections.Generic;

namespace Security_API.Data;

public partial class Client
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
