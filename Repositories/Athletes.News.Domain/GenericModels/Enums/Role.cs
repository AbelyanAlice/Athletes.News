using System.ComponentModel;


namespace Athletes.News.Domain.GenericModels.Enums;

public enum Role
{
    [Description("admin_user")] SuperAdmin = 1,
    [Description("admin_user")] Admin = 2,
    [Description("customer_user")] Customer = 3
}
