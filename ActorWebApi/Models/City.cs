using System;
using System.Collections.Generic;

namespace ActorWebApi.Models;

public partial class City
{
    public ushort CityId { get; set; }

    public string City1 { get; set; } = null!;

    public ushort CountryId { get; set; }

    public DateTime LastUpdate { get; set; }
}
