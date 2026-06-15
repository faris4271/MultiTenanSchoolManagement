using FSH.Framework.Web.Modules;

namespace FSH.Modules.Logistics;

public sealed class LogisticsModuleConstants : IModuleConstants
{
    public string ModuleId => "Logistics";
    public string ModuleName => "Logistics";
    public string ApiPrefix => "logistics";
    public const string SchemaName = "logistics";
}
