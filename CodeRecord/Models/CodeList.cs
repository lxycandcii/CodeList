using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace CodeRecord.Models
{
    [Table("CodeList")]
    public class CodeList
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("代码主题")]
        public string CodeName { get; set; }

        [DisplayName("详细内容")]        
        public string Code { get; set; }

        [DisplayName("说明信息")]
        public string Readmd { get; set; }

        [DisplayName("创建时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateTime { get; set; }

        [DisplayName("修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateTime { get; set; }

    }

    public class CodeListContext : DbContext
    {
        public CodeListContext() : base("CodeConn") { }

        public DbSet<CodeList> Codes { get; set; }
    }
}