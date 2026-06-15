using FSH.Framework.Shared.Identity;

namespace FSH.Modules.Administration;

public static class AdministrationPermissionConstants
{
    public static class Schools
    {
        public const string View = "Permissions.Schools.View";
        public const string Create = "Permissions.Schools.Create";
        public const string Update = "Permissions.Schools.Update";
        public const string Delete = "Permissions.Schools.Delete";
    }

    public static class Departments
    {
        public const string View = "Permissions.Departments.View";
        public const string Create = "Permissions.Departments.Create";
        public const string Update = "Permissions.Departments.Update";
        public const string Delete = "Permissions.Departments.Delete";
    }

    public static class Auditoriums
    {
        public const string View = "Permissions.Auditoriums.View";
        public const string Create = "Permissions.Auditoriums.Create";
        public const string Update = "Permissions.Auditoriums.Update";
        public const string Delete = "Permissions.Auditoriums.Delete";
        public const string Book = "Permissions.Auditoriums.Book";
    }

    public static class Playgrounds
    {
        public const string View = "Permissions.Playgrounds.View";
        public const string Create = "Permissions.Playgrounds.Create";
        public const string Update = "Permissions.Playgrounds.Update";
        public const string Delete = "Permissions.Playgrounds.Delete";
    }

    public static class NoticeBoards
    {
        public const string View = "Permissions.NoticeBoards.View";
        public const string Create = "Permissions.NoticeBoards.Create";
        public const string Update = "Permissions.NoticeBoards.Update";
        public const string Delete = "Permissions.NoticeBoards.Delete";
    }
}
