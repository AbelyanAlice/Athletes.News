﻿using Microsoft.AspNetCore.Identity;

namespace Athletes.News.Domain.Entities;

public class UserRole : IdentityUserRole<long>
{
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;

}