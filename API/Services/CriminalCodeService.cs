using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repo;

namespace API.Services
{
    public class CriminalCodeService : ICriminalCodeService
    {
        private readonly CodigosPenaisContext _CodigosPenaisContext;
        private readonly ITokenService _TokenService;
        private readonly IConfiguration _Configuration;
        private List<string> fields = new List<string>{
                "Id",
                "Name",
                "Description",
                "Penalty",
                "PrisonTime",
                "StatusId",
                "CreateDate",
                "UpdateDate",
                "CreateUserId",
                "UpdateUserId"
            };
        public CriminalCodeService(CodigosPenaisContext dbContext, ITokenService tokenService, IConfiguration configuration)
        {
            _CodigosPenaisContext = dbContext;
            _TokenService = tokenService;
            _Configuration = configuration;
        }
        public void IncludeCriminalCode(CriminalCode criminalCode)
        {
            Status status = new Status { Name = "Status" };
            _CodigosPenaisContext.Statuses.Add(status);
            _CodigosPenaisContext.SaveChanges();
            criminalCode.StatusId = status.Id;
            _CodigosPenaisContext.CriminalCodes.Add(criminalCode);
            _CodigosPenaisContext.SaveChanges();
        }
        public bool RemoveCriminalCode(int criminalCodeId)
        {
            CriminalCode? criminalCode = _CodigosPenaisContext.CriminalCodes.FirstOrDefault(x => x.Id.Equals(criminalCodeId));
            if (criminalCode != null)
            {
                _CodigosPenaisContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateCriminalCode(CriminalCode criminalCode)
        {
            CriminalCode? oldCriminalCode = _CodigosPenaisContext.CriminalCodes.FirstOrDefault(x => x.Id.Equals(criminalCode.Id));
            if (criminalCode != null)
            {
                oldCriminalCode = criminalCode;
                _CodigosPenaisContext.SaveChanges();
                return true;
            }
            return false;
        }
        public CriminalCode? GetCriminalCodeById(int criminalCodeId)
        {
            CriminalCode? criminalCode = _CodigosPenaisContext.CriminalCodes.FirstOrDefault(x => x.Id.Equals(criminalCodeId));
            if (criminalCode != null)
            {
                return criminalCode;
            }
            return null;
        }
        public List<CriminalCode> GetSortedCriminalCodes(CriminalCodeFilter criminalCodeFilter)
        {
            if (criminalCodeFilter.OrderId >= fields.Count() || criminalCodeFilter.FilterId >= fields.Count())
            {
                return new List<CriminalCode>();
            }

            string orderWay = criminalCodeFilter.Way ? "desc" : "asc";

            List<CriminalCode> criminalCodes = FilterCriminalCodes(_CodigosPenaisContext.CriminalCodes, fields[(int)criminalCodeFilter.FilterId], criminalCodeFilter.Filter)
            .OrderBy($"{fields[(int)criminalCodeFilter.OrderId]} {orderWay}")
            .Skip(criminalCodeFilter.Page * criminalCodeFilter.Rows)
            .Take(criminalCodeFilter.Rows).ToList();
            return criminalCodes;
        }
        private IQueryable<CriminalCode> FilterCriminalCodes(DbSet<CriminalCode> query, string filter, string value)
        {
            if (value == "")
            {
                return query;
            }
            switch (filter)
            {
                // Int values
                case "Id":
                    return query.Where(x => x.Id.Equals(Convert.ToInt32(value)));
                case "PrisonTime":
                    return query.Where(x => x.PrisonTime.Equals(Convert.ToInt32(value)));
                case "StatusId":
                    return query.Where(x => x.StatusId.Equals(Convert.ToInt32(value)));
                case "CreateUserId":
                    return query.Where(x => x.CreateUserId.Equals(Convert.ToInt32(value)));
                case "UpdateUserId":
                    return query.Where(x => x.UpdateUserId.Equals(Convert.ToInt32(value)));
                // Float values
                case "Penalty":
                    return query.Where(x => x.Penalty.Equals(float.Parse(value)));
                // String values
                case "Name":
                    return query.Where(x => x.Name.Contains(value));
                case "Description":
                    return query.Where(x => x.Description.Contains(value));
                default:
                    return query;
            }
        }
    }
}