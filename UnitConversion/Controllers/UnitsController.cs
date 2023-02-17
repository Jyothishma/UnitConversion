using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NuGet.Versioning;
using UnitConversion.Models;

namespace UnitConversion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly UnitConversionContext _context;

        public UnitsController(UnitConversionContext context)
        {
            _context = context;
        }

     
     
        //POST: api/Units
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
        public async Task<ActionResult<String>> UnitConversion(Unit unit, float UnitValue)
        {
            _context.Units.Add(unit);
            try
            {
                var Unit_List = await _context.Units.ToListAsync();
                if (unit.MetricName == null && unit.ImperialName == null)
                {
                    return "INVALID REQUEST! Either Metric Name or Imperial Name must be passed in Request ";
                }
                else if (unit.MetricName != null && unit.ImperialName != null)
                {
                    return "INVALID REQUEST! Both Metric Name and  Imperial Name cannot be passed in Request . Only one can be passed";
                }
                else if ((_context.Units.Any(p => p.MetricName.Equals(unit.MetricName)))  || (_context.Units.Any(p => p.ImperialName.Equals(unit.ImperialName))))

                {
                   if (unit.MetricName != null && unit.ImperialName == null) {
                        var Metric_List = _context.Units
                                           .Where(p => p.MetricName == unit.MetricName)
                                           .Select(p => p).ToList().FirstOrDefault();
                        var Result = Metric_List.MetricFormula.Replace("X", UnitValue.ToString());

                        DataTable dt = new DataTable();
                        return string.Concat(dt.Compute(Result, "").ToString(), " ", Metric_List.ImperialName);
                    }
                    else if (unit.ImperialName != null && unit.MetricName == null)
                    {
                        var Imperial_List = _context.Units
                                            .Where(p => p.ImperialName == unit.ImperialName)
                                            .Select(p => p).ToList().FirstOrDefault();
                        var Result = Imperial_List.ImperialFormula.Replace("X", UnitValue.ToString());
                        DataTable dt = new DataTable();
                        return string.Concat(dt.Compute(Result, "").ToString(), " ", Imperial_List.MetricName);
                    }
                }
                else return "INVALID REQUEST! Invalid Metric name or Imperial Name ";

            }
            catch (DbUpdateException db)
            {

                return db.Message;
                
            }

            return "Bad Request ";

        }
         
       

        
    }
}
