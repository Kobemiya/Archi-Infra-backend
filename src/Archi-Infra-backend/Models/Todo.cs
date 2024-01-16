using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InfraArchi;

public partial class Todo
{
    [JsonPropertyName("pk")]
    public int Pk => Id;

    [JsonPropertyName("sk")]
    public int Sk => Id;
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }
}
