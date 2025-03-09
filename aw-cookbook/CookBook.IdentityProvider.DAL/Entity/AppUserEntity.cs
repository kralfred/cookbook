using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.IdentityProvider.DAL.Entity;

public class AppUserEntity
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool Active { get; set; }
    public string? Email { get; set; }

    public ICollection<AppUserClaimEntity> Claims { get; set; } = new List<AppUserClaimEntity>();


}
