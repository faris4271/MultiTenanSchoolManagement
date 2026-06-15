using FSH.Framework.Web.Modules;

namespace FSH.Modules.Administration;

public sealed class AdministrationModuleConstants : IModuleConstants
{
    public string ModuleId => "Administration";
    public string ModuleName => "Administration";
    public string ApiPrefix => "administration";
    public const string SchemaName = "administration";
}
