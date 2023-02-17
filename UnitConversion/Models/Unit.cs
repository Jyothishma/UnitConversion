using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UnitConversion.Models;

public partial class Unit
{
    public int Id { get; set; }

    [DefaultValue(null)] 
    public string? MetricName { get; set; }

    [DefaultValue(null)]
    public string? MetricFormula { get; set; }

    [DefaultValue(null)]
    public string? ImperialName { get; set; }

    [DefaultValue(null)]
    public string? ImperialFormula { get; set; }

    
}
