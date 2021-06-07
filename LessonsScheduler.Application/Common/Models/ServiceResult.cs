using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Application.Common.Models
{
    public class ServiceResult
    {
        public ServiceResult(List<string> errors)
        {
            Errors = errors;
        }
        public ServiceResult()
        {

        }

        public List<string> Errors { get; set; } = new List<string>();

        public bool Success
        {
            get
            {
                return !Errors.Any();
            }
        }
    }
}
