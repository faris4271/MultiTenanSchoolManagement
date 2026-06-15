using FSH.Framework.Web.Modules;

namespace FSH.Modules.HumanResources;

public sealed class HumanResourcesModuleConstants : IModuleConstants
{
    public string ModuleId => "HumanResources";
    public string ModuleName => "HumanResources";
    public string ApiPrefix => "hr";
    public const string SchemaName = "hr";
}
