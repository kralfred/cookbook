using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.IdentityProvider.DAL.Entity;

public class AppUserClaimEntity
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }

    public Guid UserId { get; set; }
    public AppUserEntity User { get; set; }



}
