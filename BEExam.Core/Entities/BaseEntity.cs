using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BEExam.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        private bool IsDeleted { get; set; }

        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        public void RevokeDelete()
        {
            IsDeleted = false;
        }

    }
}
