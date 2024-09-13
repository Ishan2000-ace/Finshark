using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace IStockRepository
{
    public interface TokenInterface
    {
        string createToken(AppUser appUser);
    }
}