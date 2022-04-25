using System.Linq.Expressions;
using System.Linq;
using System.Linq.Dynamic;
using EntityFramework.DynamicLinq;
using API.Models;
using API.Repo;

namespace API.Services
{
    public interface ICriminalCodeService
    {
        public void IncludeCriminalCode(CriminalCode criminalCode);
        public bool RemoveCriminalCode(int criminalCodeId);
        public bool UpdateCriminalCode(CriminalCode criminalCode);
        public CriminalCode? GetCriminalCodeById(int criminalCodeId);
        public List<CriminalCode> GetSortedCriminalCodes(CriminalCodeFilter criminalCodeFilter);
    }
}