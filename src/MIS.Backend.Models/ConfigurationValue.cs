using MIS.Backend.Models.Interfaces;

namespace MIS.Backend.Models;

public class ConfigurationValue : IHasId
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}